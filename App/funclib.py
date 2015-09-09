#Made by Luke Dinkler and Peter Toth
#Function Library for SecureMe
import os, win32
import win32com.shell.shell as win32shell

def AdminEx(command):
    win32shell.ShellExecuteEx(lpVerb='runas', lpFile='cmd.exe', lpParameters='/c ' + command)

def DisableGuest():
    AdminEx("net user guest /active:no >NUL")

def EnableFirewall():
    AdminEx("netsh advfirewall set allprofiles state on")

def EnableUAC():
    AdminEx("C:\Windows\System32\reg.exe ADD HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System /v EnableLUA /t REG_DWORD /d 2 /f")
    #Requires reboot

def SetPasswordPolicies():
    pol1 = "net accounts /minpwlen:08"
    pol2 = "net accounts /maxpwage:90"
    pol3 = "net accounts /uniquepw:05"
    AdminEx(pol1)
    AdminEx(pol2)
    AdminEx(pol3)

def SetAuditPolicies():
    pol1 = """auditpol /set /category:"Account Logon" /success:enable /failure:enable"""
    pol2 = """auditpol /set /category:"Account Management" /success:enable /failure:enable"""
    pol3 = """auditpol /set /category:"DS Access" /success:enable /failure:enable"""
    pol4 = """auditpol /set /category:"Logon/Logoff" /success:enable /failure:enable"""
    pol5 = """auditpol /set /category:"Object Access" /success:enable /failure:enable"""
    pol6 = """auditpol /set /category:"Policy Change" /success:enable /failure:enable"""
    pol7 = """auditpol /set /category:"Privilege Use" /success:enable /failure:enable"""
    AdminEx(pol1)
    AdminEx(pol2)
    AdminEx(pol3)
    AdminEx(pol4)
    AdminEx(pol5)
    AdminEx(pol6)
    AdminEx(pol7)

def EnableAutoUpdates():
    reg_command = "reg add HKLM\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU /v AUOptions /t REG_DWORD /d 5"
    AdminEx(reg_command)
    
def FullLockdown():
    DisableGuest()
    EnableFirewall()
    SetPasswordPolicies()
    SetAuditPolicies()
    EnableAutoUpdates()
