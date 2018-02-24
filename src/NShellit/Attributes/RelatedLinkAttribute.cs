using System;

namespace Acklann.NShellit.Attributes
{
    /// <summary>
    /// Defines a uri for a command. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage((AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct), AllowMultiple = true, Inherited = true)]
    public sealed class RelatedLinkAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RelatedLinkAttribute"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        public RelatedLinkAttribute(string url)
        {
            Url = url;
        }

        /// <summary>
        /// The URL.
        /// </summary>
        public readonly string Url;
    }
}