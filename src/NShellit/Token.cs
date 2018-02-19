namespace Acklann.NShellit
{
    internal struct Token
    {
        public Token(int pos, string name, string value)
        {
            Position = pos;
            
            string[] parts = name.Split(':');
            Value = (parts.Length > 1 ? parts[1] : value);
            IsSwitch = parts.Length > 1;
            Name = parts[0];
        }

        public bool IsSwitch;
        public readonly int Position;
        public readonly string Name, Value;
        public bool HasName => !string.IsNullOrEmpty(Name);

        public override string ToString()
        {
            return (HasName ? $"-{Name} {Value}" : $"pos:{Position} {Value}");
        }
    }
}