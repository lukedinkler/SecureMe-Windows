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

namespace SecureMe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
    }
}
