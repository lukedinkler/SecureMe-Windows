Title  Windows PowerShell Security Script
color 8A
@echo off

:StartupScreen
echo ####################################################
echo #        PowerShell Basic Security Script          #
echo #                 Version 2.1                      #
echo #                                                  #      
echo #                                                  #
echo #            ~Coded by SecurityGhost~              #
echo ####################################################
timeout /t 3 > NUL
 
cls

net sessions >NUL
if %errorlevel%==0 (
goto :Home
) else (
echo You need to run this script as a Administrator!
pause
exit
)

cls

:Home
echo  There are curenly 5 sections of this script:
echo -----------------------------------------------------
echo 1 - Information Gathering
echo 2 - User Management
echo 3 - Security Configureations
echo 4 - Service Management 
echo 5 - System Patching 
echo -----------------------------------------------------
echo.
echo 6 - Reboot
echo 7 - Exit 
echo.  
set /p Choice=Type choice:
if "%Choice%"=="1" goto Info
if "%Choice%"=="2" goto Users
if "%Choice%"=="3" goto Security
if "%Choice%"=="4" goto Service
if "%Choice%"=="5" goto Update
if "%Choice%"=="6" goto Reboot
if "%Choice%"=="7" exit
goto Home


:Info
cls
echo launching Information Gathering section....
timeout /t 2
PowerShell -NoProfile -Command "& {Start-Process -Wait PowerShell.exe -ArgumentList '-NoProfile -ExecutionPolicy Bypass -File ""%~dp0\reports.ps1""' -Verb RunAs}"
cls
goto Home

:Users
cls
echo launching User Management section....
timeout /t 2
PowerShell -NoProfile -Command "& {Start-Process -Wait PowerShell.exe -ArgumentList '-NoProfile -ExecutionPolicy Bypass -File ""%~dp0\manageusers.ps1""' -Verb RunAs}"
cls
goto Home

:Security
cls
echo launching Security Polices section....
timeout /t 2
PowerShell -NoProfile -Command "& {Start-Process -Wait PowerShell.exe -ArgumentList '-NoProfile -ExecutionPolicy Bypass -File ""%~dp0\security.ps1""' -Verb RunAs}"
cls
goto Home

:Service
cls
echo launching Services section....
timeout /t 2
PowerShell -NoProfile -Command "& {Start-Process -Wait PowerShell.exe -ArgumentList '-NoProfile -ExecutionPolicy Bypass -File ""%~dp0\services.ps1""' -Verb RunAs}"
cls
goto Home

:Update
cls
echo launching Update section....
timeout /t 2
PowerShell -NoProfile -Command "& {Start-Process PowerShell.exe -ArgumentList '-NoProfile -ExecutionPolicy Bypass -File ""%~dp0\Updates.ps1""' -Verb RunAs}"
cls
goto Home

:Reboot
cls
Color 0C 
echo Reboot in 5
timeout /t 1 > NUL
echo 4
timeout /t 1 > NUL
echo 3
timeout /t 1 > NUL
echo 2
timeout /t 1 > NUL
echo 1! Rebooting Now...
timeout /t 1 > NUL
shutdown /r /f /t 00
