using System.Collections.Generic;

namespace Acklann.Poshley.Generators
{
    public interface IShellWrapper
    {
        ShellKind Kind { get; }

        string PackageDirectory { get; }

        void GeneratePackage(IEnumerable<CommandInfo> commandList, string executableFile);
    }
}