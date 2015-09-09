# Made by Luke Dinkler and Peter Toth
import GUI, funclib

def Init():
        MainMenu()
        
def MainMenu():
       menu = GUI.buttonbox("Welcome to SecureMe! Please select an option to begin", choices=["Full Secure", "Partial Secure", "About"])
       if menu == "About":
               about = GUI.buttonbox("""SecureMe Version 0.1 Beta 0
Developed by Luke Dinkler and Peter Toth 2015""", choices=["OK"])
               MainMenu()
               
if __name__ == '__main__':
        Init()
