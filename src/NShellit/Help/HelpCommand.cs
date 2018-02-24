namespace Acklann.NShellit.Help
{
    /// <summary>
    /// Represents a CLI help command.
    /// </summary>
    /// <seealso cref="Acklann.NShellit.CommandInfo" />
    internal class HelpCommand : CommandInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HelpCommand"/> class.
        /// </summary>
        public HelpCommand() : base()
        {
            Name = Id;
            IsInternal = true;
            Target = typeof(HelpCommand);
            Description = "Display the help menu.";

            Add(new Argument(nameof(CommandName), typeof(string))
            {
                Position = 0,
                Kind = "command",
                Description = "The name of a command."
            });
        }

        /// <summary>
        /// The name/identifier.
        /// </summary>
        public const string Id = "help";

        /// <summary>
        /// Gets the name of the command in which the help menu is to be presented for.
        /// </summary>
        /// <value>The name of the command.</value>
        public string CommandName
        {
            get { return this[nameof(CommandName).ToLower()].Value?.ToString(); }
        }
    }
}