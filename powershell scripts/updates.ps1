# install Chocolate package manager 
iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))

cls

# install choco packages
do {
    do {
        write-host "[Install Software] --------------------------------------"
        write-host "1 - Avg"
        write-host "2 - MalwareBytes"
        write-host "3 - CLAMWIN"
        write-host "4 - Microsoft Baseline Security Analyzer"
        write-host "5 - Revo Uninstaller"
        write-host ""
        write-host "6 - Install All"
        write-host "7 - Exit"
        write-host "----------------------------------------------------------"
        write-host -nonewline "Type your choice and press Enter: "
        
        $choice = read-host
        
        write-host ""
        
        $ok = $choice -match '^[1234567]+$'
        
        if ( -not $ok) { write-host "Invalid selection" }
    } until ( $ok )
    
    switch -Regex ( $choice ) {
        "1"
        {
            choco install avgantivirusfree -y
        }
        
        "2"
        {
            choco install malwarebytes -y
        }

        "3"
        {
            choco install clamwin -y
        }

        "4"
        {
            choco install mbsa -y
        }
        "5"
        {
            choco install revo.uninstaller -y
        }
        "6"
        {
            choco install avgantivirusfree malwarebytes mbsa revo.uninstaller -y
        }
    }
} until ( $choice -match "7" )

cls

write-host "Starting Windows Updates....."
timeout /t 2
# get path
$MyDir = [System.IO.Path]::GetDirectoryName($myInvocation.MyCommand.Definition)
# copy ps module
copy-item -Path "$MyDir\Tools\PSWindowsUpdate" -Destination "$env:USERPROFILE\Documents\WindowsPowerShell\Modules" -Force
copy-item -Path "$MyDir\Tools\PSWindowsUpdate" -Destination "$Env:WinDir\System32\WindowsPowerShell\v1.0\Modules" -Force
# set ExecutionPolicy
Set-ExecutionPolicy Unrestricted
# import module
Import-Module PSWindowsUpdate
# add "othe products" to updates
Add-WUServiceManager -ServiceID "7971f918-a847-4430-9279-4a52d1efe18d"
# launch updates
Get-WUInstall –MicrosoftUpdate -WithHidden -AcceptAll
