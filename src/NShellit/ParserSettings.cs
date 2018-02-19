namespace Acklann.NShellit
{
    public struct ParserSettings
    {
        public bool EnableHelpCommand;

        public bool EnableVersionCommand;

        public bool EnablePackageCommand;

        public static ParserSettings GetDefault() => new ParserSettings()
        {
            EnableHelpCommand = true,
            EnableVersionCommand = true,
            EnablePackageCommand = true
        };
    }
}