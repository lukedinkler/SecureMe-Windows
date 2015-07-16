#Made by Luke Dinkler and Peter Toth
import os, subprocess 
import win32com.shell.shell as win32shell

def AdminEx(command):
    win32shell.ShellExecuteEx(lpVerb='runas', lpFile='cmd.exe', lpParameters='/c ' + command)
