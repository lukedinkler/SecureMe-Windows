   M S B A M L   `   `   `  ���� C  ?SecureMe, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SecureMeSecureMe      SecureMe.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:SecureMe     -     �Name$  SecureMeWindow�� � Title$ SecureMe��$��763.345��$��1048.622�� � 
ResizeMode$ CanMinimize=� � WindowStartupLocation$ CenterScreen=� � Icon$  Images/SecureMeIcon-D1.ico��.��� .+��� -    ��Name$ MenuTabControl��$
��Left=�$	��634��$��	0,101,0,0q�$	��Top=�$
��1043��.@��� -    ��Name$ MainTab��$
��Main��$��
-1,2,-1,-1q�.��� ���	#FFE5E5E5 � ColumnDefinitions �� $	��22* ��� $
��995* �.+��� -    ��Name$ WelcomeLabel��$��Center=�$D��>Welcome to SecureMe! Please select a security option to begin:��$
��Left=�$��0,66,0,0q�$	��Top=�$��26.667(�$��Liberation Serif)�$
��1006��$��2���� -   	 ��Name$	 FullSecureButton��$��1��$
��Left=�$	��176��$��
89,236,0,0q�$	��Top=�$	��175��$��Images/Full-Secure-D1.png��
 � Cursor$

 Hand���� -   $	 BasicSecureButton��$��1��$
��Left=�$	��167��$��412,245,0,0q�$	��Top=�$	��158��$ ��Images/Basic-Secure-D1.png��$

 Hand���� -   $	 ManualSelectButton��$��1��$
��Left=�$	��151��$��736,261,0,0q�$	��Top=�$	��154��$ ��Images/ManualSelect-D1.png��$

 Hand���� -   $ FullSecureLabel��$��Full Secure��$��1��$
��Left=�$��117,417,0,0q�$	��Top=�$��24(��� -	   $ BasicSecureLabel��$��Center=�$��Basic Secure��$��1��$
��Left=�$��412,417,0,0q�$	��Top=�$��24(�$	��158���� -
   $ MaualSelectLabel��$��Manual Secure��$��1��$
��Left=�$��736,417,0,0q�$	��Top=�$��24(��� -   $ HeyYouLabel��$��Center=�$��Hey, Dominic!��$
��Left=�$��0,23,0,0q�$	��Top=�$��26.667(�$
��1006��$��2��$��Source Sans Pro)�$��Italic$��� $��Users��$��	-2,2,0,-1q�.��� ���	#FFE5E5E5.+��� -    ��Name$ UsersBox��$��198,57,202,131q� J� Opacity$
 0.74Q�
���   ����	#FFFBFBFB�� -   $ 
UsersLabel��$��Users:��$��466,10,467,0q�$	��Top=�$��24(�$��Segoe UI Semilight)��� -   $ SelectedUserLabel��$��Selected User: ��$
��Left=�$��215,515,0,0q�$	��Top=�$��16(��� -   $	 
AddUserBtn��$
��Left=�$��68��$��491,478,0,0q�$	��Top=�$��72��$��Images/Add-Icon-D1.png��$

 Hand���� -   $	 RemoveUserBtn��$
��Left=�$��68��$��587,479,0,0q�$	��Top=�$��72��$��Images/Remove-Icon-D1.png��$

 Hand���� -   $ AddUserLabel��$	��Add��$
��Left=�$��506,555,0,0q�$	��Top=�$��16(��� -   $ DeleteUserLabel��$��Center=�$��Delete��$
��Left=�$��584,555,0,0q�$	��Top=�$��16(�$��72���� -   $	 ChangePasswordBtn��$
��Left=�$��72��$��712,478,0,0q�$	��Top=�$��73��$#��Images/ChangePasword-Icon.png��$

 Hand���� -   $ ChangePasswdLabel��$��Change Password:��$
��Left=�$��683,555,0,0q�$	��Top=�$��16(��� -   $ Services��$��Services��$��	-1,2,3,-1q�.��� ���	#FFE5E5E5.+��� -   $ label��$��	Services:��$��452,10,450,0q�$	��Top=� J� RenderTransformOrigin$ 1.237,0.769&�$��24(��� -   $ ServicesBox��$
��Left=�$	��369��$��	10,69,0,0q�$	��Top=�$	��992��$ 0.805Q�
���   ����	#FFFFFEFE�� -   $ ServiceStatusLabel��$��Status: ��$
��Left=�$��
19,440,0,0q�$	��Top=�$��16(�$	��248���� -   $	 StartServiceBtn��$
��Left=�$��91��$��302,459,0,0q�$	��Top=�$��93��$��Images/Start-Icon-D1.png��$

 Hand���� -   $	 StopServiceBtn��$
��Left=�$��91��$��452,461,0,0q�$	��Top=�$	��100��$��Images/Stop-Icon-D1.png��$

 Hand���� -   $	 DisableServiceBtn��$
��Left=�$��91��$��592,463,0,0q�$	��Top=�$	��100��$ ��Images/Disable-Icon-D1.png��$

 Hand���� -   $ StartServiceLabel��$��Start��$
��Left=�$��323,552,0,0q�$	��Top=�$ 0.921,0.615&�$��18.667(��� -   $ StopServiceLabel��$
��Stop��$
��Left=�$��473,553,0,0q�$	��Top=�$��18.667(��� -   $ DisableServiceLabel��$��Disable��$
��Left=�$��608,557,0,0q�$	��Top=�$��16(�$ 0.839,0.516&��� -   $	 EnableServiceBtn��$
��Left=�$	��105��$��739,453,0,0q�$	��Top=�$	��105��$��Images/Enable-Icon-D1.png��$ 
0.69,0.672&�$

 Hand���� -    $ EnableServiceLabel��$��Enable w/ Startup Mode��$
��Left=�$��703,557,0,0q�$	��Top=�$��16(��� -!    ��Name$ ServiceStartupModeBox��$
��Left=�$��876,491,0,0q�$	��Top=�$	��120���� -"   $ ServiceStartupModeLabel��$��Startup Mode:��$
��Left=�$��891,458,0,0q�$	��Top=��� -#   $ SvcDescLabel��$
��Left=�$��112,469,0,0q�$	��Top=�$��27��$��73��$ 0.5,0.5&�$��Description:���� -$    ��Name$ SvcDescriptionBox��$��Visible=� �� 
IsReadOnly . $
��Left=�$��95��$��
10,496,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��274�� �� 	IsEnabled . �� -%   $ About��$��About��$��328,2,-335,0q�$ 
3.14,0.571&�.��� ���	#FFE5E5E5$��0,-1,0,1q� �� $
��116* ��� $
��901* �.+��� -&   $ AboutMainLabel��$��	SecureMe:��$
��Left=�$��130,181,0,0q�$	��Top=�$��26.667(�$	��143��$��1���� -'   $ AboutVerLabel��$��Version 1.2��$
��Left=�$��130,238,0,0q�$	��Top=�$	��150��$��16(�$��Italic$�$��1���� -(   $	 image��$��1��$
��Left=�$	��269��$��389,117,0,0q�$	��Top=�$	��273��$ ��Images/SecureMeLogo-D1.png���� -)   $ AboutCreditLabel��$��Developed by Luke Dinkler��$��130,316,557,0q�$	��Top=�$��16(�$��1���� -*   $ AboutYearLabel��$�� ��$
��Left=�$��100,231,0,0q�$	��Top=�$��2��$��21.333(��� -+    ��Name$ AboutRectangle��$��1��$
��Left=�$	��354��$��	89,85,0,0q����	#FF2D9CEA$��4��$	��Top=�$	��598�� �� RadiusX$
 13.5�� �� RadiusY$
 13.5������ �� -,   $ 	Processes��$��	Processes��$��-48,0,35,-1q�$ 0.896,0.682&�$��25��$��Bottom=�.��� ���	#FFE5E5E5$��0,0,-4,0q� �� $
��169* ��� $
��848* �.+��� --   $ ProcessesLabel��$��Center=�$��
Processes:��$
��Left=�$��
190,10,0,0q�$	��Top=�$��24(�$	��383��$��1���� -.   $ 
ProcessBox��$
��Left=�$	��365��$��	10,67,0,0q�$	��Top=�$	��992��$��2��
���   �
�������$ 0.785Q��� -/   $	 RefreshProcessBtn��$��1��$
��Left=�$	��103��$��632,446,0,0q�$	��Top=�$	��104��$ ��Images/Refresh-Icon-D1.png��$ 3.365,0.563&�$

 Hand���� -0   $	 KillProcessBtn��$��1��$
��Left=�$	��112��$��411,437,0,0q�$	��Top=�$	��122��$��Images/Kill-Icon-D1.png��$

 Hand���� -1   $ KillProcessLabel��$��Kill Process��$��1��$
��Left=�$��423,555,0,0q�$	��Top=�$��16(��� -2   $ RefreshProcessLabel��$��Refresh Processes��$��1��$
��Left=�$��615,554,0,0q�$	��Top=�$��16(��� -3   $ PIDLabel��$��PID: ��$
��Left=�$��
10,518,0,0q�$	��Top=�$��16(��� -4    ��Name$ ProcessFileLabel��$
��Left=�$��
10,446,0,0q�$
��Wrap=�$��File:��$	��Top=�$��16(�$ 0.822,0.517&�$��2��$	��547��$��72���� -5   $	 image1��$��1��$
��Left=�$��62��$��	615,0,0,0q�$	��Top=�$��67��$��Images/Process-Icon.png���� -6   $ SysInfo��$��System Info��$��-36,2,31,-1q�.��� ���	#FFE5E5E5.+��� -7   $ OSLabel��$	��OS:��$
��Left=�$��	29,63,0,0q�$	��Top=�$��21.333(�$	��397���� -8   $	 OSPic��$
��Left=�$	��226��$��
574,39,0,0q�$	��Top=�$	��354��$��Images/Win8.jpg���� -9   $ CPULabel��$��CPU: AMD FX 8510 8-Core��$
��Left=�$��
29,133,0,0q�$	��Top=�$ 0.237,0.615&�$��18.667(��� -:   $ RAMLabel��$��RAM: 4060 MB��$
��Left=�$��
29,256,0,0q�$	��Top=�$��18.667(��� -;   $ 	ArchLabel��$��Architecture:��$
��Left=�$��
29,196,0,0q�$	��Top=�$��18.667(�$	��228���� -<   $ Settings��$��Settings��$��91,2,-92,-1q�.��� ���	#FFE5E5E5 �� $
��221* ��� $
��785* �.+��� -=   $ MainSettingsLabel��$��Center=�$��	Settings:��$
��Left=�$��0,30,0,0q�$	��Top=�$��21.333(�$
��1006��$��2���� ->   $	 SettingsSaveBtn��$��1��$
��Left=�$	��147��$��202,439,0,0q�$	��Top=�$	��148��$��Images/Save-Icon-D1.png��$

 Hand���� -?   $ ServicesSettingLabel��$'��!Services Start/Stop/Disable Mode:��$
��Left=�$��	58,88,0,0q�$	��Top=�$��2��$	��289��$��18.667(�	� -@    	�Name$ ServicesSettingsSafeBtn��$��Center=�$��Standard (Safe)��$��1��$
��Left=�$��
168,97,0,0q�$	��Top=�$	��133��$��16(�	� -A   $ ServicesSettingAdminBtn��$��Center=�$��Admin��$��1��$
��Left=�$��
347,97,0,0q�$	��Top=�$��70��$��16(�$ 	0.243,0.9&��� -B   $ PortsTab��$��Ports��$
��Left=�$��24��$	��Top=�$��54��$��
-87,2,0,-1q�$ 0.509,0.653&�.��� ���	#FFE5E5E5.+��� -C   $ PortsBox��$
��Left=�$	��385��$��	10,83,0,0q�$	��Top=�$	��982��
���   �$	 0.8Q�
��������� -D   $	 
PortsImage��$
��Left=�$��78��$��	709,0,0,0q�$	��Top=�$	��107��$��Images/Ports-Icon.png���� -E   $ 
PortsLabel��$��Center=�$��Listening Ports:��$
��Left=�$��	25,10,0,0q�$	��Top=�$	��643��$��52��$��32(��� -F   $	 RefreshPortsBtn��$
��Left=�$��72��$��709,473,0,0q�$	��Top=�$��74��$ ��Images/Refresh-Icon-D1.png��$

 Hand���� -G   $ RefreshPortsLabel��$��Refresh��$
��Left=�$��702,538,0,0q�$	��Top=�$��23(��� -H   $ ProgramsTab��$��Packages��$
��Left=�$��24��$	��Top=�$��71��$��-121,2,0,-1q�.��� ���	#FFE5E5E5.+��� -I   $ ProgramsBox��$
��Left=�$	��363��$��	10,77,0,0q�$	��Top=�$	��993�����	#FF040000$	 0.8Q�
��������� -J   $	 UninstallBtn��$
��Left=�$��85��$��513,455,0,0q�$	��Top=�$��86��$��Images/Remove-Icon-D1.png��$

 Hand���� -K   $ UninstallLabel��$��	Uninstall��$
��Left=�$��513,540,0,0q�$	��Top=�$��32��$��86��$��20(��� -L   $	 OpenPathBtn��$
��Left=�$��85��$��660,455,0,0q�$	��Top=�$��85��$��Images/Folder-Icon.png��$

 Hand���� -M   $ StartProgramLabel��$��Open Directory��$
��Left=�$��628,539,0,0q�$	��Top=�$	��147��$��20(��� -N   $ ProgramVersionLabel��$��Version:��$
��Left=�$��
10,501,0,0q�$	��Top=�$	��454��$��16(��� -O   $ ProgramLocationText��$
��Left=�$��
14,535,0,0q�$
��Wrap=�$��	Location:��$	��Top=�$��45��$	��482��$��16(��� -P   $ PckgNameLabel��$
��Left=�$��
14,455,0,0q�$
��Wrap=�$��Name:��$	��Top=�$��41��$	��450��$��14(��� -Q   $	 PckgIcon��$
��Left=�$��72��$��	809,0,0,0q�$	��Top=�$��77��$��Images/Package-Icon.png���� -R   $ 	PckgLabel��$��Center=�$��Installed Packages:��$
��Left=�$��	266,8,0,0q�$	��Top=�$	��509��$��57��$��30(��� -S   $ 	MainLabel��$��Center=�$��	SecureMe:��$��0,31,0,0q�$	��Top=�$��26.667(�