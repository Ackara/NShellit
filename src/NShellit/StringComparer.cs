using System;
using System.Collections.Generic;

namespace Acklann.NShellit
{
    internal class StringComparer : IEqualityComparer<string>
    {
        internal static readonly IEqualityComparer<string> IgnoreCase = new StringComparer();

        public bool Equals(string x, string y) => (x?.Equals(y, StringComparison.InvariantCultureIgnoreCase) ?? false);

        public int GetHashCode(string obj) => obj.GetHashCode();
    }
}