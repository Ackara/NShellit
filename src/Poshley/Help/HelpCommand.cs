namespace Acklann.Poshley.Help
{
    internal class HelpCommand : CommandInfo
    {
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

        public const string Id = "help";

        public string CommandName
        {
            get { return this[nameof(CommandName).ToLower()].Value?.ToString(); }
        }
    }
}