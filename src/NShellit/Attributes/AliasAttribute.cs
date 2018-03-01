using System;

namespace Acklann.NShellit.Attributes
{
    /// <summary>
    /// Defines alternate names for a command and parameters. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage((AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field), AllowMultiple = false, Inherited = true)]
    public sealed class AliasAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AliasAttribute"/> class.
        /// </summary>
        /// <param name="aliases">The aliases.</param>
        public AliasAttribute(params string[] aliases)
        {
            Aliases = aliases;
        }

        /// <summary>
        /// The alternate names.
        /// </summary>
        public readonly string[] Aliases;
    }
}