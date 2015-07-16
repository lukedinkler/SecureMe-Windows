#Made by Luke Dinkler and Peter Toth
#Function Library for SecureMe
import os, win32
import win32com.shell.shell as win32shell
import winshell

def AdminEx(command):
    win32shell.ShellExecuteEx(lpVerb='runas', lpFile='cmd.exe', lpParameters='/c ' + command)
