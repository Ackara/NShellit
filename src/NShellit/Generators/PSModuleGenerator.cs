using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Acklann.NShellit.Generators
{
    /// <summary>
    /// Provides methods for creating a powershell module.
    /// </summary>
    /// <seealso cref="Acklann.NShellit.Generators.IShellWrapper" />
    public class PSModuleGenerator : IShellWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSModuleGenerator"/> class.
        /// </summary>
        public PSModuleGenerator()
        {
            _content = new StringBuilder();
            _packageDirectory = Path.Combine(Path.GetTempPath(), nameof(NShellit), "powershell");
        }

        /// <summary>
        /// Gets the output directory.
        /// </summary>
        /// <value>The package directory.</value>
        public string PackageDirectory
        {
            get { return _packageDirectory; }
        }

        /// <summary>
        /// Gets the kind of package.
        /// </summary>
        /// <value>The kind.</value>
        public ShellKind Kind => ShellKind.Powershell;

        /// <summary>
        /// Generates the powershell module from cli executable.
        /// </summary>
        /// <param name="commandList">The command list.</param>
        /// <param name="assemblyFile">The executable.</param>
        /// <exception cref="FileNotFoundException"></exception>
        public void GeneratePackage(IEnumerable<CommandInfo> commandList, string assemblyFile, string outputDirectory)
        {
            if (!File.Exists(assemblyFile)) throw new FileNotFoundException($"Could not file at '{assemblyFile}'.");

            string workingDirectory = Path.GetDirectoryName(assemblyFile);
            _packageDirectory = Path.Combine(outputDirectory, "powershell", AppInfo.Product);
            DeleteAllFileButTheModuleManifest();

            CopyAssemblyFilesToBinFolder(workingDirectory);
            GeneratePSModuleManifest(commandList, assemblyFile);
        }

        /* --- HELPER METHODS --- */

        private void DeleteAllFileButTheModuleManifest()
        {
            /* NOTES:
            * I am going through the trouble of deleting everything but the manifest because
            * I don't want the manifest GUID to change every time I rebuild the package.
            * Perhaps its better/faster to just delete the entire folder especially when
            * invoking MSBuild clean will delete anyway. However I'll keep it mainly so my
            * approval tests can pass. Also will powershell gallery except the same GUID after
            * each update; something to think check out.
            */

            if (Directory.Exists(_packageDirectory))
            {
                foreach (string path in (from p in Directory.EnumerateFiles(_packageDirectory, "*", SearchOption.AllDirectories)
                                         where Path.GetExtension(p) != ".psd1"
                                         select p))
                {
                    File.Delete(path);
                }
            }
            else Directory.CreateDirectory(_packageDirectory);
        }

        private void CopyAssemblyFilesToBinFolder(string workingDirectory)
        {
            string binFolder = Path.Combine(_packageDirectory, "bin"), dest, dir;
            if (!Directory.Exists(binFolder)) Directory.CreateDirectory(binFolder);
            IEnumerable<string> assemblies = Directory.EnumerateFiles(workingDirectory, "*", SearchOption.TopDirectoryOnly);
            IEnumerable<string> subFolders = (from d in Directory.EnumerateDirectories(workingDirectory, "*", SearchOption.TopDirectoryOnly)
                                              where (d.EndsWith("publish") || d.EndsWith("generated")) == false
                                              select d);

            foreach (string file in assemblies)
            {
                File.Copy(file, Path.Combine(binFolder, Path.GetFileName(file)), overwrite: true);
            }

            foreach (string folder in subFolders)
            {
                foreach (string file in Directory.EnumerateFiles(folder, "*", SearchOption.AllDirectories))
                {
                    dest = Path.Combine(binFolder, file.Remove(0, workingDirectory.Length + 1));
                    dir = Path.GetDirectoryName(dest);
                    if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                    File.Copy(file, dest, overwrite: true);
                }
            }
        }

        private void GeneratePSModuleManifest(IEnumerable<CommandInfo> commandList, string assemblyFile)
        {
            string exe = Path.ChangeExtension(assemblyFile, ".exe");
            if (File.Exists(exe)) assemblyFile = exe;

            var cmdlets = new LinkedList<string>();
            foreach (CommandInfo command in commandList)
            {
                cmdlets.AddLast(GetCmdlet(command));
                WriteScript(assemblyFile, command);
            }

            // Creating powershell module manifest.
            var manifest = $"{AppInfo.Product}.psd1";
            var cmdlet = (File.Exists(Path.Combine(_packageDirectory, manifest)) ? "Update-ModuleManifest" : "New-ModuleManifest");
            var cmdletsToExport = string.Join(", ", cmdlets.Select(x => $"'{x}'"));
            var nestedModules = string.Join(", ", cmdlets.Select(x => $"'{x}.ps1'"));

            using (var cmd = new Process
            {
                StartInfo = new ProcessStartInfo("powershell")
                {
                    Arguments = $"-ExecutionPolicy Bypass -NonInteractive -Command \"{cmdlet} '{manifest}' -ModuleVersion '{AppInfo.Version}' -Description '{AppInfo.Description}' -Author '{AppInfo.Company}' -Company '{AppInfo.Company}' -Copyright '{AppInfo.Copyright}' -NestedModules @({nestedModules}) -CmdletsToExport @({cmdletsToExport})\"",

                    WorkingDirectory = _packageDirectory,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            }) { cmd.Start(); Console.WriteLine(cmd.StandardError.ReadToEnd()); }
        }

        /* ----- */

        private void WriteScript(string executableFile, CommandInfo command)
        {
            string name = GetCmdlet(command);
            string toolExe = (Path.GetExtension(executableFile).ToLowerInvariant() == ".dll" ? "dotnet " : string.Empty); /* {11} */

            var script = string.Format(@"<#
.SYNOPSIS
{3}{4}{5}{6}
#>

function {0}({2})
{{
    {9}
    $exe = ""$PSScriptRoot\bin\{1}"";
    return (&{11}$exe {8} {7});
}}
{10}
", name, Path.GetFileName(executableFile), GetParameterList(command), (command.Description), GetParameterDocs(command), GetExamplesDoc(command), GetRelatedLinksDoc(command), GetArgumentList(command), command.Name, GetPreparationCode(command), GetAliases(command), toolExe);

            File.WriteAllText(Path.Combine(_packageDirectory, $"{name}.ps1"), script, Encoding.UTF8);
        }

        /* *** {2} *** */

        private string GetParameterList(CommandInfo command)
        {
            if (command.HasArguments)
            {
                _content.Clear();
                foreach (Argument param in command.OrderBy(x => x.Position))
                {
                    _content.AppendFormat(@"
[Parameter({0})][Alias({1})]{4}[{2}]${3},", parameterOf(param), aliasOf(param), typeOf(param), param.MemberName, enumOf(param));
                }

                return _content.ToString().TrimEnd(' ', ',', '\r', '\n');
            }
            else return string.Empty;

            /* LOCAL FUNCTIONS */

            string aliasOf(Argument a) => (a.HasAlias ? string.Join(", ", a.Aliases.Select(x => $"'{x}'")) : string.Empty);
            string parameterOf(Argument a) => string.Concat((a.IsRequired ? "Mandatory" : string.Empty));
            string typeOf(Argument a)
            {
                if (a.DataType == typeof(bool)) return "switch";
                else if (a.DataType.IsEnum) return "string";
                else return a.DataType.Name;
            }
            string enumOf(Argument a)
            {
                if (a.DataType.IsEnum) return string.Format(@"[ValidatePattern('(?i)({0}|\d+)')]", string.Join("|", Enum.GetNames(a.DataType).Select(x => $"^{x}$")));
                else return string.Empty;
            }
        }

        /* *** {9} *** */

        private object GetPreparationCode(CommandInfo command)
        {
            _content.Clear();
            foreach (Argument arg in command)
            {
                _content.AppendFormat(@"
    $name{0} = ''; $value{0} = '';
    if (${1}) {{ $name{0} = '-{1}'; $value{0} = {2}; }}
", arg.Position, arg.MemberName, valueOf(arg));
            }

            return _content.ToString();

            /* LOCAL FUNCTIONS */

            string valueOf(Argument a)
            {
                if (a.DataType.IsArray) return $"[string]::Join(',', ${a.MemberName})";
                else if (a.DataType == typeof(bool)) return "''";
                else return $"${a.MemberName}.ToString()";
            }
        }

        /* *** {7} *** */

        private string GetArgumentList(CommandInfo command)
        {
            if (command.HasArguments)
            {
                return string.Join(" ", command.Select(x => string.Format("$name{0} $value{0}", x.Position)));
            }
            else return string.Empty;
        }

        /* *** {4} *** */

        private string GetParameterDocs(CommandInfo command)
        {
            if (command.HasArguments)
            {
                _content.Clear();
                foreach (Argument param in command)
                {
                    _content.AppendFormat(@"

.PARAMETER {0}
{1}", param.MemberName, param.Description);
                }
                return _content.ToString();
            }
            else return string.Empty;
        }

        /* *** {5} *** */

        private string GetExamplesDoc(CommandInfo command)
        {
            if (command.Examples.Count > 0)
            {
                _content.Clear();
                foreach (Example ex in command.Examples)
                    if (ex.ForCmdlet)
                    {
                        _content.AppendFormat(@"

.EXAMPLE
{0}
{1}", ex.Command, ex.Description);
                    }
                return _content.ToString();
            }
            else return string.Empty;
        }

        /* *** {6} *** */

        private string GetRelatedLinksDoc(CommandInfo command)
        {
            if (command.RelatedLinks.Count > 0)
            {
                _content.Clear();
                foreach (string link in command.RelatedLinks)
                {
                    _content.AppendFormat(@"

.LINK
{0}", link);
                }
                return _content.ToString();
            }
            else return string.Empty;
        }

        /* *** {10} *** */

        private string GetAliases(CommandInfo command)
        {
            _content.Clear();
            _content.AppendLine();
            foreach (string name in command.Aliases)
            {
                _content.AppendLine($"Set-Alias -Name '{name}' -Value '{GetCmdlet(command)}';");
            }

            return _content.ToString();
        }

        #region Private Members

        private StringBuilder _content;
        private string _packageDirectory;

        private string GetCmdlet(CommandInfo c) => string.IsNullOrEmpty(c.Cmdlet) ? $"Invoke-{System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(c.Name)}" : c.Cmdlet;

        #endregion Private Members
    }
}