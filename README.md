# NShellit
[![NuGet](https://img.shields.io/nuget/v/Acklann.NShellit.svg)](https://www.nuget.org/packages/Acklann.NShellit/)
[![NuGet](https://img.shields.io/nuget/dt/Acklann.NShellit.svg)](https://www.nuget.org/packages/Acklann.NShellit/)
---

## What is NShellit?
NShellit is a command-line parser inspired by *powershell*. Powershell has one of the best argument convention around, so why not incorporate it into  console applications.

### Where can I get?
NShellit is available at [nuget.org](https://www.nuget.org/packages/Acklann.NShellit).

### How it works?
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
var parser = Acklann.NShellit.Parser.MapResults(args, typeof(CoolCommand));
/// OR EVEN BETTER
/// var parser = Acklann.NShellit.Parser.MapResults(args, allCommandTypes);

if (parser.HasResult)
{
    var command = parser.GetResult<ICommand>();
    return command.Execute();
}
else return parser.PrintUsage();
```
