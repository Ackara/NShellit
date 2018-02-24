namespace Acklann.NShellit.Help
{
    /// <summary>
    /// Represents a CLI version command.
    /// </summary>
    /// <seealso cref="Acklann.NShellit.CommandInfo" />
    internal class VersionCommand : CommandInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VersionCommand"/> class.
        /// </summary>
        public VersionCommand() : base()
        {
            Name = Id;
            IsInternal = true;
            Target = typeof(VersionCommand);
            Description = "Display the current version information.";
        }

        /// <summary>
        /// The name/identifier.
        /// </summary>
        public const string Id = "version";
    }
}