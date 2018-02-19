using System;

namespace Acklann.NShellit.Attributes
{
    [AttributeUsage((AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Field | AttributeTargets.Property), AllowMultiple = false, Inherited = false)]
    public sealed class SummaryAttribute : Attribute
    {
        public SummaryAttribute(string content)
        {
            Content = content;
        }

        public readonly string Content;
    }
}