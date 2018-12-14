$platyPSInstalled = Get-Module -ListAvailable -Name platyPS;
$modulePath = ".\bin\Debug\net451\InjectionApi.dll"
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
Update-MarkdownHelp .\Docs\;

Write-Host "Updating help info .xml..."
New-ExternalHelp .\Docs -OutputPath en-US\ -Force;