# socketlabs-powershell
### [![SocketLabs](https://www.socketlabs.com/assets/logo-dark-sm.png)](https://www.socketlabs.com) 
[![Twitter Follow](https://img.shields.io/twitter/follow/socketlabs.svg?style=social&label=Follow)](https://twitter.com/socketlabs) [![MIT licensed](https://img.shields.io/badge/license-MIT-blue.svg)](./LICENSE) [![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg)](https://github.com/socketlabs/socketlabs-csharp/blob/master/CONTRIBUTING.md)
<!--
[![GitHub contributors](https://img.shields.io/github/contributors/socketlabs/csharp-socketlabs.svg)](https://github.com/socketlabs/csharp-socketlabs/graphs/contributors)
-->

The SocketLabs InjectionApi PowerShell module allows you to easily pipe PowerShell command outputs using the [SocketLabs Injection API](https://www.socketlabs.com/api-reference/injection-api/).  

# Table of Contents
* [Prerequisites and Installation](#prerequisites-and-installation)
* [Getting Started](#getting-started)
* [Managing API Keys](#managing-api-keys)
* [Examples and Use Cases](#examples-and-use-cases)
* [License](#license)

# Prerequisites and Installation
## Prerequisites
* A supported .NET version
  * PowerShell 3.0 or PowerShell Core 6.1.0 or higher. 
  * .NET version 4.5 or higher
  * .NET Core 2.0 or higher
  * .NET Standard 2.0 or higher
* A SocketLabs account. If you don't have one yet, you can 
[sign up for a free account](https://signup.socketlabs.com/step-1?plan=free) 
to get started.

## Installation
For most uses we recommend installing the SocketLabs InjectionApi Module via the 
[PowerShell Gallery](https://www.powershellgallery.com/packages/SocketLabsInjectionApi). 
You can install the latest version of the module with the following command:

```powershell
PS> Install-Module -Name SocketLabsInjectionApi -Force
```

Alternately, you can simply [clone this repository](https://github.com/socketlabs/socketlabs-powershell.git) 
directly to include the source code in your project.

# Getting Started
## Obtaining your API Key and SocketLabs ServerId number
In order to get started, you'll need to enable the Injection API feature in the 
[SocketLabs Control Panel](https://cp.socketlabs.com). Once logged in, navigate 
to your SocketLabs server's dashboard (if you only have one server on your account
you'll be taken here immediately after logging in). Make note of your 4 or 5 digit
ServerId number, as you'll need this along with your API key in order to use the 
Injection API. 

To enable the Injection API, click on the "For Developers" dropdown on the 
top-level navigation, then choose the "Configure HTTP Injection API" option. 
Once here, you can enable the feature by choosing the "Enabled" option in the
dropdown. Enabling the feature will also generate your API key, which you'll 
need (along with your ServerId) to start using the API. Be sure to click the 
"Update" button to save your changes once you are finished.


## Managing API Keys
For ease of demonstration, many of our examples include the ServerId and API 
key directly in our code sample. Generally it is not considered a good practice 
to store sensitive information like this directly in your code. Depending on 
your project type, we recommend either storing your credentials in an `app.config`
or a `web.config` file, or using Environment Variables. For more information please see: 

* [Using web.config](https://docs.microsoft.com/en-us/aspnet/identity/overview/features-api/best-practices-for-deploying-passwords-and-other-sensitive-data-to-aspnet-and-azure)
* [Using Environment Variables](https://docs.microsoft.com/en-us/dotnet/api/system.environment.getenvironmentvariable)

## Usage

We recommend storing your API Key and ServerId as environment variables.

```powershell
PS C:\> $target = [System.EnvironmentVariableTarget]::User
PS C:\> $apiKey = "XXXXX123456ABCDE"
PS C:\> $serverId = "1000"
PS C:\> [System.Environment]::SetEnvironmentVariable("SL_API_KEY", $apiKey, $target)
PS C:\> [System.Environment]::SetEnvironmentVariable("SL_SERVERID", $serverId, $target)
```

### Examples

#### Output a list of processess to an email recipient.
```powershell

PS C:\> Get-Process | Out-SocketLabs -Sender "sysadm@example.com" -Recipients "infra@example.com", "logs@example.com" -Subject "Here is the list of running processes."
```

#### Get IP Address information from the current host
```powershell
PS C:\> $request = Invoke-WebRequest -Uri "https://ifconfig.co/json" -UseBasicParsing
PS C:\> $request.Content | ConvertFrom-Json | Format-Table ip, country*, hostname | 
>> Out-SocketLabs -Sender "sysadm@example.com" `
>> -Recipients "infra@example.com", "logs@example.com" `
>> -Subject "Here is the list of running processes."
```



# License
The SocketLabs InjectionApi PowerShell module and all associated code, including any code 
samples, are [MIT Licensed](https://github.com/socketlabs/socketlabs-csharp/blob/master/LICENSE.MD).