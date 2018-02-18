using System;

namespace Acklann.Poshley.Attributes
{
    [AttributeUsage((AttributeTargets.Field | AttributeTargets.Property), AllowMultiple = false, Inherited = true)]
    public sealed class RequiredAttribute : Attribute
    {
    }
}