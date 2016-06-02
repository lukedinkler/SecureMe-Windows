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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfAnimatedGif;
using System.Threading;

namespace SecureMe
{
    /// <summary>
    /// Interaction logic for Loader.xaml
    /// </summary>
    public partial class Loader : Window
    {
        public int dotnum = 1;
        public int dotcount = 0;
        public int EndCount = 0;
        public System.Windows.Threading.DispatcherTimer CompletionTimer = new System.Windows.Threading.DispatcherTimer();
        public RotateTransform rt = new RotateTransform();
        public DoubleAnimation da = new DoubleAnimation
                (360, 0, new Duration(TimeSpan.FromSeconds(2)));
        public static bool done = false;
        public System.Windows.Threading.DispatcherTimer Securing_Timer = new System.Windows.Threading.DispatcherTimer();
        public Thread FullSecureThd = new Thread(FullSecure);
        public Thread BasicSecureThd = new Thread(BasicSecure);
        public static string loader_string = "";


        public Loader()
        {
            InitializeComponent();

            LoadingIMG.RenderTransform = rt;
            LoadingIMG.RenderTransformOrigin = new Point(0.5, 0.5);
            da.RepeatBehavior = RepeatBehavior.Forever;

            rt.BeginAnimation(RotateTransform.AngleProperty, da);

            
            
            Securing_Timer.Interval = new TimeSpan(0, 0, 1);
            Securing_Timer.Tick += Securing_Timer_Tick;
            Securing_Timer.Start();

            if (Public.LoadSecureMode == "Full")
            {
                FullSecureThd.Start();
            }
            else if (Public.LoadSecureMode == "Basic")
            {
                BasicSecureThd.Start();
                
            }

            CompletionTimer.Interval = new TimeSpan(0, 0, 2);
            CompletionTimer.Tick += CompletionTimer_Tick;
            
        }

        public static void BasicSecure()
        {
            funclib.SetPasswdPolicies();
            funclib.SetAuditPolicies();
            funclib.DisableIPv6();
            funclib.DisableGuest();
            funclib.EnableFirewall();
            funclib.AutoUpdates();
            done = true;
        }

        public static void FullSecure()
        {
            funclib.SetPasswdPolicies();
            funclib.SetAuditPolicies();
            funclib.AdvFirewallSet();
            funclib.DisableIPv6();
            funclib.DisableGuest();
            funclib.EnableFirewall();
            funclib.AutoUpdates();
            funclib.SetSecurityPol();
            funclib.DoVariousTasks();
            funclib.DisableVulnerableServices();
            string scan = funclib.ScanSys();
            if(scan != "")
            {
                //Report possible viruses
            }
            funclib.GrabSysInfo();
            
            done = true;
            
        }

       
        private void CompletionTimer_Tick(object sender, EventArgs e)
        {
            if (BasicSecureThd.IsAlive)
            {
                BasicSecureThd.Join();
            }
            if (FullSecureThd.IsAlive)
            {
                FullSecureThd.Join();
            }
            this.Close();
        }

        private void Securing_Timer_Tick(object sender, EventArgs e)
        {
            if (dotnum == 1)
            {
                LoadingLabel.Content = loader_string + "..";
                dotnum = 2;
                if (done == true)
                {
                    EndCount++;
                }

            }
            else if (dotnum == 2)
            {
                LoadingLabel.Content = loader_string + "...";
                dotnum = 3;
                if (done == true)
                {
                    EndCount++;
                }

            }
            else if (dotnum == 3)
            {
                LoadingLabel.Content = loader_string + ".";
                dotnum = 1;
                dotcount++;
                if (done == true)
                {
                    EndCount++;
                }
            }

            if (EndCount == 2)
            {
                rt.BeginAnimation(RotateTransform.AngleProperty, null);
                Uri CheckUri = new Uri(@"pack://application:,,,/Images/Security_Approved.png");
                LoadingIMG.Source = new BitmapImage(CheckUri);
                LoadingLabel.Content = "System Secure!";
                Securing_Timer.Stop();
                CompletionTimer.Start();
            }
        }

        private void LoadingWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
            Closing -= LoadingWindow_Closing;
            e.Cancel = true;
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.5));
            anim.Completed += (s, _) => this.Close();
            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }
    }
}
