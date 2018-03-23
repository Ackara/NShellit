using Acklann.NShellit.Command;
using Acklann.NShellit.Extensions;
using System;
using System.Linq;

namespace Acklann.NShellit
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            var commandList = (from t in typeof(ICommand).Assembly.GetExportedTypes()
                               where !t.IsInterface && !t.IsAbstract && typeof(ICommand).IsAssignableFrom(t)
                               select t).ToArray();

            var sut = new Parser();
            int exitCode = sut.Map<ICommand, int>(args, commandList,
                (command) => command.Execute(),
                (error) => 1);
#if DEBUG
            Console.WriteLine($"exit-code: {exitCode}");
            Console.WriteLine("press any key to exit ...");
            Console.ReadKey();
#endif
            return exitCode;
        }
    }
}