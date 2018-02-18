using Acklann.Poshley.Generators;
using System;
using System.Linq;
using System.Text;

namespace Acklann.Poshley.Help
{
    public class EditableHelpBuilder : IHelpBuilder
    {
        public EditableHelpBuilder(bool debugMode = false)
        {
#if DEBUG
            debugMode = true;
#endif
            _debug = debugMode;
            if (_debug) _content = new StringBuilder();
        }

        public string Debug
        {
            get { return _content?.ToString(); }
        }

        public string Error
        {
            get; set;
        }

        public virtual void PrintHeader()
        {
            if (string.IsNullOrEmpty(Error))
            {
                WriteLine(string.Format(HeaderFormatString, AppInfo.Product, AppInfo.Version, AppInfo.Copyright), ConsoleColor.DarkGray);
                WriteLine("");
                Console.ResetColor();
            }
        }

        public virtual void PrintVersion()
        {
            WriteLine(string.Format("{0} v{1}", AppInfo.Product, AppInfo.Version));
        }

        public void PrintHelp(params CommandInfo[] commandList)
        {
            PrintHelp(Error, commandList);
        }

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

        protected virtual void PrintError()
        {
            if (!string.IsNullOrEmpty(Error))
            {
                WriteLine(string.Format(ErrorFormatString, Error), ConsoleColor.Red);
                WriteLine("");
            }
        }

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

        protected virtual void PrintExamples(CommandInfo command)
        {
            foreach (Example ex in command.Examples)
            {
                WriteLine(ExampleFormatString, ex.Command, ex.Description);
            }
        }

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

        protected void Write(string content, ConsoleColor color = ConsoleColor.Gray)
        {
            if (_debug) _content.Append(content);
            Console.ForegroundColor = color;
            Console.Write(content);
        }

        protected void WriteLine(string content, ConsoleColor color = ConsoleColor.Gray)
        {
            Write(string.Concat(content, Environment.NewLine), color);
        }

        protected void WriteLine(string format, params object[] values)
        {
            Write(string.Format(string.Concat(format, Environment.NewLine), values));
        }

        #region Format Strings

        public static string ErrorFormatString = "{0}";

        public static string HeaderFormatString =
@"{0} v{1}
{2}";

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