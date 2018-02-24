namespace Acklann.NShellit.Help
{
    /// <summary>
    /// Provides methods for presenting a help menu.
    /// </summary>
    public interface IHelpBuilder
    {
        /// <summary>
        /// Prints the header.
        /// </summary>
        void PrintHeader();

        /// <summary>
        /// Prints the version.
        /// </summary>
        void PrintVersion();

        /// <summary>
        /// Prints the help menu.
        /// </summary>
        /// <param name="commandList">The command list.</param>
        void PrintHelp(params CommandInfo[] commandList);

        /// <summary>
        /// Prints the help menu.
        /// </summary>
        /// <param name="error">The error message.</param>
        /// <param name="commandList">The command list.</param>
        void PrintHelp(string error, params CommandInfo[] commandList);
    }
}