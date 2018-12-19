$platyPSInstalled = Get-Module -ListAvailable -Name platyPS;
$modulePath = ".\src\SocketLabs\SocketLabsModule\bin\Debug\net451\SocketLabs.psd1"
$buildCompleted = Test-Path $modulePath;

if (!$buildCompleted) {
    Write-Error "Could not find module assembly. Please build the project and run script again.";
    exit;
}

if (!$platyPSInstalled) {
    Write-Host "platyPS module not detected.  Installing now...";
    Install-Module platyPS -Confirm:$false -Force;
}

Import-Module platyPS;
Import-Module $modulePath;

Write-Host "Updating markdown docs..."
Update-MarkdownHelp .\docs\;

Write-Host "Updating help info .xml..."
New-ExternalHelp .\docs -OutputPath .\src\SocketLabs\SocketLabsModule\en-US\ -Force;