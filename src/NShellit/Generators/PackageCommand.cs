using System;
using System.Collections.Generic;
using System.Linq;

namespace Acklann.NShellit.Generators
{
    internal class PackageCommand : CommandInfo
    {
        internal PackageCommand() : base()
        {
            Name = Id;
            IsInternal = true;
            Target = typeof(PackageCommand);
            Description = "";
            Examples.Add(new Example("", ""));
            RelatedLinks.Add("");

            Add(new Argument(nameof(ExecutableFile), typeof(string))
            {
                Position = 0,
                Description = "",
                IsRequired = true
            }, new Argument(nameof(PackageKind), typeof(ShellKind))
            {
                Position = 1,
                Description = "",
                Default = (ShellKind.Powershell)
            });
        }

        public const string Id = "ca65cb33-397f-4f5a-851b-b2b0c8b11b94";

        internal ShellKind PackageKind
        {
            get { return (ShellKind)base[nameof(PackageKind).ToLowerInvariant()].GetValue(); }
        }

        internal string ExecutableFile
        {
            get { return base[nameof(ExecutableFile).ToLowerInvariant()].Value?.ToString(); }
        }

        internal void GeneratePackages(IEnumerable<CommandInfo> commandList)
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
                    generator.GeneratePackage(commandList.Where(x => x.IsInternal == false), ExecutableFile);
                    Console.WriteLine($"{nameof(NShellit)} -> Successfully created package '{generator.PackageDirectory}\\'");
                }
        }
    }
}