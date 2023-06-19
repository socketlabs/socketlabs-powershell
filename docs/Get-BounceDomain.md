---
external help file: SocketLabs.PowerShell.ManagementApi.dll-Help.xml
Module Name: SocketLabs
online version: https://github.com/socketlabs/socketlabs-powershell/blob/main/README.md
schema: 2.0.0
---

# Get-BounceDomain

## SYNOPSIS
The Bounce Domains endpoint allows you to get a list of Bounce Domains for your server, add new domains, update an existing domain, or delete a domain.

## SYNTAX

```
Get-BounceDomain [-ServerId] <Int32> [[-Domain] <String>] [[-ApiKey] <String>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Get All Bounce Domains for Server

## EXAMPLES

### Example 1
```powershell
PS C:\>  Get-BounceDomain -ServerId 12345 -ApiKey xxxxxxxxxxxxxxxxxx.xxxxxxxxxxxxxxxxxxxxxxx
```

Get all bounce domains for the server 12345 using the specified API Key

## PARAMETERS

### -ApiKey
Your SocketLabs API key.  You can also specify your API key by setting the environment variable `SL_MGMT_API`. 
If you specify this parameter it will override the environment variable.

_Note:_
In order to get started with the SocketLabs API you'll first need to create an API key. This can be done on the API Key Management page in the SocketLabs Performance Dashboard.

It is important to keep your API key secure because it can be used to modify features for your SocketLabs account.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 10
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Domain
The domain to retrieve the bounce domain configuration for.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerId
The Server ID to retrieve bounce domains for.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[https://github.com/socketlabs/socketlabs-powershell/blob/main/README.md](https://github.com/socketlabs/socketlabs-powershell/blob/main/README.md)

