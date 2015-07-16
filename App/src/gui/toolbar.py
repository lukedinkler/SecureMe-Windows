# Made by Luke Dinkler and Peter Toth

import sys, tkinter
from tkinter import *

class ToolBar():

        def __init__(self, root, gui):
                self.frame = Frame(root, borderwidth=2, relief='raised')
                self.root = root
                self.gui = gui
                self.frame.configure(bg='gray65')
                self.create()
                self.frame.pack(side=TOP, fill=X)

        def create(self):
                refreshButton = Button(self.frame, text="Refresh", command=lambda : self.gui.refresh("Button Pressed"), relief=GROOVE)
                refreshButton.pack(side=LEFT, padx=2, pady=2, fill=X)
                exitButton = Button(self.frame, text="Exit", command=lambda : self.gui.quitMenu(), relief=GROOVE)
                exitButton.pack(side=LEFT, padx=2, pady=2, fill=X)
