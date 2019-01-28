# Topshelf.CommandLineOptions
Topshelf.CommandLineOptions provides extension to use CommandLine options when installing and launching apps build using Topshelf.
It uses `Reflection` to load properties of your Options DTO and utilizes built-in `AddCommandLineDefinition` method.

## Install
Package is available on [NuGet](https://www.nuget.org/packages/Topshelf.CommandLineOptions)  
PM> `Install-Package Topshelf.CommandLineOptions `

## Example
Create a class to hold your options
```csharp
public class CommandLineOptions
{
    public int? MyIntParam { get; set; }
    public string MyStringParam { get; set; }
}
```
Then let Topshelf.CommandLineOptions populate it
```csharp
HostFactory.Run(configure =>
{
    var commandLineOptions = configure.GetCommandlineOptions<CommandLineOptions>();

    configure.Service<BookByDateServiceRunner>(service =>
    {
        service.ConstructUsing(s => new BookByDateServiceRunner());
        service.WhenStarted(s => s.Start(commandLineOptions));
        service.WhenStopped(s => s.Stop());
    });
});
```
when running your app with arguments
```
MyApp.exe -MyIntParam:12 -MyStringParam:"String I Want To Pass"
```


### Custom arguments names
If you want to give custom (shorter) names to the params, you can decorate the properties with `[Option]` attrbitue.
```csharp
public class CommandLineOptions
{
    [Option("a")]
    public int? MyIntParam { get; set; }
    [Option("b")]
    public string MyStringParam { get; set; }
}
```
then you can run your app with given argument names instead
```
MyApp.exe -a:12 -b:"String I Want To Pass"
```

### Default values
If you need to specify default values for your options in case they are not provided when the app is launched, you can specify them as a default values in your Options class. Otherwise type-defaults are used.
```csharp
public class CommandLineOptions
{
    [Option("a")]
    public int? MyIntParam { get; set; } = 15;
    [Option("b")]
    public string MyStringParam { get; set; } = "Default string value";
}
```