using System;
using System.Linq;

namespace Acklann.NShellit
{
    /// <summary>
    /// Represents a command-line argument of a <see cref="CommandInfo"/>.
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{ToDebuggerDisplay()}")]
    public class Argument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Argument"/> class.
        /// </summary>
        public Argument() : this(string.Empty, typeof(string))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Argument"/> class.
        /// </summary>
        /// <param name="memberName">The name of the field/property this instance is associated with.</param>
        public Argument(string memberName) : this(memberName, typeof(string))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Argument" /> class.
        /// </summary>
        /// <param name="memberName">The name of the field/property this instance is associated with.</param>
        /// <param name="dataType">The data type.</param>
        public Argument(string memberName, Type dataType)
        {
            Position = -1;
            DataType = dataType;
            MemberName = memberName;
            Description = string.Empty;
        }

        internal CommandInfo Command;

        /// <summary>
        /// Gets the preferred name of this instance.
        /// </summary>
        /// <value>The first value of <see cref="Aliases"/> if any; otherwise the <see cref="Position"/>.</value>
        public string Name
        {
            get { return Aliases?.Length > 0 ? ($"-{Aliases[0]}") : $"[position {Position}]"; }
        }

        /// <summary>
        /// Gets the long name of this instance.
        /// </summary>
        /// <value>The max value of <see cref="Aliases"/> if any; otherwise the <see cref="Position"/>.</value>
        public string LongName
        {
            get { return (Aliases?.Length > 0 ? Aliases.Max() : $"[position {Position}]"); }
        }

        /// <summary>
        /// Gets the short name of this instance.
        /// </summary>
        /// <value>The min value of <see cref="Aliases"/> if any; otherwise the <see cref="Position"/>.</value>
        public string ShortName
        {
            get { return (Aliases?.Length > 0 ? Aliases.Min() : $"[position {Position}]"); }
        }

        /// <summary>
        /// Gets or sets the kind; A friendly name that describes this instance data type.
        /// </summary>
        /// <value>A friendly name that describes this instance data type.</value>
        public string Kind
        {
            get
            {
                if (string.IsNullOrEmpty(_valueKind))
                {
                    if (DataType == typeof(bool)) _valueKind = "switch";
                    else if (DataType.IsEnum) _valueKind = string.Join("|", DataType.GetEnumNames());
                    else _valueKind = DataType.Name;
                }

                return _valueKind;
            }
            set { _valueKind = value; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance <see cref="Aliases"/> is null or empty.
        /// </summary>
        /// <value><c>true</c> if this instance <see cref="Aliases"/> is null or empty; otherwise, <c>false</c>.</value>
        public bool HasAlias
        {
            get { return Aliases?.Length > 0; }
        }

        /// <summary>
        /// Gets or sets the list of acceptable names for this instance.
        /// </summary>
        /// <value>The list of acceptable names.</value>
        public string[] Aliases { get; set; }

        /// <summary>
        /// Gets or sets the name of the field/property this instance is associated with.
        /// </summary>
        /// <value>The name of the member.</value>
        public string MemberName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        //

        /// <summary>
        /// Gets or sets the data type.
        /// </summary>
        /// <value>The type of the data.</value>
        public Type DataType { get; set; }

        /// <summary>
        /// Gets or sets the default value of this instance.
        /// </summary>
        /// <value>The default value.</value>
        public object Default { get; set; }

        /// <summary>
        /// Gets or sets the value of this instance.
        /// </summary>
        /// <value>The value.</value>
        public object Value { get; set; }

        //

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        public int Position { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is required.
        /// </summary>
        /// <value><c>true</c> if this instance is required; otherwise, <c>false</c>.</value>
        public bool IsRequired { get; set; }

        /// <summary>
        /// Gets this instance <see cref="Value"/> if not null; otherwise <see cref="Default"/>.
        /// </summary>
        /// <returns>The value.</returns>
        public object GetValue()
        {
            return (Value ?? Default);
        }

        #region Private Members

        private string _valueKind;

        private string ToDebuggerDisplay()
        {
            return string.Format("[{0} <{1}>] = '{2}'",
                (Aliases?.Length > 0 ? $"-{Aliases[0]}" : $"pos:{Position}"),
                DataType.Name,
                (Value ?? Default));
        }

        #endregion Private Members
    }

    /// <summary>
    /// Represents a command-line argument of a <see cref="CommandInfo"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Acklann.NShellit.Argument" />
    public class Argument<T> : Argument { internal new CommandInfo<T> Command => (CommandInfo<T>)base.Command; }
}