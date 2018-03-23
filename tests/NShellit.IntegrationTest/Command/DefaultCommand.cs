using Acklann.NShellit.Attributes;
using System;

namespace Acklann.NShellit.Command
{
    [Command("")]
    public class DefaultCommand : ICommand
    {
        [Parameter('n', "num")]
        [Summary("This is a number.")]
        public int Number { get; set; }

        public int Execute()
        {
            Console.WriteLine("Execute default.");
            return 0;
        }
    }
}