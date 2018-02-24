using System;

namespace Acklann.NShellit.Attributes
{
    /// <summary>
    /// Defines a command for a command-line parser. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage((AttributeTargets.Class | AttributeTargets.Struct), Inherited = false, AllowMultiple = false)]
    public sealed class CommandAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandAttribute"/> class.
        /// </summary>
        /// <param name="name">The name of the command.</param>
        public CommandAttribute(string name) : this(name, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandAttribute"/> class.
        /// </summary>
        /// <param name="name">The name of the command.</param>
        /// <param name="summary">The command description.</param>
        public CommandAttribute(string name, string summary)
        {
            Name = name;
            Summary = summary;
        }

        /// <summary>
        /// The name
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        /// <value>The summary.</value>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the name to be used when creating a shell command using an <see cref="Generators.IShellWrapper"/>.
        /// </summary>
        /// <value>The command name.</value>
        public string Cmdlet { get; set; }
    }
}