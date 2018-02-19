using System;

namespace Acklann.NShellit.Attributes
{
    [AttributeUsage((AttributeTargets.Property | AttributeTargets.Field), AllowMultiple = false, Inherited = true)]
    public sealed class ParameterAttribute : Attribute
    {
        public ParameterAttribute(params string[] aliases)
        {
            Position = -1;
            Aliases = aliases;
        }

        public readonly string[] Aliases;

        public int Position { get; set; }

        public string HelpText { get; set; }

        public object Default { get; set; }

        public string Kind { get; set; }

        public bool Required { get; set; }

        public bool ValueFromPipeline { get; set; }
    }
}