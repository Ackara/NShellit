using Acklann.NShellit.Generators;
using Acklann.NShellit.Help;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Acklann.NShellit
{
    /// <summary>
    /// Provides methods for converting command-line arguments to an object.
    /// </summary>
    public class Parser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parser"/> class.
        /// </summary>
        public Parser() : this(ParserOptions.None, new EditableHelpBuilder())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parser"/> class.
        /// </summary>
        /// <param name="options">The settings used to create the object.</param>
        public Parser(ParserOptions options) : this(options, new EditableHelpBuilder())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parser" /> class.
        /// </summary>
        /// <param name="options">The settings used to create the object.</param>
        /// <param name="helpBuilder">The object used to build the help menu.</param>
        /// <exception cref="ArgumentNullException"><see cref="IHelpBuilder"/> is null.</exception>
        public Parser(ParserOptions options, IHelpBuilder helpBuilder)
        {
            _helpBuilder = helpBuilder ?? throw new ArgumentNullException(nameof(helpBuilder));
            _commandList = new Dictionary<string, CommandInfo>();
            _options = options;

            // Appending internal commands
            if (!options.HasFlag(ParserOptions.ExcludeHelpCommand)) _commandList.Add(HelpCommand.Id, new HelpCommand());
            if (!options.HasFlag(ParserOptions.ExcludeVersionCommand)) _commandList.Add(VersionCommand.Id, new VersionCommand());
            if (!options.HasFlag(ParserOptions.ExcludePackageCommand)) _commandList.Add(PackageCommand.Id, new PackageCommand());
        }

        /// <summary>
        /// Tries the convert the given string value to the specified base type.
        /// </summary>
        /// <typeparam name="TResult">The type to convert the value to.</typeparam>
        /// <param name="value">The string value.</param>
        /// <param name="result">The result.</param>
        /// <returns><c>true</c> if value was converted successfully, <c>false</c> otherwise.</returns>
        public static bool TryConvert<TResult>(string value, out TResult result)
        {
            bool success = TryConvert(value, typeof(TResult), out object obj);
            result = (TResult)obj;
            return success;
        }

        /// <summary>
        /// Tries the convert the given string value to the specified base type.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <param name="conversionType">The type to convert value to.</param>
        /// <param name="result">The result.</param>
        /// <returns><c>true</c> if value was converted successfully, <c>false</c> otherwise.</returns>
        public static bool TryConvert(string value, Type conversionType, out object result)
        {
            result = null;

            if (conversionType == null || value == null) return false;
            else try
                {
                    if (conversionType.IsEnum)
                    {
                        result = Enum.Parse(conversionType, value, ignoreCase: true);
                    }
                    else if (conversionType == typeof(bool))
                    {
                        switch (value.ToLowerInvariant())
                        {
                            case "1":
                            case "on":
                            case "true":
                                result = true;
                                break;

                            case "0":
                            case "off":
                            case "false":
                                result = false;
                                break;
                        }
                    }
                    else if (conversionType.IsArray)
                    {
                        Type elementType = conversionType.GetElementType();
                        string[] list = value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        var array = Array.CreateInstance(elementType, list.Length);
                        for (int i = 0; i < list.Length; i++)
                        {
                            array.SetValue(Convert.ChangeType(list[i], elementType), i);
                        }
                        result = array;
                    }
                    else result = Convert.ChangeType(value, conversionType);

                    return result != null;
                }
                catch { return false; }
        }

        /// <summary>
        /// Tries to map the specified argument array to a command within this instance's command-list. To build the command-list see <see cref="Add(CommandInfo[])"/>.
        /// </summary>
        /// <param name="args">The argument array.</param>
        /// <param name="command">The mapped/selected command.</param>
        /// <param name="error">The reason as to why this method returns <c>false</c>.</param>
        /// <returns><c>true</c> if a command was found, <c>false</c> otherwise.</returns>
        public bool TryMap(string[] args, out CommandInfo command, out string error)
        {
            if (TryFindCommand(ref args, out command, out error))
            {
                /* TODO: explain implementation. */

                var parameterList = new LinkedList<Argument>(command);
                LinkedList<Token> userArgs = Tokenize(args);
                LinkedListNode<Token> node = userArgs.First;
                var duplicateAt = new bool[userArgs.Count];
                int position = -1;
                Token arg;

                while (node != null)
                {
                    arg = node.Value;
                    if (!arg.HasName) position++;

                    if (duplicateAt[arg.Position]) position--;
                    else if (TryFindParameter(arg, parameterList, position, out LinkedListNode<Argument> parameter, out error))
                    {
                        parameterList.Remove(parameter);
                        if (arg.HasName && parameter.Value.DataType != typeof(bool))
                        {
                            duplicateAt[arg.Position + 1] = true;
                        }
                    }
                    else return false;

                    node = node.Next;
                }

                if (!string.IsNullOrEmpty(error)) ShowHelpMenu(command.Name, error);
                else if (RequiredParametersWereNotAssigned(parameterList, out error)) ShowHelpMenu(command.Name, error);
                else if (command.IsInternal) HandleInternalCommand(command);
            }
            else ShowHelpMenu();

            return string.IsNullOrEmpty(error);
        }

        /// <summary>
        /// Adds a <see cref="CommandInfo" /> to this instance list of available commands.
        /// </summary>
        /// <param name="commandList">The command list.</param>
        /// <exception cref="ArgumentNullException"><paramref name="commandList"/> is null.</exception>
        public void Add(params CommandInfo[] commandList)
        {
            if (commandList == null) throw new ArgumentNullException(nameof(commandList));

            foreach (CommandInfo command in commandList)
                if (command != null)
                {
                    _commandList.Add(command.Name.ToLowerInvariant(), command);
                }
        }

        /* --- HELPER METHODS --- */

        private LinkedList<Token> Tokenize(string[] args)
        {
            string name, value, nextValue, array;
            int i, temp, position = 0, n = args.Length;
            var list = new LinkedList<Token>();

            for (i = 0; i < n; i++)
            {
                value = args[i];
                if (!string.IsNullOrEmpty(value))
                {
                    if (value[0] == '-')
                    {
                        temp = i;
                        name = value.TrimStart('-');
                        value = (++i < n ? args[i] : string.Empty);
                        list.AddFirst(new Token(position++, name, getValue()));
                        i = temp;
                    }
                    else list.AddLast(new Token(position++, string.Empty, getValue()));
                }
            }

            return list;

            /* *** LOCAL FUNCTIONS *** */

            bool traversingArray()
            {
                nextValue = ((i + 1) < n ? args[(i + 1)] : string.Empty);
                return !string.IsNullOrEmpty(value) && (value[value.Length - 1] == ',' || (!string.IsNullOrEmpty(nextValue) && nextValue[0] == ','));
            }

            string getValue()
            {
                if (traversingArray())
                {
                    array = string.Empty;
                    do
                    {
                        array = string.Concat(array, value);
                        value = (++i < n ? args[i] : string.Empty);
                    } while (traversingArray());
                    value = string.Concat(array, value);
                }

                return value;
            }
        }

        private bool TryFindCommand(ref string[] args, out CommandInfo command, out string error)
        {
            error = string.Empty;
            bool matchFound = true;
            string verb = (args?.Length > 0 ? args[0].ToLowerInvariant() : string.Empty);

            if (_commandList.ContainsKey(verb) && !string.IsNullOrEmpty(verb))
            {
                args[0] = string.Empty;
                command = _commandList[verb];
            }
            else if (_commandList.ContainsKey(string.Empty))
            {
                command = _commandList[string.Empty];
            }
            else
            {
                command = null;
                matchFound = false;
                error = (string.IsNullOrEmpty(verb) ?
                    "No arguments were passed." :
                    string.Format("The term '{0}' is not recognized as a valid command, check your spelling and try again.", verb));
            }

            return matchFound;
        }

        private bool TryFindParameter(Token userArg, LinkedList<Argument> parameterList, int position, out LinkedListNode<Argument> parameter, out string error)
        {
            parameter = parameterList.First;

            while (parameter != null)
            {
                if (userArg.HasName)
                {
                    /* if the user arg matches the param alias or member name */
                    if ((parameter.Value.Aliases?.Contains(userArg.Name, StringComparer.IgnoreCase) ?? false) || (userArg.Name.Equals(parameter.Value.MemberName, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        parameter.Value.Value = getValue(parameter.Value.DataType, out error);
                        return string.IsNullOrEmpty(error);
                    }
                }
                else if (parameter.Value.Position == position)
                {
                    parameter.Value.Value = getValue(parameter.Value.DataType, out error);
                    return string.IsNullOrEmpty(error);
                }

                parameter = parameter.Next;
            }

            error = string.Format("The term {0} is not a valid argument.", (userArg.HasName ? userArg.Name : $"at position {userArg.Position}"));
            return false;

            object getValue(Type dataType, out string err)
            {
                err = string.Empty;
                string value = ((userArg.HasName && userArg.IsSwitch == false && dataType == typeof(bool)) ? bool.TrueString : userArg.Value);

                if (TryConvert(value, dataType, out object result) == false)
                {
                    err = string.Format("'{0}' should be of type {1}", userArg.Value, dataType.Name);
                }

                return result;
            }
        }

        private bool RequiredParametersWereNotAssigned(LinkedList<Argument> parameterList, out string error)
        {
            error = string.Join(Environment.NewLine, (from p in parameterList
                                                      where p.IsRequired
                                                      select $"The parameter ({p.Name}) is required; you must supply a value."));
            return string.IsNullOrWhiteSpace(error) == false;
        }

        private void HandleInternalCommand(CommandInfo command)
        {
            switch (command.Name)
            {
                case HelpCommand.Id:
                    ShowHelpMenu((command as HelpCommand).CommandName);
                    break;

                case VersionCommand.Id:
                    _helpBuilder.PrintVersion();
                    break;

                case PackageCommand.Id:
                    (command as PackageCommand).GeneratePackages(_commandList.Values);
                    break;
            }
        }

        private void ShowHelpMenu(string command = null, string error = "")
        {
            command = command?.ToLowerInvariant();
            if (command == null) _helpBuilder.PrintHelp(error, _commandList.Values.ToArray());
            else if (_commandList.ContainsKey(command)) _helpBuilder.PrintHelp(error, _commandList[command]);
            else _helpBuilder.PrintHelp(error, _commandList.Values.ToArray());
        }

        #region Non-Public Fields

        private readonly ParserOptions _options;
        private readonly IHelpBuilder _helpBuilder;
        private readonly IDictionary<string, CommandInfo> _commandList;

        #endregion Non-Public Fields
    }
}