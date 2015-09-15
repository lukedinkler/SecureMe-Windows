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
            System.Diagnostics.Process.Start(proc);
        }

        public static void DisableGuest() //Diables guest account
        {
            string cmd = "net user guest /active:no";
            AdminEx(cmd);
        }

        public static void EnableFirewall() //Enables Windows Firewall w/ all profiles
        {
            AdminEx("netsh advfirewall set allprofiles state on");
        }

        public static void SetPasswdPolicies()
        {
            AdminEx("net accounts /minpwlen:08");
            AdminEx("net accounts /maxpwage:90");
            AdminEx("net accounts /uniquepw:05");
        }

        public static void SetAuditPolicies()
        {
            AdminEx("auditpol /set /category:\"Account Logon\" /success:enable /failure:enable");
            AdminEx("auditpol /set /category:\"Account Management\" /success:enable /failure:enable");
            AdminEx("auditpol /set /category:\"DS Access\" /success:enable /failure:enable");
            AdminEx("auditpol /set /category:\"Logon / Logoff\" /success:enable /failure:enable");
            AdminEx("auditpol /set /category:\"Object Access\" /success:enable /failure:enable");
            AdminEx("auditpol /set /category:\"Policy Change\" /success:enable /failure:enable");
            AdminEx("auditpol /set /category:\"Privilege Use\" /success:enable /failure:enable");
        }

        public static void AutoUpdates()
        {
            AdminEx(@"reg add HKLM\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU /v AUOptions /t REG_DWORD /d 5");

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


    }
}
