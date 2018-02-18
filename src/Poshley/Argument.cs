using System;
using System.Linq;

namespace Acklann.Poshley
{
    [System.Diagnostics.DebuggerDisplay("{ToDebuggerDisplay()}")]
    public class Argument
    {
        public Argument() : this(string.Empty, typeof(string))
        {
        }

        public Argument(string memberName) : this(memberName, typeof(string))
        {
        }

        public Argument(string memberName, Type dataType)
        {
            Position = -1;
            DataType = dataType;
            MemberName = memberName;
            Description = string.Empty;
        }

        internal CommandInfo Command;

        public string Name
        {
            get { return Aliases?.Length > 0 ? ($"-{Aliases[0]}") : $"[position {Position}]"; }
        }

        public string LongName
        {
            get { return (Aliases?.Length > 0 ? Aliases.Max() : $"[position {Position}]"); }
        }

        public string ShortName
        {
            get { return (Aliases?.Length > 0 ? Aliases.Min() : $"[position {Position}]"); }
        }

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

        public bool HasAlias
        {
            get { return Aliases?.Length > 0; }
        }

        public string[] Aliases { get; set; }
        public string MemberName { get; set; }
        public string Description { get; set; }

        public Type DataType { get; set; }
        public object Default { get; set; }
        public object Value { get; set; }

        public int Position { get; set; }
        public bool IsRequired { get; set; }

        public object GetValue()
        {
            return (Value ?? Default);
        }

        protected string ToDebuggerDisplay()
        {
            return string.Format("[{0} <{1}>] = '{2}'",
                (Aliases?.Length > 0 ? $"-{Aliases[0]}" : $"pos:{Position}"),
                DataType.Name,
                (Value ?? Default));
        }

        #region Private Members

        private string _valueKind;

        #endregion Private Members
    }

    public class Argument<T> : Argument { internal new CommandInfo<T> Command => (CommandInfo<T>)base.Command; }
}