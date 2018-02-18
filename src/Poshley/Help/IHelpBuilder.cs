namespace Acklann.Poshley.Help
{
    public interface IHelpBuilder
    {
        void PrintHeader();

        void PrintVersion();

        void PrintHelp(params CommandInfo[] commandList);

        void PrintHelp(string error, params CommandInfo[] commandList);
    }
}