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
    /// Interaction logic for PasswdChange.xaml
    /// </summary>
    public partial class PasswdChange : Window
    {
        public PasswdChange()
        {
            InitializeComponent();
        }

        private void SetPasswdButton_Click(object sender, RoutedEventArgs e)
        {
            if (SetPasswdBox.Text == "" || SetPasswdBox.Text == " ")
            {
                MessageBox.Show("Please enter a password first!");
            }
            else
            {
                string usr = MainWindow.PasswordChangeUser;
                funclib.AdminEx("net user " + usr + " " + SetPasswdBox.Text);
                MessageBox.Show("Password set!");
                this.Close();
            }
        }
    }
}
