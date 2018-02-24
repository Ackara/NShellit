using System;

namespace Acklann.NShellit
{
    /// <summary>
    /// Provides enumerated values to use to set <see cref="Parser"/> options.
    /// </summary>
    [Flags]
    public enum ParserOptions
    {
        /// <summary>
        /// Default settings.
        /// </summary>
        None = 0,

        /// <summary>
        /// The exclude help command.
        /// </summary>
        ExcludeHelpCommand = 1,

        /// <summary>
        /// The exclude version command.
        /// </summary>
        ExcludeVersionCommand = 2,

        /// <summary>
        /// The exclude package command.
        /// </summary>
        ExcludePackageCommand = 4
    }
}