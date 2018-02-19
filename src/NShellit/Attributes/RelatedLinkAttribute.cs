using System;

namespace Acklann.NShellit.Attributes
{
    [AttributeUsage((AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct), AllowMultiple = true, Inherited = true)]
    public sealed class RelatedLinkAttribute : Attribute
    {
        public RelatedLinkAttribute(string url)
        {
            Url = url;
        }

        public readonly string Url;
    }
}