using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Management;
using System.ServiceProcess;
using System.Diagnostics;
using WpfAnimatedGif;

namespace SecureMe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> Users = new List<string>();
        public string SelectedUser = "";
        public string username = "";
        public List<string> ServiceList = new List<string>();
        public Dictionary<string, ServiceController> ServiceDict = new Dictionary<string, ServiceController>();
        public string SelectedService = "";
        public string Config = "";
        public string ServiceSettingValue = "";
        public string WinVer = "";
        public string AbbWinVer = "";
        public List<string> ProcessList = new List<string>();
        public Dictionary<string, string> ProcessFileDict = new Dictionary<string, string>();
        public string SelectedProcess = "";
        public Dictionary<string, Process> ProcessDict = new Dictionary<string, Process>();

        public MainWindow()
        {
            InitializeComponent();

            username = Environment.UserName;

            string[] frontlabelchoices = { "Hey, " + username + "!", "What's up, " + username + "?", "Yo, " + username + "!" };
            HeyYouLabel.Content = funclib.RandomChoice(frontlabelchoices);

            var RawWinVer = (from x in new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem").Get().OfType<ManagementObject>()
                             select x.GetPropertyValue("Caption")).FirstOrDefault();

            if (RawWinVer == null)
            {
                WinVer = "UNKNOWN";
            }
            else
            {
                WinVer = RawWinVer.ToString();
            }

            Uri OSPicURI = new Uri(@"pack://application:,,,/Images/Win8.png");

            if (WinVer.StartsWith("Microsoft Windows 10"))
            {
                AbbWinVer = "10";
                OSPicURI = new Uri(@"pack://application:,,,/Images/Win10.png");
            }
            if (WinVer.StartsWith("Microsoft Windows 8"))
            {
                AbbWinVer = "8";
                OSPicURI = new Uri(@"pack://application:,,,/Images/Win8.png");
            }
            if (WinVer.StartsWith("Microsoft Windows 7"))
            {
                AbbWinVer = "7";
                OSPicURI = new Uri(@"pack://application:,,,/Images/Win7.png");
            }
            if (WinVer.StartsWith("Microsoft Windows Vista"))
            {
                AbbWinVer = "Vista";
                OSPicURI = new Uri(@"pack://application:,,,/Images/WinVista.png");
            }
            if(WinVer.StartsWith("Microsoft Windows XP"))
            {
                AbbWinVer = "XP";
                OSPicURI = new Uri(@"pack://application:,,,/Images/WinXP.png");
            }


            OSLabel.Content = "OS: " + WinVer;
            OSPic.Source = new BitmapImage(OSPicURI);
            CPULabel.Content = "CPU: " + funclib.GetCPUName();
            RAMLabel.Content = "Total RAM: " + funclib.GetRAM();
            ArchLabel.Content = "Architecture: " + funclib.GetCPUArch();

            if (!System.IO.File.Exists("config.dat"))
            {
                funclib.WriteFile("config.dat", "Services Setting: Standard");
                Config = funclib.ReadFile("config.dat");
                string[] conflines = Config.Split('\n');
                ServiceSettingValue = conflines[0].Substring(18);
                ServicesSettingsSafeBtn.IsChecked = true;
            }
            else
            {
                Config = funclib.ReadFile("config.dat");
                string[] conflines = Config.Split('\n');
                ServiceSettingValue = conflines[0].Substring(18);
                ServiceSettingValue = ServiceSettingValue.TrimEnd('\r', '\n');

                if (ServiceSettingValue == "Standard")
                {
                    ServicesSettingsSafeBtn.IsChecked = true;

                }
                else if (ServiceSettingValue == "Admin")
                {
                    ServicesSettingAdminBtn.IsChecked = true;

                }
            }

            SelectQuery query = new SelectQuery("Win32_UserAccount");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            foreach (ManagementObject envVar in searcher.Get())
            {
                Users.Add(envVar["name"].ToString());
            }

            foreach (string usr in Users)
            {
                AddUser(usr);
            }

            Public.UserNames = Users;
            

            System.ServiceProcess.ServiceController[] services;
            services = System.ServiceProcess.ServiceController.GetServices();
            foreach (ServiceController SC in services)
            {
                ServiceList.Add(SC.ServiceName);
                ServiceDict.Add(SC.ServiceName, SC);
            }

            foreach (string svc in ServiceList)
            {
                AddService(svc);
            }

            string[] startupmodes = { "Automatic", "Manual" };
            foreach(string m in startupmodes)
            {
                AddStartupMode(m);
            }

            var ProcessTimer = new System.Windows.Threading.DispatcherTimer();
            ProcessTimer.Tick += ProcessTimer_Tick;
            ProcessTimer.Interval = new TimeSpan(0, 0, 10);
            ProcessTimer.Start();

            UpdateProcesses();


            

        }

        private void ProcessTimer_Tick(object sender, EventArgs e)
        {
            UpdateProcesses();
        }

        public void AddUser(string name)
        {
            ListBoxItem usr = new ListBoxItem();
            usr.Content = name;
            usr.FontSize = 18;
            usr.Foreground = Brushes.White;
            UsersBox.Items.Add(usr);
        }

        public void AddService(string svcname)
        {
            ListBoxItem svc = new ListBoxItem();
            svc.Content = svcname;
            svc.FontSize = 17;
            svc.Foreground = Brushes.White;
            ServicesBox.Items.Add(svc);
        }

        public void AddStartupMode(string mode)
        {
            ComboBoxItem itm = new ComboBoxItem();
            itm.Content = mode;
            ServiceStartupModeBox.Items.Add(itm);
        }

        public void AddProcess(string procname)
        {
            ListBoxItem proc = new ListBoxItem();
            proc.Content = procname;
            proc.FontSize = 17;
            proc.Foreground = Brushes.White;
            ProcessBox.Items.Add(proc);
        }

        public void UpdateProcesses()
        {
            ProcessList = new List<string>();
            Process[] processes = Process.GetProcesses();
            ProcessFileDict = new Dictionary<string, string>();
            ProcessDict = new Dictionary<string, Process>();

            foreach (Process proc in processes)
            {
                ProcessList.Add(proc.ProcessName);
            }

            ProcessBox.Items.Clear();

            foreach(string proc in ProcessList)
            {
                AddProcess(proc);
            }
        }

        private void FullSecureButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri FSBtnIMG = new Uri(@"pack://application:,,,/Images/Full-Secure-D1-Glow.png");
            FullSecureButton.Source = new BitmapImage(FSBtnIMG);
        }

        private void FullSecureButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri FSBtnIMG = new Uri(@"pack://application:,,,/Images/Full-Secure-D1.png");
            FullSecureButton.Source = new BitmapImage(FSBtnIMG);
        }

        private void FullSecureButton_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Public.LoadSecureMode = "Full";
            Loader FullSecure = new Loader();
            FullSecure.ShowDialog();

        }

        private void BasicSecureButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri BSBtnIMG = new Uri(@"pack://application:,,,/Images/Basic-Secure-D1-Glow.png");
            BasicSecureButton.Source = new BitmapImage(BSBtnIMG);
        }

        private void BasicSecureButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri BSBtnIMG = new Uri(@"pack://application:,,,/Images/Basic-Secure-D1.png");
            BasicSecureButton.Source = new BitmapImage(BSBtnIMG);
        }

        private void BasicSecureButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Loader BasicSecure = new Loader();
            Public.LoadSecureMode = "Basic";
            BasicSecure.ShowDialog();
        }

        private void ManualSelectButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri MSBtnIMG = new Uri(@"pack://application:,,,/Images/ManualSelect-D1-Glow.png");
            ManualSelectButton.Source = new BitmapImage(MSBtnIMG);
        }

        private void ManualSelectButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri MSBtnIMG = new Uri(@"pack://application:,,,/Images/ManualSelect-D1.png");
            ManualSelectButton.Source = new BitmapImage(MSBtnIMG);
        }

        private void ManualSelectButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Manual Select code here
        }

        private void UsersBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UsersBox.SelectedIndex > -1)
            {

                SelectedUser = ((ListBoxItem)UsersBox.SelectedValue).Content.ToString();
                SelectedUserLabel.Content = "Selected User: " + SelectedUser;

            }
        }

        private void AddUserBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri AUBtnIMG = new Uri(@"pack://application:,,,/Images/Add-Icon-D1-Glow.png");
            AddUserBtn.Source = new BitmapImage(AUBtnIMG);
        }

        private void AddUserBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri AUBtnIMG = new Uri(@"pack://application:,,,/Images/Add-Icon-D1.png");
            AddUserBtn.Source = new BitmapImage(AUBtnIMG);
        }

        private void RemoveUserBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri RUBtnIMG = new Uri(@"pack://application:,,,/Images/Remove-Icon-D1-Glow.png");
            RemoveUserBtn.Source = new BitmapImage(RUBtnIMG);
        }

        private void RemoveUserBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri RUBtnIMG = new Uri(@"pack://application:,,,/Images/Remove-Icon-D1.png");
            RemoveUserBtn.Source = new BitmapImage(RUBtnIMG);
        }

        private void RemoveUserBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (UsersBox.SelectedIndex > -1)
            {
                if (SelectedUser != "DefaultAccount" && SelectedUser != "Administrator" && SelectedUser != username)
                {
                    string usrname = SelectedUser;
                    funclib.AdminEx("net user " + usrname + " /DELETE");
                    UsersBox.Items.RemoveAt(UsersBox.SelectedIndex);
                    MessageBox.Show("User successfully removed!");
                    UsersBox.SelectedIndex = -1;
                    Public.UserNames.Remove(usrname);
                    Users.Remove(usrname);
                }
                else
                {
                    MessageBox.Show("Sorry, but you can't remove this user!");
                }
            }
            else
            {
                MessageBox.Show("Please select a user to remove!");
            }
        }

        private void AddUserBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddUser AU = new AddUser();
            AU.ShowDialog();
            if (Public.UserAdded)
            {
                MessageBox.Show("User added successfully!");
                AddUser(Public.NewUserName);
            }
            Public.UserAdded = false;
        }

        private void ServicesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedService = ((ListBoxItem)ServicesBox.SelectedValue).Content.ToString();
            ServiceController SelectedController = ServiceDict[SelectedService];
            string status = SelectedController.Status.ToString();
            string startuptype = funclib.GetServiceStartupType(SelectedService);
            if(startuptype == "MANUAL")
            {
                ServiceStartupModeBox.SelectedIndex = 1;
            }
            else if(startuptype == "AUTOMATIC")
            {
                ServiceStartupModeBox.SelectedIndex = 0;
            }
            else if(startuptype == "DISABLED")
            {
                ServiceStartupModeBox.SelectedIndex = -1;
            }

            ServiceStatusLabel.Content = "Status: " + status + " - " + startuptype;
        }

        private void StartServiceBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri SSBtnIMG = new Uri(@"pack://application:,,,/Images/Start-Icon-D1-Glow.png");
            StartServiceBtn.Source = new BitmapImage(SSBtnIMG);
        }

        private void StartServiceBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri SSBtnIMG = new Uri(@"pack://application:,,,/Images/Start-Icon-D1.png");
            StartServiceBtn.Source = new BitmapImage(SSBtnIMG);
        }

        private void StopServiceBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri SSBtnIMG = new Uri(@"pack://application:,,,/Images/Stop-Icon-D1-Glow.png");
            StopServiceBtn.Source = new BitmapImage(SSBtnIMG);
        }

        private void StopServiceBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri SSBtnIMG = new Uri(@"pack://application:,,,/Images/Stop-Icon-D1.png");
            StopServiceBtn.Source = new BitmapImage(SSBtnIMG);
        }

        private void DisableServiceBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri DSBtnIMG = new Uri(@"pack://application:,,,/Images/Disable-Icon-D1-Glow.png");
            DisableServiceBtn.Source = new BitmapImage(DSBtnIMG);
        }

        private void DisableServiceBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri DSBtnIMG = new Uri(@"pack://application:,,,/Images/Disable-Icon-D1.png");
            DisableServiceBtn.Source = new BitmapImage(DSBtnIMG);
        }

        private void StartServiceBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ServicesBox.SelectedIndex > -1)
            {
                var svctointerface = ServiceDict[SelectedService];
                string currstatus = svctointerface.Status.ToString();
                if (currstatus == "Running")
                {
                    MessageBox.Show("Service is already started, silly!");
                }
                else
                {
                    if (ServiceSettingValue == "Admin")
                    {
                        funclib.AdminEx("net start " + SelectedService);
                        SwapServiceController(SelectedService);
                        MessageBox.Show("Administrative command sent!");
                    }
                    else
                    {
                        try
                        {
                            svctointerface.Start();
                            MessageBox.Show("Service is starting!");
                        }
                        catch (Exception eerr)
                        {
                            MessageBox.Show("Unable to start service!\n" + eerr.Message);
                        }
                    }

                    ServiceStatusLabel.Content = "Status: ";
                }

            }
            else
            {
                MessageBox.Show("Please select a service to start!");
            }
        }

        private void StopServiceBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ServicesBox.SelectedIndex > -1)
            {
                var svctointerface = ServiceDict[SelectedService];
                string svcstatus = svctointerface.Status.ToString();
                if (svcstatus == "Stopped")
                {
                    MessageBox.Show("The service is already stopped, silly!");
                }
                else
                {
                    if (ServiceSettingValue == "Admin")
                    {
                        funclib.AdminEx("net stop " + SelectedService);
                        SwapServiceController(SelectedService);
                        MessageBox.Show("Administrative service change status request sent!");
                    }
                    else
                    {
                        try
                        {
                            svctointerface.Stop();
                            MessageBox.Show("Stopping service...");
                        }
                        catch (Exception er)
                        {
                            MessageBox.Show("Unable to stop service!\n" + er.Message);
                        }

                    }
                    ServiceStatusLabel.Content = "Status: ";
                }

            }
            else
            {
                MessageBox.Show("Please select a service to stop!");
            }
        }

        private void DisableServiceBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ServicesBox.SelectedIndex > -1)
            {
                var svctointerface = ServiceDict[SelectedService];
                string svcstatus = svctointerface.Status.ToString();
                if (svcstatus == "Running")
                {
                    if(ServiceSettingValue == "Admin")
                    {
                        funclib.AdminEx("net stop " + SelectedService);
                        funclib.AdminEx("sc config \"" + SelectedService + "\" start= disabled");
                        SwapServiceController(SelectedService);
                        MessageBox.Show("Admin Service disable request sent!");
                    }
                    else
                    {
                        try
                        {
                            svctointerface.Stop();
                            funclib.AdminEx("sc config \"" + SelectedService + "\" start= disabled");
                            MessageBox.Show("Service disabled!");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Unable to stop service to disable it!");
                        }
                    }
                    
                }
                else
                {
                    funclib.AdminEx("sc config \"" + SelectedService + "\" start= disabled");
                    SwapServiceController(SelectedService);
                    MessageBox.Show("Service disabled!");
                }

                ServiceStatusLabel.Content = "Status: ";
            }
            else
            {
                MessageBox.Show("Please select a service to disable!");
            }
        }

        private void SettingsSaveBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri SSBtnIMG = new Uri(@"pack://application:,,,/Images/Save-Icon-D1-Glow.png");
            SettingsSaveBtn.Source = new BitmapImage(SSBtnIMG);
        }

        private void SettingsSaveBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri SSBtnIMG = new Uri(@"pack://application:,,,/Images/Save-Icon-D1.png");
            SettingsSaveBtn.Source = new BitmapImage(SSBtnIMG);
        }

        private void SettingsSaveBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ServicesSettingAdminBtn.IsChecked == true || ServicesSettingsSafeBtn.IsChecked == true)
            {
                if (ServicesSettingsSafeBtn.IsChecked == true)
                {
                    ServiceSettingValue = "Standard";
                }
                else
                {
                    ServiceSettingValue = "Admin";
                }

                string conftowrite = "Services Setting: " + ServiceSettingValue;
                funclib.WriteFile("config.dat", conftowrite);
                Config = conftowrite;
                MessageBox.Show("Settings successfully saved!");


            }
            else
            {
                MessageBox.Show("Error! Missing required info!");
            }
        }
        public void SwapServiceController(string servicename)
        {
            ServiceDict.Remove(servicename);
            ServiceController svc_controller = new ServiceController(servicename);
            ServiceDict.Add(servicename, svc_controller);
        }

        private void KillProcessBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri KPBTNURI = new Uri(@"pack://application:,,,/Images/Kill-Icon-D1-Glow.png");
            KillProcessBtn.Source = new BitmapImage(KPBTNURI);
        }

        private void KillProcessBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri KPBTNURI = new Uri(@"pack://application:,,,/Images/Kill-Icon-D1.png");
            KillProcessBtn.Source = new BitmapImage(KPBTNURI);
        }

        private void RefreshProcessBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri RPBTNURI = new Uri(@"pack://application:,,,/Images/Refresh-Icon-D1-Glow.png");
            RefreshProcessBtn.Source = new BitmapImage(RPBTNURI);
        }

        private void RefreshProcessBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri RPBTNURI = new Uri(@"pack://application:,,,/Images/Refresh-Icon-D1.png");
            RefreshProcessBtn.Source = new BitmapImage(RPBTNURI);
        }

        private void RefreshProcessBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UpdateProcesses();
        }

        private void KillProcessBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(ProcessBox.SelectedIndex > -1)
            {
                Process[] ptokill = Process.GetProcessesByName(SelectedProcess);
                foreach(Process proc in ptokill)
                {
                    try
                    {
                        proc.Kill();
                        MessageBox.Show("Process Terminated!");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Unable to terminate process. Access Denied!");
                        break;
                    }
                    
                }
                
                UpdateProcesses();
            }
        }

        private void ProcessBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProcessBox.SelectedIndex > -1)
            {

                SelectedProcess = ((ListBoxItem)ProcessBox.SelectedValue).Content.ToString();
                Process[] selecproc = Process.GetProcessesByName(SelectedProcess);
                Process myproc = selecproc[0];
                string fileloc;
                string pid;
                pid = myproc.Id.ToString();
                try
                {
                    fileloc = myproc.Modules[0].FileName;
                }
                catch
                {
                    fileloc = "Unavailable";
                }
                ProcessFileLabel.Text = "File: " + fileloc;
                PIDLabel.Content = "PID: " + pid;
            }
        }

        private void EnableServiceBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri ESBTNURI = new Uri(@"pack://application:,,,/Images/Enable-Icon-D1-Glow.png");
            EnableServiceBtn.Source = new BitmapImage(ESBTNURI);
        }

        private void EnableServiceBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri ESBTNURI = new Uri(@"pack://application:,,,/Images/Enable-Icon-D1.png");
            EnableServiceBtn.Source = new BitmapImage(ESBTNURI);
        }

        private void EnableServiceBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(ServicesBox.SelectedIndex > -1)
            {
                if(ServiceStartupModeBox.SelectedIndex > -1)
                {
                    int mode = ServiceStartupModeBox.SelectedIndex;
                    if(mode == 0)
                    {
                        funclib.AdminEx("sc config " + SelectedService + " start=auto");
                    }
                    else if(mode == 1)
                    {
                        funclib.AdminEx("sc config " + SelectedService + " start=demand");
                    }
                    SwapServiceController(SelectedService);
                    MessageBox.Show("Service enabled!");
                }
                else
                {
                    MessageBox.Show("Please select a startup mode for this service!");
                }
            }
            else
            {
                MessageBox.Show("Please select a service to enable a startup mode for.");
            }
        }
    }
    
}
