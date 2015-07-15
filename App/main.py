import os, time, subprocess, GUI
print("Welcome to SecureMe!")
MainMenu = GUI.buttonbox("Main Menu:", choices=["Secure", "Exit"])
if MainMenu == "Exit":
    os._exit(1)
    
