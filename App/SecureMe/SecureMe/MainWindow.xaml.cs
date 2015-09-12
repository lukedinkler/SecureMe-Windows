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
        

        public MainWindow()
        {
            InitializeComponent();
            SelectQuery query = new SelectQuery("Win32_UserAccount");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            foreach (ManagementObject envVar in searcher.Get())
            {
                Users.Add(envVar["name"].ToString());
            }

            foreach(string usr in Users)
            {
                AddUser(usr);
            }

            Public.UserNames = Users;
            username = Environment.UserName;
            
        }

        public void AddUser(string name)
        {
            ListBoxItem usr = new ListBoxItem();
            usr.Content = name;
            usr.FontSize = 16;
            usr.Foreground = Brushes.White;
            UsersBox.Items.Add(usr);
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
            //Full Secure Code here
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
            //Basic Secure Code here
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
            if(UsersBox.SelectedIndex > -1)
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
            if(UsersBox.SelectedIndex > -1)
            {
                if(SelectedUser != "DefaultAccount" && SelectedUser != "Administrator" && SelectedUser != username)
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
    }
}
