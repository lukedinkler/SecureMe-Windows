write-host "Getting info!"
Start-Sleep -s 2
mkdir "$env:USERPROFILE\Desktop\reports"
$basedpath="$env:USERPROFILE\Desktop\reports"
net start |Out-File "$basedpath\services.txt"
tasklist /svc |Out-File "$basedpath\processes.txt"
netstat /a /b |Out-File "$basedpath\netstat.txt"
driverquery |Out-File "$basedpath\driverinfo.txt"
cls
write-host "Info sent to folder on $env:USERNAME's Desktop!"
Start-Sleep -s 5

cls
Write-Host "Getting user info!"
Start-Sleep -s 2
Write-output "All user Accounts:" >> "$basedpath\usersreport.txt"
get-wmiobject Win32_UserAccount -filter 'LocalAccount=TRUE' | select-object -expandproperty Name|Out-File -Append "$basedpath\usersreport.txt"
Write-output "" >> "$basedpath\usersreport.txt"
Write-output "Admin Accounts:" >> "$basedpath\usersreport.txt"
net localgroup administrators | where {$_ -AND $_ -notmatch "command completed successfully"} | select -skip 4|Out-File -Append "$basedpath\usersreport.txt"
Write-output "" >> "$basedpath\usersreport.txt"
Write-output "Disabled Accounts:" >> "$basedpath\usersreport.txt"
get-wmiobject Win32_UserAccount -filter 'Disabled=TRUE or Lockout=TRUE' | select-object -expandproperty Name|Out-File -Append "$basedpath\usersreport.txt"
Write-Host "Done!"
timeout /t 5

cls

write-host "Searching for Media Files..."
Start-Sleep -s 2
$Include = @('*.mp3','*.mp4','*.m4a','*.jpg','*.jpeg','*.wav','*.ogg','*.wma','*.mov','*.mp4v','*.mpeg4','*.gif','*.png')
$exclude = [RegEx]'^C:\\Windows|^C:\\Program Files'
Get-ChildItem "C:\" -Directory |
  Where FullName -notmatch $exclude|ForEach {
  Get-ChildItem -Path $_.FullName -Include $Include -Recurse| 
  Select-Object -ExpandProperty FullName |Out-File "$basedpath\media.txt"
}

cls
start -Wait C:\WINDOWS\system32\notepad.exe "$basedpath\media.txt"
write-host "Media sent to folder on $env:USERNAME's Desktop!"
timeout /t 5