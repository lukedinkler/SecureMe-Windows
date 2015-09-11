using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SecureMe
{
    class funclib
    {
        public void AdminEx(string command) //Runs an Administrative Windows Command
        {
            var proc = new System.Diagnostics.ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = @"C:\Windows\System32";
            proc.FileName = @"C:\Windows\System32\cmd.exe";
            proc.Verb = "runas";
            proc.Arguments = "/c " + command;
            proc.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            System.Diagnostics.Process.Start(proc);
        }

        public void DisableGuest() //Diables guest account
        {
            string cmd = "net user guest /active:no >NUL";
            AdminEx(cmd);
        }

        public void EnableFirewall() //Enables Windows Firewall w/ all profiles
        {
            AdminEx("netsh advfirewall set allprofiles state on");
        }

        public void SetPasswdPolicies()
        {
            AdminEx("net accounts /minpwlen:08");
            AdminEx("net accounts /maxpwage:90");
            AdminEx("net accounts /uniquepw:05");
        }

        public void SetAuditPolicies()
        {
            AdminEx("auditpol /set /category:\"Account Logon\" /success:enable /failure:enable");
            AdminEx("auditpol /set /category:\"Account Management\" /success:enable /failure:enable");
            AdminEx("auditpol /set /category:\"DS Access\" /success:enable /failure:enable");
            AdminEx("auditpol /set /category:\"Logon / Logoff\" /success:enable /failure:enable");
            AdminEx("auditpol /set /category:\"Object Access\" /success:enable /failure:enable");
            AdminEx("auditpol /set /category:\"Policy Change\" /success:enable /failure:enable");
            AdminEx("auditpol /set /category:\"Privilege Use\" /success:enable /failure:enable");
        }

        public void AutoUpdates()
        {
            AdminEx(@"reg add HKLM\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU /v AUOptions /t REG_DWORD /d 5");

        }

        
    }
}
