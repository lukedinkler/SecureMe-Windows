# Made by Luke Dinkler and Peter Toth

import Tkinter
from Tkinter import *
import sys

class RootPasswordWindow():

	def __init__(self, enc):
		self.enc = enc
		self.build()

	def build(self):
		self.root = Tk()
		self.root.geometry("300x150+350+350")
		self.root.title("SecureMe - Root Password")

		l = Label(self.root, text="This program requires a root password:")
		l.pack()

		self.e = Entry(self.root, show="*")
		self.e.bind("<Return>", lambda x: self.submit())
		self.e.pack(padx=10, pady=10)

		f = Frame(self.root)
		submit = Button(f, text="Submit!", padx=10, pady=10, command=self.submit)
		submit.pack(side=RIGHT)
		cancel = Button(f, text="Cancel", padx=10, pady=10, command=self.cancel)
		cancel.pack(side=LEFT)
		f.pack()

		self.root.mainloop()

	def submit(self):
		pswd = self.e.get()
		self.enc.encrypt(pswd)
		print('Password Set')
		self.root.destroy()

	def cancel(self):
		print("FATAL: No Root Password! Exiting...")
		sys.exit(1)