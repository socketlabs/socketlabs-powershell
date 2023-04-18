---
external help file: SocketLabs.PowerShell.InjectionApi.dll-Help.xml
Module Name: SocketLabs
online version: https://github.com/socketlabs/socketlabs-powershell/blob/main/README.md
schema: 2.0.0
---

# Out-SocketLabs

## SYNOPSIS
The SocketLabs Out-SocketLabs cmdlet lets you send messages through our platform using our email injection API.

## SYNTAX

```
Out-SocketLabs [-Sender] <String> [-Recipients] <String[]> [-Subject] <String> [[-InjectionApiKey] <String>]
 [[-ServerId] <Int32>] [-PassThru] [-UseCXEndpoint] [-ApiEndpoint <String>] [-Unformatted]
 [-InputObject <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Use the `Out-SocketLabs` cmdlet to send pipeline output to the specified recipients.

## EXAMPLES

### Example 1
```powershell
PS C:\> "Hello SocketLabs!" | Out-SocketLabs -Subject "Hi this is a test!" -Sender "me@example.com" -Recipients "you@example.com"
```

Send a basic message through the InjectionApi.

### Example 2
```powershell
PS C:\> Get-Process | Out-SocketLabs -Sender "sysadm@example.com" -Recipients "infra@example.com", "logs@example.com" -Subject "Here is the list of running processes."
```

Output a list of processess to multiple email recipient.

### Example 3
```powershell
PS C:\> '<h1 style="background-color: #FFCDD2;">New Alert</h1><p>Something bad happened</p>' | Out-SocketLabs -Sender "no-reply@example.com" -Recipients "angie@example.com" -Subject "Houston, we have a problem" -Unformatted
```

Send HTML content without using the default powershell formatting.

## PARAMETERS

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InjectionApiKey
Your API Key for your SocketLabs server

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The object to pass in for sending through the InjectionApi

```yaml
Type: PSObject
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Pass the object through the pipeline

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Recipients
A list of email addresses to send the message to

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: To

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sender
The from address of the email message

```yaml
Type: String
Parameter Sets: (All)
Aliases: From

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerId
The ServerId value for your SocketLabs server.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Subject
The subject of your message

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApiEndpoint
Specify an alternative API Endpoint.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Unformatted
Do not apply the default PowerShell formatting and colors.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseCXEndpoint
Use the complex sender endpoint.  Setting this flag ignores any values used in the `-ApiEndpoint` parameter.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Management.Automation.PSObject
## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[https://github.com/socketlabs/socketlabs-powershell/blob/main/README.md](https://github.com/socketlabs/socketlabs-powershell/blob/main/README.md) 

[Obtaining your API Key and SocketLabs ServerId number](https://github.com/socketlabs/socketlabs-powershell/blob/main/README.md#obtaining-your-api-key-and-socketlabs-serverid-number) 

[Developer Documentation](https://www.socketlabs.com/developers)