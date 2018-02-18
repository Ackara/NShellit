namespace Acklann.Poshley
{
    public struct Example
    {
        public Example(Attributes.ExampleAttribute example) : this(example.Command, example.Explanation)
        {
        }

        public Example(string command, string description)
        {
            Command = command;
            this.Description = description;
        }

        public string Command { get; }

        public string Description { get; }

        public override string ToString()
        {
            return Command;
        }
    }
}