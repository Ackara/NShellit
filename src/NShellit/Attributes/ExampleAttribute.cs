using System;

namespace Acklann.NShellit.Attributes
{
    /// <summary>
    /// Defines an usage example for a command. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage((AttributeTargets.Class | AttributeTargets.Struct), AllowMultiple = true, Inherited = true)]
    public sealed class ExampleAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleAttribute"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        public ExampleAttribute(string command) : this(command, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleAttribute"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="explanation">The explanation.</param>
        public ExampleAttribute(string command, string explanation)
        {
            this.Command = command;
            Explanation = explanation;
        }

        /// <summary>
        /// The command
        /// </summary>
        public readonly string Command;

        /// <summary>
        /// Gets or sets the explanation.
        /// </summary>
        /// <value>The explanation.</value>
        public string Explanation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the target command should be used only when packaged as a shell command.
        /// </summary>
        /// <value><c>true</c> if [for shell]; otherwise, <c>false</c>.</value>
        public bool ForCmdlet { get; set; }
    }
}