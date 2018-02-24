using System;

namespace Acklann.NShellit.Attributes
{
    /// <summary>
    /// Indicates that a fied/property is required. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage((AttributeTargets.Field | AttributeTargets.Property), AllowMultiple = false, Inherited = true)]
    public sealed class RequiredAttribute : Attribute
    {
    }
}