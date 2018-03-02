# NShellit
[![NuGet](https://img.shields.io/nuget/v/Acklann.NShellit.svg)](https://www.nuget.org/packages/Acklann.NShellit/)
[![NuGet](https://img.shields.io/nuget/dt/Acklann.NShellit.svg)](https://www.nuget.org/packages/Acklann.NShellit/)
![License](https://img.shields.io/badge/license-MIT-lightgrey.svg)
---

## What is NShellit?

NShellit is a command-line parser inspired by *powershell*. Powershell has some of the best conventions for handling arguments, so why not incorporate some of them into our console applications.

## How it works?

First you will need to create a simple class that will store the options for your command, and decorate them with the following Attributes.

```csharp
class CoolCommand : ICommand
{
    [Required, Parameter]
    public string SomeString { get; set; }
    
    [Parameter]
    public int SomeNumber { get; set; }
    
    [Parameter("s", "enabale")]
    public bool SomeSwitch { get; set; }
    
    int Execute() { ... }
}
```

Next in your `Program.cs` file add the following.

```csharp
using Acklann.NShellit.Extensions;

var parser = new Acklann.NShellit.Parser();

paser.Map<CoolCommand, OtherCommand>(args,
    (cool) => { cool.Execute(); },
    (other) => { other.Execute(); },
    (errorMsg) => { /* optional */ }
);

/* --- OR EVEN BETTER --- */

int exitCode = parser.Map<ICommand, int>(args, listOfAllCommandTypes,
    (command) => { return command.Execute(); },
    (errorMsg) => { return 101; }
);
```

## Where can I get?

NShellit is available at [nuget.org](https://www.nuget.org/packages/Acklann.NShellit).

`PM> Install-Package Acklann.Nshellit`