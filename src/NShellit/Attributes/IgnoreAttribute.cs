using System;

namespace Acklann.NShellit.Attributes
{
    [AttributeUsage((AttributeTargets.Field | AttributeTargets.Property), AllowMultiple = false, Inherited = true)]
    public sealed class IgnoreAttribute : Attribute
    {
    }
}