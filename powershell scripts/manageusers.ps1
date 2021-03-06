#region users
Write-Host "WARNING: This will ensure that all accounts are authorized!"
Start-Sleep -s 2
$uaccounts = get-wmiobject Win32_UserAccount -filter 'LocalAccount=TRUE' | select-object -expandproperty Name
foreach ($i in $uaccounts) {
$name =Read-Host "Is '$i' a authorized user? Yes or No"  
If ($name -eq 'no') {
(net user $i /del)
(Get-WmiObject -Class Win32_UserProfile | where {$_.LocalPath -like "*$i"} | Remove-WmiObject)
}
If ($name -eq'yes') {
(Write-Host "good to go")
}
}
cls
Write-Host "All user have been managed"
Start-Sleep -s 5
#endregion users
cls
#region admins
Write-Host "WARNING: This will ensure all ADMIN accounts are authorized, but this IS NOT PERFECT so make sure to double check the users!"
Start-Sleep -s 2
$members = net localgroup administrators | where {$_ -AND $_ -notmatch "command completed successfully"} | select -skip 4
foreach ($i in $members) {
$name =Read-Host "Is '$i' a authorized Admin? Yes or No"  
If ($name -eq 'no') {
(net localgroup administrators $i /del)
}
If ($name -eq'yes') {
(Write-Host "good to go")
}
}
cls
Write-Host "All Admin users have been checked"
Start-Sleep -s 5
#endregion admins
cls
#region enable
Write-Host "WARNING: This will ensure all authorized accounts are enabled!"
Start-Sleep -s 2
$accounts = get-wmiobject Win32_UserAccount -filter 'Disabled=TRUE or Lockout=TRUE' | select-object -expandproperty Name
foreach ($i in $accounts) {
$name =Read-Host "User account '$i' is lockedout or disabled. Do you want to Enable? Yes or No"  
If ($name -eq 'no') {
(Write-Host "User'$i' will not be enabled.")
}
If ($name -eq'yes') {
(net user $i /active:yes)
}
}
cls
Write-Host "All locked or disabled users have been managed"
Start-Sleep -s 5
#endregion enable
cls
#region password
Write-Host "WARNING: This is a quick & easy way to ensure all accounts are password protected, but this SHOULD NEVER BE DONE ON A PRODUCTION MACHINE!"
Start-Sleep -s 2
$password = Read-Host 'Enter a new password for all your accounts'
$accounts = get-wmiobject Win32_UserAccount -filter 'LocalAccount=TRUE' | select-object -expandproperty Name
foreach ($i in $accounts) { net user $i $password }
cls
Write-Host All user account passwords set to $password
Start-Sleep -s 5
#endregion password
cls
#region password policies
Write-Host "Setting Password policies"
Start-Sleep -s 2
net accounts /MINPWLEN:8 /MAXPWAGE:30 /MINPWAGE:10 /UNIQUEPW:5 
net accounts /lockoutthreshold:3
Write-Host "Password Policies Set!"
Start-Sleep -s 5
#endregion password policies
cls
#region Guest account
Write-Host "Disabling Guest and ADMIN accounts"
Start-Sleep -s 2
net user guest /active:no
net user Administrator /active:no
write-host Accounts Disabled
Start-Sleep -s 5
#endregion Guest account