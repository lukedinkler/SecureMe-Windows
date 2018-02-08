#region reset
Write-Host "Setting local secrity policies to defalt"
Start-Sleep -s 2
secedit /configure /cfg "$Env:WinDir\inf\defltbase.inf" /db defltbase.sdb /verbose
Write-Host "Good!"
Start-Sleep -s 5
#endregion reset
cls
#region UAC
Write-Host "Enabling UAC..."
Start-Sleep -s 2
Set-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System" -Name EnableLUA -Value 1 -Force
Write-Host "UAC Enabled!"
Start-Sleep -s 5
#endregion
cls
#region Regedit
Write-Host "Setting Security Policies..."
Set-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon" -Name AllocateCDRoms -Value 1 -Force
Set-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon" -Name AutoAdminLogon -Value 0 -Force
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management" -Name ClearPageFileAtShutdown -Value 1 -Force
Set-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon" -Name AllocateFloppies -Value 1 -Force
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\Control\Print\Providers\LanMan Print Services\Servers" -Name AddPrinterDrivers -Value 1 -Force 
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\Control\Lsa" -Name LimitBlankPasswordUse -Value 1 -Force 
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\Control\Lsa" -Name auditbaseobjects -Value 1 -Force 
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\Control\Lsa" -Name fullprivilegeauditing -Value 1 -Force 
Set-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System" -Name dontdisplaylastusername -Value 1 -Force 
Set-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System" -Name PromptOnSecureDesktop -Value 1 -Force 
Set-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System" -Name EnableInstallerDetection -Value 1 -Force 
Set-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System" -Name undockwithoutlogon -Value 0 -Force 
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\services\Netlogon\Parameters" -Name MaximumPasswordAge -Value 15 -Force 
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\services\Netlogon\Parameters" -Name DisablePasswordChange -Value 1 -Force 
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\services\Netlogon\Parameters" -Name RequireStrongKey -Value 1 -Force 
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\services\Netlogon\Parameters" -Name RequireSignOrSeal -Value 1 -Force 
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\services\Netlogon\Parameters" -Name SignSecureChannel -Value 1 -Force 
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\services\Netlogon\Parameters" -Name SealSecureChannel -Value 1 -Force 
Set-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System" -Name DisableCAD -Value 0 -Force  
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\Control\Lsa" -Name restrictanonymous -Value 1 -Force  
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\Control\Lsa" -Name restrictanonymoussam -Value 1 -Force  
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\services\LanmanServer\Parameters" -Name autodisconnect -Value 45 -Force
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\services\LanmanServer\Parameters" -Name enablesecuritysignature -Value 0 -Force  
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\services\LanmanServer\Parameters" -Name requiresecuritysignature -Value 0 -Force  
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\Control\Lsa" -Name disabledomaincreds -Value 1 -Force  
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\Control\Lsa" -Name everyoneincludesanonymous -Value 0 -Force  
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\services\LanmanWorkstation\Parameters" -Name EnablePlainTextPassword -Value 0 -Force 
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\services\LanmanServer\Parameters" -Name NullSessionPipes -Value "" -Force
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\Control\SecurePipeServers\winreg\AllowedExactPaths" -Name Machine -Value "" -Force
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\Control\SecurePipeServers\winreg\AllowedPaths" -Name Machine -Value "" -Force
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\services\LanmanServer\Parameters" -Name NullSessionShares -Value "" -Force
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\Control\Lsa" -Name UseMachineId -Value 0 -Force 
Set-ItemProperty -Path "HKLM:\Software\Microsoft\Internet Explorer\PhishingFilter" -Name EnabledV8 -Value 1 -Force 
Set-ItemProperty -Path "HKLM:\Software\Microsoft\Internet Explorer\PhishingFilter" -Name EnabledV9 -Value 1 -Force 
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\Control\CrashControl" -Name CrashDumpEnabled -Value 0 -Force 
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\Services\CDROM" -Name AutoRun -Value 1 -Force 
Set-ItemProperty -Path "HKLM:\Software\Microsoft\Windows\CurrentVersion\Internet Settings" -Name DisablePasswordCaching -Value 1 -Force  
Set-ItemProperty -Path "HKLM:\Software\Microsoft\Internet Explorer\Main" -Name DoNotTrack -Value 1 -Force 
Set-ItemProperty -Path "HKLM:\Software\Microsoft\Internet Explorer\Download" -Name RunInvalidSignatures -Value 1 -Force 
Set-ItemProperty -Path "HKLM:\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_LOCALMACHINE_LOCKDOWN\Settings" -Name LOCALMACHINE_CD_UNLOCK -Value 1 -Force 
Set-ItemProperty -Path "HKLM:\Software\Microsoft\Windows\CurrentVersion\Internet Settings" -Name WarnonBadCertRecving -Value 1 -Force 
Set-ItemProperty -Path "HKLM:\Software\Microsoft\Windows\CurrentVersion\Internet Settings" -Name WarnOnPostRedirect -Value 1 -Force 
Set-ItemProperty -Path "HKLM:\Software\Microsoft\Windows\CurrentVersion\Internet Settings" -Name WarnonZoneCrossing -Value 1 -Force 
Write-Host "Security Policies Set!"
#endregion
cls
#region Updates
Write-Host "Setting up automatic updates..."
Start-Sleep -s 2
Set-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Auto Update" -Name AUOptions -Value 4 -Force
Write-Host "Automatic updates ready!"
Start-Sleep -s 5
#endregion
cls
#region Autoplay
Write-Host "disabling Autoplay and Autorun"
Start-Sleep -s 2
Set-ItemProperty -Path "HKLM:\Software\Microsoft\Windows\CurrentVersion\Explorer\AutoplayHandlers" -Name DisableAutoplay -Value 1 -Force
Set-ItemProperty -Path "HKLM:\Software\Microsoft\Windows\CurrentVersion\Explorer" -Name NoDriveTypeAutoRun -Value 255 -Force
Write-Host "Autoplay disabled!"
Start-Sleep -s 5
#endregion
cls
#region hidenfiles
Write-Host "Making windows explorer show hiden files!"
Start-Sleep -s 2
Set-ItemProperty -Path "HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name Hidden -Value 1 -Force
Set-ItemProperty -Path "HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name HideFileExt -Value 0 -Force
Set-ItemProperty -Path "HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name HideDrivesWithNoMedia -Value 0 -Force
Set-ItemProperty -Path "HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name ShowSuperHidden -Value 1 -Force
Write-Host "Done!"
Start-Sleep -s 5
#endregion
cls
#region auditing
write-host "Enabling full system auditing ..."
Start-Sleep -s 2
auditpol /set /category:* /success:enable 
auditpol /set /category:* /failure:enable
Write-Host "auditing set!"
Start-Sleep -s 5
#endregion auditing
cls
# region firewall
write-host Enabling Firewall...
Start-Sleep -s 2
netsh advfirewall set allprofiles state on
netsh advfirewall reset
netsh advfirewall set allprofiles state on
write-host Firewall enabled!
Start-Sleep -s 5
# endregion firewall