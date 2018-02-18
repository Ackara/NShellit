using System;

namespace Acklann.Poshley.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
    public sealed class UseConstructorAttribute : Attribute
    {
    }
}