using System;

namespace Acklann.NShellit.Generators
{
    /// <summary>
    /// Represents a package type.
    /// </summary>
    [Flags]
    public enum ShellKind
    {
        /// <summary>
        /// Powershell Module
        /// </summary>
        Powershell = 1
    }
}