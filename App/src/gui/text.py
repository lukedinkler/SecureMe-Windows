# Peter Toth

import tkinter
from tkinter import Text

class CustomText(Text):

	def __init__(self, root, **kwargs):
		Text.__init__(self, root, **kwargs)

	def clear(self):
		self.delete("1.0", tkinter.END)

	def resetText(self, text):
		self.clear()
		self.insert(tkinter.END, text)

	def type(self, type=tkinter.NORMAL):
		self.configure(state=type)
