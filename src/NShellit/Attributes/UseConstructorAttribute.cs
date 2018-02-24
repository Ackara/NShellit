using System;

namespace Acklann.NShellit.Attributes
{
    /// <summary>
    /// Instructs the <see cref="CommandInfo.ToObject(Type, bool)"/> method to object's specifed constructor. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
    public sealed class UseConstructorAttribute : Attribute
    {
    }
}