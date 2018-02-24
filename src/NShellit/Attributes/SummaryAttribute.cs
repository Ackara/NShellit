using System;

namespace Acklann.NShellit.Attributes
{
    /// <summary>
    /// Defines a brief summary of a command or parameter. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage((AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Field | AttributeTargets.Property), AllowMultiple = false, Inherited = false)]
    public sealed class SummaryAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryAttribute" /> class.
        /// </summary>
        /// <param name="summary">The summary.</param>
        public SummaryAttribute(string summary)
        {
            Summary = summary;
        }

        /// <summary>
        /// The summary
        /// </summary>
        public readonly string Summary;
    }
}