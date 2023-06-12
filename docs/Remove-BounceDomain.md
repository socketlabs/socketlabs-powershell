---
external help file: SocketLabs.PowerShell.ManagementApi.dll-Help.xml
Module Name: SocketLabs
online version: https://github.com/socketlabs/socketlabs-powershell/blob/main/README.md
schema: 2.0.0
---

# Remove-BounceDomain

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

### Default (Default)
```
Remove-BounceDomain [-ServerId] <Int32> [-Domain] <String> [[-ApiKey] <String>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Pipeline
```
Remove-BounceDomain [-BounceDomains <BounceDomain[]>] [[-ApiKey] <String>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -ApiKey
{{ Fill ApiKey Description }}

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

### -BounceDomains
{{ Fill BounceDomains Description }}

```yaml
Type: BounceDomain[]
Parameter Sets: Pipeline
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
{{ Fill Domain Description }}

```yaml
Type: String
Parameter Sets: Default
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerId
{{ Fill ServerId Description }}

```yaml
Type: Int32
Parameter Sets: Default
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

### ManagementApi.Models.BounceDomain[]

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[https://github.com/socketlabs/socketlabs-powershell/blob/main/README.md](https://github.com/socketlabs/socketlabs-powershell/blob/main/README.md)

