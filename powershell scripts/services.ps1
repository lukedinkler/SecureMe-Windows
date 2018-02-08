write-host "vulnerable services!"
Start-Sleep -s 3
cls
$MyDir = [System.IO.Path]::GetDirectoryName($myInvocation.MyCommand.Definition)
Get-Content "$MyDir\Tools\services.txt" | Foreach-Object {
Get-Content "$MyDir\Tools\servicenames.txt"
$quest= Read-Host "Do you want to stop and disable '$_'? yes/no"  
If ($quest -eq 'yes') {
Stop-Service $_ -Force
Set-Service $_ -StartupType disabled
write-host "Done! '$_' disabled!"
Start-Sleep -s 3
cls
}
If ($quest -eq 'no') {
Write-Host "'$_' will not be disabled"
Start-Sleep -s 3
cls
}
}
Write-Host "All valnerable services managed!"
Start-Sleep -s 5