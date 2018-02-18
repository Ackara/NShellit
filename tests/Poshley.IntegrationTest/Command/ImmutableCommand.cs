using Acklann.Poshley.Attributes;
using System;

namespace Poshley.IntegrationTest.Command
{
    [Command("immutable", Cmdlet = "Invoke-Transpile")]
    [Summary("A command with 1 constructor.")]
    [Example("immutable a,b,c", Explanation = "This example is a good one.")]
    [RelatedLink("http://codeplex.com/Ackara")]
    [RelatedLink("http://gitbub.com/Ackara")]
    public class ImmutableCommand : ICommand
    {
        [UseConstructor]
        public ImmutableCommand(string outFile, bool overwrite, params string[] inputFiles)
        {
            OutFile = outFile;
            Overwrite = overwrite;
            InputFiles = inputFiles;
        }

        [Parameter("f", "force")]
        [Summary("A switch")]
        public readonly bool Overwrite;

        [Parameter("o", "output", Position = 0)]
        [Summary("A string value.")]
        public readonly string OutFile;

        [Required, Parameter("i", "input")]
        [Summary("An array of strings.")]
        public readonly string[] InputFiles;

        public int Execute()
        {
            Console.WriteLine(string.Format(@"{{
    ""array"": ""{0}"",
    ""string"": ""{1}"",
    ""bool"": ""{2}""
}}",
                string.Join(", ", InputFiles), OutFile, Overwrite));
            return 0;
        }
    }
}