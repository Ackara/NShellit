using System;

namespace Acklann.Poshley.Attributes
{
    [AttributeUsage((AttributeTargets.Class | AttributeTargets.Struct), Inherited = false, AllowMultiple = false)]
    public sealed class CommandAttribute : Attribute
    {
        public CommandAttribute() : this(string.Empty, string.Empty)
        {
        }

        public CommandAttribute(string name) : this(name, string.Empty)
        {
        }

        public CommandAttribute(string name, string helpText)
        {
            Name = name;
            HelpText = helpText;
        }

        public string Name;

        public string HelpText { get; set; }

        public string Cmdlet { get; set; }
    }
}