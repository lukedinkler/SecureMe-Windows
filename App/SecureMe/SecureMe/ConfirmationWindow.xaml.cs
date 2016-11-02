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
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace SecureMe
{
    /// <summary>
    /// Interaction logic for ConfirmationWindow.xaml
    /// </summary>
    public partial class ConfirmationWindow : Window
    {
        public ConfirmationWindow()
        {
            InitializeComponent();
            AreYouSure.Text = "Are you sure you wish to continue, " + Public.CurrentUser + "?";   
        }

        private void NoBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            NoBtn.Source = new BitmapImage(new Uri(@"pack://application:,,,/Images/Remove-Icon-D1-Glow.png"));
        }

        private void NoBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            NoBtn.Source = new BitmapImage(new Uri(@"pack://application:,,,/Images/Remove-Icon-D1.png"));
        }

        private void NoBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Public.Confirm = false;
            this.Close();
        }

        private void YesBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            YesBtn.Source = new BitmapImage(new Uri(@"pack://application:,,,/Images/Enable-Icon-D1-Glow.png"));
        }

        private void YesBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            YesBtn.Source = new BitmapImage(new Uri(@"pack://application:,,,/Images/Enable-Icon-D1.png"));
        }

        private void YesBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Public.Confirm = true;
            this.Close();
        }

        private void Confirmation_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Closing -= Confirmation_Closing;
            e.Cancel = true;
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.5));
            anim.Completed += (s, _) => this.Close();
            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }
    }
}
