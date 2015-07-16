# Peter Toth

import Tkinter
from Tkinter import Text

class CustomText(Text):

	def __init__(self, root, **kwargs):
		Text.__init__(self, root, **kwargs)

	def clear(self):
		self.delete("1.0", Tkinter.END)

	def resetText(self, text):
		self.clear()
		self.insert(Tkinter.END, text)

	def type(self, type=Tkinter.NORMAL):
		self.configure(state=type)