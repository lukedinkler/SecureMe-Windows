#Made by Luke Dinkler and Peter Toth
#Function Library for SecureMe
import os, win32
import win32com.shell.shell as win32shell
import winshell

def AdminEx(command):
    win32shell.ShellExecuteEx(lpVerb='runas', lpFile='cmd.exe', lpParameters='/c ' + command)

def DisableGuest():
    AdminEx("net user guest /active:no >NUL")

def EnableFirewall():
    AdminEx("netsh advfirewall set allprofiles state on")

def EnableUAC():
    AdminEx("C:\Windows\System32\reg.exe ADD HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System /v EnableLUA /t REG_DWORD /d 2 /f")
    #Requires reboot
