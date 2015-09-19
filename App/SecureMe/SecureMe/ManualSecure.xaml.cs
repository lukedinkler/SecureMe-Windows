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
using System.Windows.Shapes;

namespace SecureMe
{
    /// <summary>
    /// Interaction logic for ManualSecure.xaml
    /// </summary>
    public partial class ManualSecure : Window
    {
        public string SelectedOption = "";

        public ManualSecure()
        {
            InitializeComponent();
            string[] security_options = { "Enable Firewall", "Disable Firewall", "Disable IPv6", "Disable Guest Account", "Enable Automatic Windows Updates" };
            foreach(string opt in security_options)
            {
                AddSecurityOption(opt);
            }
        }

        public void AddSecurityOption(string otp)
        {
            ListBoxItem itm = new ListBoxItem();
            itm.Content = otp;
            itm.FontSize = 19;
            itm.Foreground = Brushes.LightGreen;
            ManSecureBox.Items.Add(itm);
        }

        private void ApplyOptionBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri AOBTNURI = new Uri(@"pack://application:,,,/Images/Terminal-Icon-D1-Glow.png");
            ApplyOptionBtn.Source = new BitmapImage(AOBTNURI);
        }

        private void ApplyOptionBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(ManSecureBox.SelectedIndex > -1)
            {
                if(SelectedOption == "Enable Firewall")
                {
                    funclib.EnableFirewall();
                    MessageBox.Show("Firewall Enabled!");
                }
                else if(SelectedOption == "Disable Firewall")
                {
                    funclib.DisableFirewall();
                    MessageBox.Show("Firewall Disabled!");
                }
                else if(SelectedOption == "Disable IPv6")
                {
                    funclib.DisableIPv6();
                    MessageBox.Show("IPv6 disabled!");
                }
                else if(SelectedOption == "Disable Guest Account")
                {
                    funclib.DisableGuest();
                    MessageBox.Show("Guest Account Disabled!");
                }
                else if(SelectedOption == "Enable Automatic Windows Updates")
                {
                    funclib.AutoUpdates();
                    MessageBox.Show("Automatic Windows updates are enabled!");
                }
            }
            else
            {
                MessageBox.Show("Please select an option to apply!");
            }
        }

        private void ApplyOptionBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri AOBTNURI = new Uri(@"pack://application:,,,/Images/Terminal-Icon-D1.png");
            ApplyOptionBtn.Source = new BitmapImage(AOBTNURI);
        }

        private void ManSecureBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ManSecureBox.SelectedIndex > -1)
            {
                SelectedOption = ((ListBoxItem)ManSecureBox.SelectedValue).Content.ToString();
            }
        }
    }
}
