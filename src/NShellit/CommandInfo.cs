using Acklann.NShellit.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Acklann.NShellit
{
    /// <summary>
    /// Represents a CLI command.
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{ToDebuggerDisplay()}")]
    public class CommandInfo : IEnumerable<Argument>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandInfo" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="arguments">The arguments.</param>
        /// <exception cref="ArgumentNullException">name is null.</exception>
        public CommandInfo(string name, params Argument[] arguments)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Examples = new List<Example>();
            RelatedLinks = new List<string>();

            if (_arguments == null) _arguments = new Dictionary<string, Argument>(arguments.Length == 0 ? 4 : arguments.Length);
            Add(arguments);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandInfo"/> class.
        /// </summary>
        internal CommandInfo() : this(string.Empty, new Argument[0])
        {
        }

        internal Type Target;
        internal bool IsInternal;

        /// <summary>
        /// Gets the number arguments.
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get { return _arguments.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has arguments.
        /// </summary>
        /// <value><c>true</c> if this instance has arguments; otherwise, <c>false</c>.</value>
        public bool HasArguments
        {
            get { return _arguments.Count > 0; }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the cmdlet.
        /// </summary>
        /// <value>The cmdlet.</value>
        public string Cmdlet { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the examples.
        /// </summary>
        /// <value>The examples.</value>
        public ICollection<Example> Examples { get; set; }

        /// <summary>
        /// Gets or sets the related links.
        /// </summary>
        /// <value>The related links.</value>
        public ICollection<string> RelatedLinks { get; set; }

        /// <summary>
        /// Gets the <see cref="Argument"/> with the specified member name.
        /// </summary>
        /// <param name="memberName">Name of the member.</param>
        /// <returns>Argument.</returns>
        public Argument this[string memberName]
        {
            get { return _arguments.ContainsKey((memberName ?? string.Empty)) ? _arguments[memberName] : null; }
        }

        /// <summary>
        /// Converts the specified <typeparamref name="T"/> to a <see cref="CommandInfo"/> object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>A <see cref="CommandInfo"/> instance.</returns>
        public static CommandInfo ConvertFrom<T>()
        {
            return ConvertFrom(typeof(T));
        }

        /// <summary>
        /// Converts the specified <see cref="Type"/> to a <see cref="CommandInfo"/> object.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>A <see cref="CommandInfo"/> instance.</returns>
        /// <exception cref="ArgumentNullException">type is null.</exception>
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
                            arg.Description = summary.Summary;
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
                        command.Description = info.Summary;
                        break;

                    case ExampleAttribute example:
                        command.Examples.Add(new Example(example));
                        break;

                    case RelatedLinkAttribute link:
                        command.RelatedLinks.Add(link.Url);
                        break;

                    case SummaryAttribute summary:
                        command.Description = summary.Summary;
                        break;
                }

            return command;
        }

        /// <summary>
        /// Creates a new instance of the specified <see cref="Type"/> using this instance <see cref="Argument"/>s.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="useConstructor">if set to <c>true</c> the type's constructor marked with the <see cref="Attributes.UseConstructorAttribute"/> will be used to create the instance.</param>
        /// <returns>A new instance of the specified <see cref="Type"/>.</returns>
        /// <exception cref="ArgumentNullException">type is null.</exception>
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

        /// <summary>
        /// Creates a new instance of the specified <see cref="Type"/> using this instance <see cref="Argument"/>s.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="useConstructor">if set to <c>true</c> the type's constructor marked with the <see cref="Attributes.UseConstructorAttribute"/> will be used to create the instance.</param>
        /// <returns>A new instance of the specified <see cref="Type"/>.</returns>
        public T ToObject<T>(bool useConstructor = false)
        {
            return (T)ToObject(typeof(T), useConstructor);
        }

        /// <summary>
        /// Adds the specified arguments.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        public void Add(params Argument[] arguments)
        {
            foreach (Argument arg in arguments)
            {
                arg.Command = this;
                _arguments.Add(arg.MemberName.ToLowerInvariant(), arg);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<Argument> GetEnumerator()
        {
            return _arguments.Values.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal object ToObject(bool useConstructor = false)
        {
            return ToObject(Target, useConstructor);
        }

        /// <summary>
        /// Determines how a class or field is displayed in the debugger variable windows.
        /// </summary>
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

    /// <summary>
    /// Represents a CLI command.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Acklann.NShellit.CommandInfo" />
    public class CommandInfo<T> : CommandInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandInfo{T}"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public CommandInfo(string name) : base(name, new Argument[0])
        {
        }
    }
}