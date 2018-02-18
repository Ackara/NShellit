namespace Acklann.Poshley.Help
{
    internal class VersionCommand : CommandInfo
    {
        public VersionCommand() : base()
        {
            Name = Id;
            IsInternal = true;
            Target = typeof(VersionCommand);
            Description = "Display the current version information.";
        }

        public const string Id = "version";
    }
}