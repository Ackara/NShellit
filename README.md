# Poshly
[![NuGet](https://img.shields.io/nuget/v/Acklann.Poshly.svg)](https://www.nuget.org/packages/Acklann.Poshly/)
[![NuGet](https://img.shields.io/nuget/dt/Acklann.Poshly.svg)](https://www.nuget.org/packages/Acklann.Poshly/)
---

## What is Poshly?
Poshly is a command-line parser inspired by *powershell*. Powershell has one of the best argument convention around, so why not incorporate it into  console applications.

### Where can I get?
Poshly is available at [nuget.org](https://www.nuget.org/packages/Acklann.Poshly).

### How it works?
First you will need to create a simple class that will store the options for your command, and decorate them with the following Attributes.

```csharp
class CoolCommand : ICommand
{
    [Parameter(Mandatory = true)]
    public string SomeString { get; set; }
    
    [Parameter]
    public int SomeNumber { get; set; }
    
    [Parameter]
    [Alias("s", "enable")]
    public bool SomeSwitch { get; set; }
    
    int Execute() { ... }
}
```

Next in your `Program.cs` file add the following.

```csharp
var parser = Acklann.Poshly.Parser.MapResults(args, typeof(CoolCommand));
/// OR EVEN BETTER
/// var parser = Acklann.Poshly.Parser.MapResults(args, allCommandTypes);

if (parser.HasResult)
{
    var command = parser.GetResult<ICommand>();
    return command.Execute();
}
else return parser.PrintUsage();
```



