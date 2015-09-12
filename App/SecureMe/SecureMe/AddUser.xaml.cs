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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            string usrname = UsernameBox.Text;
            string usrpasswd = UserPasswordBox.Password;
            string account_type = "";
            bool account_type_given;
            bool NoPass;
            if (NoPassChangeCheck.IsChecked == true)
            {
                NoPass = true;
            }
            else
            {
                NoPass = false;
            }
            if(StandardTypeBtn.IsChecked == true || AdministratorTypeBtn.IsChecked == true)
            {
                account_type_given = true;
                if(StandardTypeBtn.IsChecked == true)
                {
                    account_type = "Standard";
                }
                else
                {
                    account_type = "Admin";
                }
            }
            else
            {
                account_type_given = false;
            }
            if(usrname != "" && usrpasswd != "" && usrname != " " && account_type_given)
            {
                if (Public.UserNames.Contains(usrname))
                {
                    MessageBox.Show("Sorry! That username is already taken! Please choose a different one.");
                }
                else
                {
                    string cmd;
                    if (NoPass)
                    {
                        cmd = "net user " + usrname + " " + usrpasswd + " /ADD PASSWORDCHG:No";
                    }
                    else
                    {
                        cmd = "net user " + usrname + " " + usrpasswd + " /ADD";
                    }
                    funclib.AdminEx(cmd);
                    if(account_type == "Admin")
                    {
                        funclib.AdminEx("net localgroup administrators " + usrname + " /ADD");
                    }
                    Public.UserAdded = true;
                    Public.NewUserName = usrname;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Sorry, Please try again! There is missing required information!");
            }

        }
    }
}
