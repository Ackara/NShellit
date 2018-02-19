using Acklann.NShellit.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Acklann.NShellit
{
    [System.Diagnostics.DebuggerDisplay("{ToDebuggerDisplay()}")]
    public class CommandInfo : IEnumerable<Argument>
    {
        public CommandInfo(string name, params Argument[] arguments)
        {
            Name = name;
            Examples = new List<Example>();
            RelatedLinks = new List<string>();

            if (_arguments == null) _arguments = new Dictionary<string, Argument>(arguments.Length == 0 ? 4 : arguments.Length);
            Add(arguments);
        }

        internal CommandInfo() : this(string.Empty, new Argument[0])
        {
        }

        internal Type Target;
        internal bool IsInternal;

        public int Count
        {
            get { return _arguments.Count; }
        }

        public bool HasArguments
        {
            get { return _arguments.Count > 0; }
        }

        public string Name { get; set; }

        public string ShellName { get; set; }

        public string Description { get; set; }

        public ICollection<Example> Examples { get; set; }

        public ICollection<string> RelatedLinks { get; set; }

        public Argument this[string memberName]
        {
            get { return _arguments.ContainsKey(memberName) ? _arguments[memberName] : null; }
        }

        public static CommandInfo ConvertFrom<T>()
        {
            return ConvertFrom(typeof(T));
        }

        public static CommandInfo ConvertFrom(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            MemberInfo[] publicMembers = GetMembers(type).ToArray();
            Argument[] arguments = new Argument[publicMembers.Length];
            var occupiedPosition = new bool[publicMembers.Length];

            // Creating the command arguments'.
            int index = 0; Argument arg;
            foreach (MemberInfo member in publicMembers)
            {
                arg = arguments[index++] = new Argument();
                arg.MemberName = member.Name;
                arg.DataType = (member.MemberType == MemberTypes.Property) ? ((PropertyInfo)member).PropertyType : ((FieldInfo)member).FieldType;

                foreach (var attribute in member.GetCustomAttributes())
                    switch (attribute)
                    {
                        case ParameterAttribute parameter:
                            arg.Kind = parameter.Kind;
                            arg.Aliases = parameter.Aliases;
                            arg.Default = parameter.Default;
                            arg.Position = parameter.Position;
                            if (!arg.IsRequired) arg.IsRequired = parameter.Required;
                            if (parameter.Position >= 0) occupiedPosition[parameter.Position] = true;
                            break;

                        case SummaryAttribute summary:
                            arg.Description = summary.Content;
                            break;

                        case RequiredAttribute required:
                            arg.IsRequired = true;
                            break;
                    }
            }

            // Sorting the un-positioned arguments.
            int pos = 0;
            for (index = 0; index < arguments.Length; index++)
            {
                arg = arguments[index];
                if (arg.Position < 0)
                {
                    while (occupiedPosition[pos] == true) pos++;
                    occupiedPosition[pos] = true;
                    arg.Position = pos;
                }
            }

            // Creating the command.
            var command = new CommandInfo(string.Empty, arguments) { Target = type };
            foreach (var attribute in type.GetCustomAttributes())
                switch (attribute)
                {
                    case CommandAttribute info:
                        command.Name = info.Name;
                        command.Description = info.HelpText;
                        break;

                    case ExampleAttribute example:
                        command.Examples.Add(new Example(example));
                        break;

                    case RelatedLinkAttribute link:
                        command.RelatedLinks.Add(link.Url);
                        break;

                    case SummaryAttribute summary:
                        command.Description = summary.Content;
                        break;
                }

            return command;
        }

        public object ToObject(Type type, bool useConstructor = false)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            ConstructorInfo[] constructors = type.GetConstructors();
            ConstructorInfo constructor = (from c in constructors
                                           where c.IsDefined(typeof(UseConstructorAttribute))
                                           select c).FirstOrDefault();

            if (useConstructor && constructor == null) return CreateInstance(type, constructors[0]);
            else if (useConstructor || constructor != null) return CreateInstance(type, constructor);
            else return CreateInstance(type);
        }

        public T ToObject<T>(bool useConstructor = false)
        {
            return (T)ToObject(typeof(T), useConstructor);
        }

        public void Add(params Argument[] arguments)
        {
            foreach (Argument arg in arguments)
            {
                arg.Command = this;
                _arguments.Add(arg.MemberName.ToLowerInvariant(), arg);
            }
        }

        public IEnumerator<Argument> GetEnumerator()
        {
            return _arguments.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal object ToObject(bool useConstructor = false)
        {
            return ToObject(Target, useConstructor);
        }

        protected string ToDebuggerDisplay()
        {
            return string.Format("{0} Count={1}", (string.IsNullOrEmpty(Name) ? "default" : Name), _arguments.Count);
        }

        #region Private Members

        private readonly IDictionary<string, Argument> _arguments;

        private static IEnumerable<MemberInfo> GetMembers(Type type)
        {
            return (from m in type.GetMembers()
                    where
                        m.IsDefined(typeof(IgnoreAttribute)) == false
                        &&
                        (m.MemberType == MemberTypes.Field || m.MemberType == MemberTypes.Property)
                    select m);
        }

        private object CreateInstance(Type type, ConstructorInfo constructor)
        {
            ParameterInfo[] parameters = constructor.GetParameters();
            var values = new object[parameters.Length];

            foreach (ParameterInfo parameter in parameters)
            {
                string key = parameter.Name.ToLowerInvariant();
                if (_arguments.ContainsKey(key))
                {
                    values[parameter.Position] = _arguments[key].GetValue();
                }
            }
            return constructor.Invoke(values);
        }

        private object CreateInstance(Type type)
        {
            object instance = Activator.CreateInstance(type);

            foreach (MemberInfo member in GetMembers(type))
            {
                string key = member.Name.ToLowerInvariant();
                if (_arguments.ContainsKey(key))
                    if (member is FieldInfo field)
                    {
                        if ((field.IsStatic && field.IsInitOnly) == false)
                        {
                            field.SetValue(instance, _arguments[key].GetValue());
                        }
                    }
                    else if (member is PropertyInfo property)
                    {
                        if (property.CanWrite)
                        {
                            property.SetValue(instance, _arguments[key].GetValue());
                        }
                    }
            }

            return instance;
        }

        #endregion Private Members
    }

    public class CommandInfo<T> : CommandInfo
    {
        public CommandInfo(string name) : base(name, new Argument[0])
        {
        }
    }
}