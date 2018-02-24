namespace Acklann.NShellit
{
    /// <summary>
    /// Represents a code example.
    /// </summary>
    public struct Example
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Example"/> struct.
        /// </summary>
        /// <param name="example">The example.</param>
        public Example(Attributes.ExampleAttribute example) : this(example.Command, example.Explanation)
        {
            ForCmdlet = example.ForCmdlet;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Example"/> struct.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="description">The description.</param>
        public Example(string command, string description)
        {
            Command = command;
            Description = description;
            ForCmdlet = false;
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <value>The command.</value>
        public string Command { get; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance should be used only when packaged as a shell command.
        /// </summary>
        /// <value><c>true</c> if shell command; otherwise, <c>false</c>.</value>
        public bool ForCmdlet { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return Command;
        }
    }
}