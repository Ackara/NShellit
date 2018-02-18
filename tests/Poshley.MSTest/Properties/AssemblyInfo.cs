using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("Poshly.MSTest")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Poshly.MSTest")]
[assembly: AssemblyCopyright("Copyright ©  2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: Guid("e01b17c1-3471-4068-a77c-0e49e09b4c7a")]

// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

// Approval Tests
[assembly: UseApprovalSubdirectory(nameof(ApprovalTests))]
[assembly: UseReporter(typeof(DiffReporter), typeof(ClipboardReporter))]