using System;
using System.Collections.Generic;
using System.Linq;

namespace Acklann.NShellit.Generators
{
    /// <summary>
    /// Represents the package command.
    /// </summary>
    /// <seealso cref="Acklann.NShellit.CommandInfo" />
    internal class PackageCommand : CommandInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PackageCommand"/> class.
        /// </summary>
        public PackageCommand() : base()
        {
            Name = Id;
            IsInternal = true;
            Target = typeof(PackageCommand);
            Description = $"Exports your application as one or more of the following ({string.Join(" | ", Enum.GetNames(typeof(ShellKind)))}).";
            Examples.Add(new Example($"{Id} 1 '$assemblyLocation' '$psModuleDir'", "Wraps the console app in a powershell module."));
            RelatedLinks.Add("https://github.com/Ackara/NShellit");

            Add(new Argument(nameof(PackageKind), typeof(ShellKind))
            {
                Position = 0,
                Description = "",
                Default = (ShellKind.Powershell)
            },
            new Argument(nameof(AssemblyFile), typeof(string))
            {
                Position = 1,
                Description = "",
                IsRequired = true
            },
            new Argument(nameof(OutputDirectory), typeof(string))
            {
                Position = 2,
                Description = "",
                IsRequired = true
            });
        }

        /// <summary>
        /// The name/identifier
        /// </summary>
        public const string Id = "ca65cb33-397f-4f5a-851b-b2b0c8b11b94";

        /// <summary>
        /// Gets the kind of the package.
        /// </summary>
        /// <value>The kind of the package.</value>
        public ShellKind PackageKind
        {
            get { return (ShellKind)base[nameof(PackageKind).ToLowerInvariant()].GetValue(); }
        }

        /// <summary>
        /// Gets the executable file.
        /// </summary>
        /// <value>The executable file.</value>
        public string AssemblyFile
        {
            get { return base[nameof(AssemblyFile).ToLowerInvariant()].Value?.ToString(); }
        }

        /// <summary>
        /// Gets the output directory.
        /// </summary>
        /// <value>The output directory.</value>
        public string OutputDirectory
        {
            get { return base[nameof(OutputDirectory).ToLowerInvariant()].Value?.ToString(); }
        }

        /// <summary>
        /// Generates the packages.
        /// </summary>
        /// <param name="commandList">The command list.</param>
        public void GeneratePackages(IEnumerable<CommandInfo> commandList)
        {
            IEnumerable<IShellWrapper> packageGenerators = (from t in typeof(IShellWrapper).Assembly.ExportedTypes
                                                            where
                                                                !t.IsInterface &&
                                                                !t.IsAbstract &&
                                                                typeof(IShellWrapper).IsAssignableFrom(t)
                                                            select ((IShellWrapper)Activator.CreateInstance(t)));

            foreach (IShellWrapper generator in packageGenerators)
                if (PackageKind.HasFlag(generator.Kind))
                {
                    generator.GeneratePackage(commandList.Where(x => x.IsInternal == false), AssemblyFile, OutputDirectory);
                    Console.WriteLine($"{nameof(NShellit)} -> Successfully created package '{generator.PackageDirectory}\\'");
                }
        }
    }
}