using System.Collections.Generic;

namespace Acklann.NShellit.Generators
{
    /// <summary>
    /// Provide methods for packaging console application.
    /// </summary>
    public interface IShellWrapper
    {
        /// <summary>
        /// Gets the kind of package.
        /// </summary>
        /// <value>The kind.</value>
        ShellKind Kind { get; }

        /// <summary>
        /// Gets the output directory.
        /// </summary>
        /// <value>The package directory.</value>
        string PackageDirectory { get; }

        /// <summary>
        /// Generates the package.
        /// </summary>
        /// <param name="commandList">The command list.</param>
        /// <param name="assemblyFile">The executable file.</param>
        void GeneratePackage(IEnumerable<CommandInfo> commandList, string assemblyFile, string outputDirectory);
    }
}