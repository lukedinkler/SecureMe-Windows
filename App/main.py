# Made by Luke Dinkler and Peter Toth
import GUI, funclib, os, sys

def Init():
        MainMenu()
        
def MainMenu():
       menu = GUI.buttonbox("Welcome to SecureMe! Please select an option to begin:", choices=["Full Lockdown", "Secure", "Choose Security Option", "About"], image="data/SecureMe-icon-d1.gif")
       if menu == "About":
               about = GUI.buttonbox("""SecureMe Version 0.1 Beta 0
Developed by Luke Dinkler and Peter Toth 2015""", choices=["Back"], image="data/about-icon.gif")
               MainMenu()
       elif menu == "Choose Security Option":
               securitypieces = GUI.choicebox("Choose a system security action to preform:", choices=["Firewall: Enable", "Firewall: Disable"])
               if securitypieces == None:
                       MainMenu()
                
       elif menu == "Full Lockdown":
                funclib.DisableGuest()


                
                GUI.buttonbox("SecureMe has fully locked down and secured your computer!", choices=["OK!"], image="data/check.gif")
                MainMenu()

       elif menu == "Secure":
                MainMenu()
                                                                                               
               
if __name__ == '__main__':
        Init()
