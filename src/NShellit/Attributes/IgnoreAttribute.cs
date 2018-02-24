using System;

namespace Acklann.NShellit.Attributes
{
    /// <summary>
    /// Instructs the <see cref="CommandInfo.ConvertFrom(Type)"/> method not to use the field/property member. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage((AttributeTargets.Field | AttributeTargets.Property), AllowMultiple = false, Inherited = true)]
    public sealed class IgnoreAttribute : Attribute
    {
    }
}