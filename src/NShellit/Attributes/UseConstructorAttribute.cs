using System;

namespace Acklann.NShellit.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
    public sealed class UseConstructorAttribute : Attribute
    {
    }
}