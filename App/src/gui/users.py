# Made by Luke Dinkler and Peter Toth

import Tkinter
from Tkinter import *
import tkMessageBox
import os
os.system("cd ..")
from src.securityfunctions.users import *
from src.securityfunctions.rootpassencryption import *
from src.securityfunctions.admin import *

class AddUser():

	def __init__(self):
		self.root = Tk()
		self.root.geometry("300x125+300+300")
		self.root.title("SecureMe - Add User")
		self.root.config()

		self.users = Users()
		self.enc = Encryption()

		mainlabel = Label(self.root, text="Add User")
		mainlabel.pack()

		self.errorLabel = Label(self.root, text="")
		self.errorLabel.pack()

		fieldFrame = Frame(self.root)
		fieldFrame.pack()

		Label(fieldFrame, text="Username: ").grid(sticky=E)

		usernameEntry = Entry(fieldFrame)
		usernameEntry.grid(row=0, column=1)

		submit = Button(self.root, text="Submit", command=lambda : self.submit(usernameEntry.get()))
		submit.pack(pady=15)

		self.root.mainloop()

	def submit(self, username):
		self.errorLabel.configure(text="")

		self.users.adduser(username)

		self.root.destroy()

		tkMessageBox.showinfo("SecureMe - User Created", "Successfully Created User: '" + username + "'!")




class DelUser():

	def __init__(self, username):
		print('do nothing')