using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using Microsoft.VisualBasic.Devices;
using System.Management;
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
    class funclib
    {
        public static void AdminEx(string command) //Runs an Administrative Windows Command
        {
            var proc = new System.Diagnostics.ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = @"C:\Windows\System32";
            proc.FileName = @"C:\Windows\System32\cmd.exe";
            proc.Verb = "runas";
            proc.Arguments = "/c " + command;
            proc.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            var p = System.Diagnostics.Process.Start(proc);
            p.WaitForExit();
        }

        public static void DisableGuest() //Diables guest account
        {
            Loader.loader_string = "Disabling guest";
            string cmd = "net user guest /active:no";
            AdminEx(cmd);
        }

        public static void EnableFirewall() //Enables Windows Firewall w/ all profiles
        {
            AdminEx("netsh advfirewall set allprofiles state on");
        }

        public static void DisableFirewall()
        {
            AdminEx("netsh advfirewall set allprofiles state off");
        }

        public static void SetPasswdPolicies()
        {
            Loader.loader_string = "Setting password policies";
            AdminEx("net accounts /lockoutthreshold:3");
            AdminEx("wmic path Win32_UserAccount where PasswordExpires=false set PasswordExpires=true");
            AdminEx("wmic path Win32_UserAccount where Name=\"Guest\" set PasswordExpires=false");
            AdminEx("powercfg -SETDCVALUEINDEX SCHEME_BALANCED SUB_NONE CONSOLELOCK 1");
            AdminEx("powercfg -SETACVALUEINDEX SCHEME_BALANCED SUB_NONE CONSOLELOCK 1");
            AdminEx("powercfg -SETDCVALUEINDEX SCHEME_MIN SUB_NONE CONSOLELOCK 1");
            AdminEx("powercfg -SETDCVALUEINDEX SCHEME_MAX SUB_NONE CONSOLELOCK 1");
            AdminEx("net accounts /FORCELOGOFF:30 /MINPWLEN:8 /MAXPWAGE:30 /MINPWAGE:10 /UNIQUEPW:5 ");
         
        }

        public static void SetAuditPolicies()
        {
            Loader.loader_string = "Setting Audit policies";
            AdminEx("auditpol /set /category:\"Account Logon\" /success:enable /failure:enable");
            AdminEx("auditpol /set /category:\"Account Management\" /success:enable /failure:enable");
            AdminEx("auditpol /set /category:\"DS Access\" /success:enable /failure:enable");
            AdminEx("auditpol /set /category:\"Logon / Logoff\" /success:enable /failure:enable");
            AdminEx("auditpol /set /category:\"Object Access\" /success:enable /failure:enable");
            AdminEx("auditpol /set /category:\"Policy Change\" /success:enable /failure:enable");
            AdminEx("auditpol /set /category:\"Privilege Use\" /success:enable /failure:enable");
     
        }

        public static void DoVariousTasks()
        {
            Loader.loader_string = "Preforming various tasks";
            AdminEx("schtasks /Delete /TN * /f > NUL");
            AdminEx("ipconfig /flushdns > NUL");
            AdminEx("reg ADD \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\" /v Hidden /t REG_DWORD /d 1 /f > NUL");
            AdminEx("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\" /v HideFileExt /t REG_DWORD /d 0 /f > NUL");
            AdminEx("reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\" /v HideDrivesWithNoMedia /t REG_DWORD /d 0 /f > NUL");
            AdminEx("reg ADD \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\" /v ShowSuperHidden /t REG_DWORD /d 1 /f > NUL");
        }
        public static void DisableVulnerableServices()
        {
            Loader.loader_string = "Disabling vulnerable services";
            AdminEx("net stop RemoteRegistry");
            AdminEx("sc config RemoteRegistry start= disabled");
            AdminEx("net stop RemoteAccess");
            AdminEx("sc config RemoteAccess start= disabled");
            AdminEx("net stop Telephony");
            AdminEx("sc config Telephony start= disabled");
            AdminEx("net stop tlntsvr");
            AdminEx("sc config tlntsvr start= disabled");
            AdminEx("net stop p2pimsvc");
            AdminEx("sc config p2pimsvc start= disabled");
            AdminEx("net stop simptcp");
            AdminEx("sc config simptcp start= disabled");
            AdminEx("net stop fax");
            AdminEx("sc config fax start= disabled");
            AdminEx("net stop msftpsvc");
            AdminEx("sc config msftpsvc start= disabled");
            AdminEx("net stop telnet");
            AdminEx("sc config telnet start= disabled");
            AdminEx("net stop termservice");
            AdminEx("sc config termservice start= disabled");
            
        }

        public static void GrabSysInfo()
        {
            Loader.loader_string = "Getting system information";
            AdminEx("mkdir %userprofile%\\Desktop\\reports");
            //AdminEx("set basedpath=%userprofile%\\Desktop\\reports");
            //AdminEx("del /q %basedpath%\\*.*");
            AdminEx("net start >> %userprofile%\\Desktop\\reports\\services.txt");
            AdminEx("tasklist /svc >> %userprofile%\\Desktop\\reports\\processes.txt");
            AdminEx("driverquery >> %userprofile%\\Desktop\\reports\\driverinfo.txt");
            AdminEx("net users >> %userprofile%\\Desktop\\reports\\usersreport.txt");
            AdminEx("net localgroup Administrators >> %userprofile%\\Desktop\\reports\\usersreport.txt");
           

        }

        public static void AutoUpdates()
        {
            AdminEx(@"reg add HKLM\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU /v AUOptions /t REG_DWORD /d 5 /f");

        }

        public static void DisableWifi()
        {
            AdminEx("netsh interface set interface \"Wi-Fi\" admin=disabled");
        }

        public static string GetCmdOutput(string cmd)
        {
            // Start the child process.
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = cmd;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return output;
        }

        public static string ServiceStatus(string svcname)
        {
            string cmd = "for / f \"tokens=2*\" % a in ('sc query audiosrv ^| findstr STATE') do echo % b";
            string statusraw = GetCmdOutput(cmd);
            return statusraw;
        }

        public static void WriteFile(string file, string stufftowrite)
        {
            StreamWriter SW = new StreamWriter(file);
            SW.WriteLine(stufftowrite);
            SW.Close();
        }

        public static string ReadFile(string file)
        {
            StreamReader SR = new StreamReader(file);
            string retval = SR.ReadToEnd();
            SR.Close();
            return retval;
        }

        public static void DisableIPv6()
        {
            AdminEx(@"reg add HKLM\SYSTEM\CurrentControlSet\Services\Tcpip6\Parameters\ /v DisabledComponents /t REG_DWORD /d 0x11 /f");
        }

        public static string GetServiceStartupType(string svcname)
        {
            var reg = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\services\" + svcname);

            int startupTypeValue = (int)reg.GetValue("Start");

            string startupType = string.Empty;

            switch (startupTypeValue)
            {
                case 0:
                    startupType = "BOOT";
                    break;

                case 1:
                    startupType = "SYSTEM";
                    break;

                case 2:
                    startupType = "AUTOMATIC";
                    break;

                case 3:
                    startupType = "MANUAL";
                    break;

                case 4:
                    startupType = "DISABLED";
                    break;

                default:
                    startupType = "UNKNOWN";
                    break;

            }

            return startupType;
        }

        public static string RandomChoice(string[] cmds) //Pulls a random string from array
        {
            Random rnd = new Random();
            string choosen = cmds[rnd.Next(cmds.Length)];
            return choosen;
        }

        public static string GetRAM()
        {
            ComputerInfo CI = new ComputerInfo();
            ulong mb = CI.TotalPhysicalMemory / 1024 / 1024;
            return  mb.ToString() + " MB";
            
        }

        public static string GetCPUName()
        {
            var cpu =
            new ManagementObjectSearcher("select * from Win32_Processor")
                .Get()
                .Cast<ManagementObject>()
                .First();
            return (string)cpu["name"];
        }

        public static string GetCPUArch()
        {
            var s = System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
            return s;
        }

        public static void AdvFirewallSet(){
            Loader.loader_string = "Setting up firewall";
            AdminEx("netsh advfirewall set allprofiles state on");
            AdminEx("netsh advfirewall reset");
            AdminEx("netsh advfirewall set allprofiles state on");
            AdminEx("netsh advfirewall firewall set rule name=\"Remote Assistance (DCOM-In)\" new enable=no");
            AdminEx("netsh advfirewall firewall set rule name=\"Remote Assistance (PNRP-In)\" new enable=no");
            AdminEx("netsh advfirewall firewall set rule name=\"Remote Assistance (RA Server TCP-In)\" new enable=no");
            AdminEx("netsh advfirewall firewall set rule name=\"Remote Assistance (SSDP TCP-In)\" new enable=no");
            AdminEx("netsh advfirewall firewall set rule name=\"Remote Assistance (SSDP UDP-In)\" new enable=no");
            AdminEx("netsh advfirewall firewall set rule name=\"Remote Assistance (TCP-In)\" new enable=no");
            AdminEx("netsh advfirewall firewall set rule name=\"Telnet Server\" new enable=no");
            AdminEx("netsh advfirewall firewall set rule name=\"Telnet\" new enable=no");
            AdminEx("netsh advfirewall firewall set rule name=\"netcat\" new enable=no ");
          
        }

        public static void SetSecurityPol()
        {
            Loader.loader_string = "Setting security policies";
            AdminEx("reg ADD \"HKLM\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon\" /v AllocateCDRoms /t REG_DWORD /d 1 /f");
            AdminEx("reg ADD \"HKLM\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon\" /v AutoAdminLogon /t REG_DWORD /d 0 /f");
            AdminEx("reg ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management\" /v ClearPageFileAtShutdown /t REG_DWORD /d 1 /f");
            AdminEx("reg ADD \"HKLM\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon\" /v AllocateFloppies /t REG_DWORD /d 1 /f");
           
            AdminEx("reg ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Control\\Print\\Providers\\LanMan Print Services\\Servers\" /v AddPrinterDrivers /t REG_DWORD /d 1 /f");
            AdminEx("reg ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Control\\Lsa\" /v LimitBlankPasswordUse /t REG_DWORD /d 1 /f");
            AdminEx("reg ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Control\\Lsa\" /v auditbaseobjects /t REG_DWORD /d 1 /f");
            AdminEx("reg ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Control\\Lsa\" /v fullprivilegeauditing /t REG_DWORD /d 1 /f");
           
            AdminEx("reg ADD HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System /v dontdisplaylastusername /t REG_DWORD /d 1 /f");
            AdminEx("reg ADD HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System /v PromptOnSecureDesktop /t REG_DWORD /d 1 /f");
            AdminEx("reg ADD HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System /v EnableInstallerDetection /t REG_DWORD /d 1 /f");
            AdminEx("reg ADD HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System /v undockwithoutlogon /t REG_DWORD /d 0 /f");
            AdminEx("reg ADD HKLM\\SYSTEM\\CurrentControlSet\\services\\Netlogon\\Parameters /v MaximumPasswordAge /t REG_DWORD /d 15 /f");
            AdminEx("reg ADD HKLM\\SYSTEM\\CurrentControlSet\\services\\Netlogon\\Parameters /v DisablePasswordChange /t REG_DWORD /d 1 /f");
            AdminEx("reg ADD HKLM\\SYSTEM\\CurrentControlSet\\services\\Netlogon\\Parameters /v RequireStrongKey /t REG_DWORD /d 1 /f");
            AdminEx("reg ADD HKLM\\SYSTEM\\CurrentControlSet\\services\\Netlogon\\Parameters /v RequireSignOrSeal /t REG_DWORD /d 1 /f");
            AdminEx("reg ADD HKLM\\SYSTEM\\CurrentControlSet\\services\\Netlogon\\Parameters /v SignSecureChannel /t REG_DWORD /d 1 /f");
            AdminEx("reg ADD HKLM\\SYSTEM\\CurrentControlSet\\services\\Netlogon\\Parameters /v SealSecureChannel /t REG_DWORD /d 1 /f");
        
            AdminEx("reg ADD HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System /v DisableCAD /t REG_DWORD /d 0 /f");
            AdminEx("reg ADD HKLM\\SYSTEM\\CurrentControlSet\\Control\\Lsa /v restrictanonymous /t REG_DWORD /d 1 /f");
            AdminEx("reg ADD HKLM\\SYSTEM\\CurrentControlSet\\Control\\Lsa /v restrictanonymoussam /t REG_DWORD /d 1 /f");
            AdminEx("reg ADD HKLM\\SYSTEM\\CurrentControlSet\\services\\LanmanServer\\Parameters /v autodisconnect /t REG_DWORD /d 45 /f");
            AdminEx("reg ADD HKLM\\SYSTEM\\CurrentControlSet\\services\\LanmanServer\\Parameters /v enablesecuritysignature /t REG_DWORD /d 0 /f");
            AdminEx("reg ADD HKLM\\SYSTEM\\CurrentControlSet\\services\\LanmanServer\\Parameters /v requiresecuritysignature /t REG_DWORD /d 0 /f");
            AdminEx("reg ADD HKLM\\SYSTEM\\CurrentControlSet\\Control\\Lsa /v disabledomaincreds /t REG_DWORD /d 1 /f");
            AdminEx("reg ADD HKLM\\SYSTEM\\CurrentControlSet\\Control\\Lsa /v everyoneincludesanonymous /t REG_DWORD /d 0 /f");
            AdminEx("reg ADD HKLM\\SYSTEM\\CurrentControlSet\\services\\LanmanWorkstation\\Parameters /v EnablePlainTextPassword /t REG_DWORD /d 0 /f");
            AdminEx("reg ADD HKLM\\SYSTEM\\CurrentControlSet\\services\\LanmanServer\\Parameters /v NullSessionPipes /t REG_MULTI_SZ /d \"\" /f");
            AdminEx("reg ADD HKLM\\SYSTEM\\CurrentControlSet\\Control\\SecurePipeServers\\winreg\\AllowedExactPaths /v Machine /t REG_MULTI_SZ /d \"\" /f");
         
            AdminEx("reg ADD HKLM\\SYSTEM\\CurrentControlSet\\Control\\SecurePipeServers\\winreg\\AllowedPaths /v Machine /t REG_MULTI_SZ /d \"\" /f");
            AdminEx("reg ADD HKLM\\SYSTEM\\CurrentControlSet\\services\\LanmanServer\\Parameters /v NullSessionShares /t REG_MULTI_SZ /d \"\" /f");
            AdminEx("reg ADD HKLM\\SYSTEM\\CurrentControlSet\\Control\\Lsa /v UseMachineId /t REG_DWORD /d 0 /f");
            AdminEx("reg ADD \"HKCU\\Software\\Microsoft\\Internet Explorer\\PhishingFilter\" /v EnabledV8 /t REG_DWORD /d 1 /f");
            AdminEx("reg ADD \"HKCU\\Software\\Microsoft\\Internet Explorer\\PhishingFilter\" /v EnabledV9 /t REG_DWORD /d 1 /f");
            AdminEx("reg ADD HKLM\\SYSTEM\\CurrentControlSet\\Control\\CrashControl /v CrashDumpEnabled /t REG_DWORD /d 0 /f");
            AdminEx("reg ADD HKCU\\SYSTEM\\CurrentControlSet\\Services\\CDROM /v AutoRun /t REG_DWORD /d 1 /f");
            AdminEx("reg ADD \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\" /v DisablePasswordCaching /t REG_DWORD /d 1 /f");
            AdminEx("reg ADD \"HKCU\\Software\\Microsoft\\Internet Explorer\\Main\" /v DoNotTrack /t REG_DWORD /d 1 /f");
            AdminEx("reg ADD \"HKCU\\Software\\Microsoft\\Internet Explorer\\Download\" /v RunInvalidSignatures /t REG_DWORD /d 1 /f");
            AdminEx("reg ADD \"HKCU\\Software\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_LOCALMACHINE_LOCKDOWN\\Settings\" /v LOCALMACHINE_CD_UNLOCK /t REG_DWORD /d 1 /t");
            AdminEx("reg ADD \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\" /v WarnonBadCertRecving /t REG_DWORD /d /1 /f");
            AdminEx("reg ADD \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\" /v WarnOnPostRedirect /t REG_DWORD /d 1 /f");
            AdminEx("reg ADD \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\" /v WarnonZoneCrossing /t REG_DWORD /d 1 /f");
            AdminEx("auditpol /set /category:* /success:enable ");
            AdminEx("auditpol /set /category:* /failure:enable");
           

        }


    }
}
