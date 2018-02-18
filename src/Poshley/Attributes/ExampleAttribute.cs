using System;

namespace Acklann.Poshley.Attributes
{
    [AttributeUsage((AttributeTargets.Class | AttributeTargets.Struct), AllowMultiple = true, Inherited = true)]
    public sealed class ExampleAttribute : Attribute
    {
        public ExampleAttribute(string command) : this(command, string.Empty)
        {
        }

        public ExampleAttribute(string command, string explanation)
        {
            Command = command;
            Explanation = explanation;
        }

        public readonly string Command;

        public string Explanation { get; set; }
    }
}