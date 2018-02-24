using Acklann.NShellit.Generators;
using System;
using System.Linq;
using System.Text;

namespace Acklann.NShellit.Help
{
    /// <summary>
    /// Provides methods and properties to display a help menu.
    /// </summary>
    /// <seealso cref="Acklann.NShellit.Help.IHelpBuilder" />
    public class EditableHelpBuilder : IHelpBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditableHelpBuilder"/> class.
        /// </summary>
        /// <param name="debugMode">if set to <c>true</c> the <see cref="Debug"/> member will be assigned a value.</param>
        public EditableHelpBuilder(bool debugMode = false)
        {
#if DEBUG
            debugMode = true;
#endif
            _debug = debugMode;
            if (_debug) _content = new StringBuilder();
        }

        /// <summary>
        /// Gets the text printed to the console; only when debugging.
        /// </summary>
        /// <value>The debug.</value>
        public string Debug
        {
            get { return _content?.ToString(); }
        }

        /// <summary>
        /// Gets or sets the error message, if any.
        /// </summary>
        /// <value>The error.</value>
        public string Error
        {
            get; set;
        }

        /// <summary>
        /// Prints the header.
        /// </summary>
        public virtual void PrintHeader()
        {
            if (string.IsNullOrEmpty(Error))
            {
                WriteLine(string.Format(HeaderFormatString, AppInfo.Product, AppInfo.Version, AppInfo.Copyright), ConsoleColor.DarkGray);
                WriteLine("");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Prints the version number.
        /// </summary>
        public virtual void PrintVersion()
        {
            WriteLine(string.Format("{0} v{1}", AppInfo.Product, AppInfo.Version));
        }

        /// <summary>
        /// Prints the help menu.
        /// </summary>
        /// <param name="commandList">The command list.</param>
        public void PrintHelp(params CommandInfo[] commandList)
        {
            PrintHelp(Error, commandList);
        }

        /// <summary>
        /// Prints the help menu.
        /// </summary>
        /// <param name="error">The error message.</param>
        /// <param name="commandList">The command list.</param>
        public void PrintHelp(string error, params CommandInfo[] commandList)
        {
            Error = error;

            PrintHeader();
            PrintError();
            PrintUsage(commandList);
            PrintOptions(commandList);
            if (commandList.Length == 1)
            {
                PrintExamples(commandList[0]);
                PrintRelatedLinks(commandList[0]);
            }
            Console.ResetColor();
        }

        /* ----- */

        /// <summary>
        /// Prints the error message.
        /// </summary>
        protected virtual void PrintError()
        {
            if (!string.IsNullOrEmpty(Error))
            {
                WriteLine(string.Format(ErrorFormatString, Error), ConsoleColor.Red);
                WriteLine("");
            }
        }

        /// <summary>
        /// Prints the usage command(s) syntax.
        /// </summary>
        /// <param name="commandList">The command list.</param>
        protected virtual void PrintUsage(CommandInfo[] commandList)
        {
            Write("USAGE: ");

            if (commandList.Length == 1)
            {
                CommandInfo command = commandList[0];

                Write(command.Name, ConsoleColor.Yellow);
                foreach (Argument arg in command.OrderBy(x => x.Position))
                {
                    Write(string.Format((arg.HasAlias ? " [{0} <{1}>]" : " <{1}>"), arg.Name, arg.Kind).ToLowerInvariant(),
                        color: (arg.IsRequired ? ConsoleColor.White : ConsoleColor.Gray));
                }
                WriteLine("");
            }
            else if (commandList.Length > 1)
            {
                Write("command ", ConsoleColor.Yellow);
                WriteLine("[options]");
            }

            WriteLine("");
        }

        /// <summary>
        /// Prints the command(s) options.
        /// </summary>
        /// <param name="commandList">The command list.</param>
        protected virtual void PrintOptions(CommandInfo[] commandList)
        {
            string column1 = "Name", column2 = "Description";

            if (commandList.Length == 1)
            {
                CommandInfo command = commandList[0];
                if (command.HasArguments)
                {
                    int maxLen = (command.Max(x => alias(x).Length) + 2);
                    WriteLine("OPTIONS");
                    WriteLine("  {0} {1}", column1.PadRight(maxLen), column2);
                    WriteLine("  {0} {1}", underline(column1.Length).PadRight(maxLen), underline(column2.Length));
                    foreach (Argument arg in command.OrderBy(x => x.Position))
                    {
                        WriteLine("  {0} {1}{2}{3}",
                            (alias(arg)).PadRight(maxLen),

                            (arg.Default == null ? string.Empty : $"(Default: '{arg.Default}') "),
                            (arg.IsRequired ? "(Required) " : string.Empty),
                            arg.Description);
                    }
                }
            }
            else if (commandList.Length > 1)
            {
                int maxLen = (commandList.Max(x => x.Name.Length) + 2);

                WriteLine("COMMANDS");
                WriteLine("  {0} {1}", column1.PadRight(maxLen), column2);
                WriteLine("  {0} {1}", underline(column1.Length).PadRight(maxLen), underline(column2.Length));
                foreach (CommandInfo command in commandList.Where(x => x.Name != PackageCommand.Id))
                {
                    Write("  ");
                    Write(command.Name.PadRight(maxLen), ConsoleColor.Yellow);
                    WriteLine((' ' + command.Description));
                }
            }

            WriteLine("");

            /* LOCAL FUNCTIONS */

            string underline(int length) => string.Join("", Enumerable.Repeat('ˉ', length));
            string alias(Argument a) => (a.HasAlias ? string.Join(", ", a.Aliases.Select(n => $"-{n}").OrderBy(o => o.Length)) : $"[position {a.Position}]");
        }

        /// <summary>
        /// Prints the command examples.
        /// </summary>
        /// <param name="command">The command.</param>
        protected virtual void PrintExamples(CommandInfo command)
        {
            foreach (Example ex in command.Examples)
            {
                WriteLine(ExampleFormatString, ex.Command, ex.Description);
            }
        }

        /// <summary>
        /// Prints the command related links.
        /// </summary>
        /// <param name="command">The command.</param>
        protected virtual void PrintRelatedLinks(CommandInfo command)
        {
            if (command.RelatedLinks.Count > 0)
            {
                WriteLine("RELATED LINKS");
                foreach (string link in command.RelatedLinks)
                {
                    WriteLine($"  {link}");
                }
            }
        }

        /* ----- */

        /// <summary>
        /// Writes the specified content to the console.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="color">The color.</param>
        protected void Write(string content, ConsoleColor color = ConsoleColor.Gray)
        {
            if (_debug) _content.Append(content);

            Console.ForegroundColor = color;
            Console.Write(content);
        }

        /// <summary>
        /// Writes the specified content to the console.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="color">The color.</param>
        protected void WriteLine(string content, ConsoleColor color = ConsoleColor.Gray)
        {
            Write(string.Concat(content, Environment.NewLine), color);
        }

        /// <summary>
        /// Writes the specified content to the console.
        /// </summary>
        /// <param name="format">The string format.</param>
        /// <param name="values">The values.</param>
        protected void WriteLine(string format, params object[] values)
        {
            Write(string.Format(string.Concat(format, Environment.NewLine), values));
        }

        #region Format Strings

        /// <summary>
        /// The error format string
        /// </summary>
        public static string ErrorFormatString = "{0}";

        /// <summary>
        /// The header format string
        /// </summary>
        public static string HeaderFormatString =
@"{0} v{1}
{2}";

        /// <summary>
        /// The example format string
        /// </summary>
        public static string ExampleFormatString =
@"EXAMPLE
  {0}
  {1}
";

        #endregion Format Strings

        #region Private Members

        private readonly bool _debug;
        private readonly StringBuilder _content;

        #endregion Private Members
    }
}