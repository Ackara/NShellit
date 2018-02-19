using Acklann.NShellit.Attributes;
using System;

namespace Acklann.NShellit.Fakes
{
    [Command(Name, HelpText = "A good mutable command")]
    [Example("fake.exe -id 100", "Does something cool.")]
    [Example("fake.exe -id 125 -b", "A good explanation.")]
    [RelatedLink("https://www.poshly.org/documentation/command/fake")]
    public class MutableCommand : IFakeCommand
    {
        [Ignore]
        public const string Name = "mutable", Id = "id", Date = "date";

        [Parameter("a", HelpText = "A boolean value", Position = 1)]
        [Summary("A boolean value")]
        public bool Switch;

        
        [Required, Parameter("b", Id, HelpText = "A integer value.", Position = 3)]
        [Summary("A integer value.")]
        public int NumericValue { get; set; }

        [Parameter("c", HelpText = "A char value.", Position = 5)]
        [Summary("A char value.")]
        public char CharValue { get; set; }

        [Parameter("d", "text", HelpText = "A string value")]
        [Summary("A string value")]
        public string TextValue { get; set; }

        [Parameter("e", Date, HelpText = "A date value.")]
        [Summary("A date value.")]
        public DateTime DateValue { get; set; }

        [Parameter("f", HelpText = "An enum value", Default = (FakeEnum.East | FakeEnum.South))]
        [Summary("An enum value")]
        public FakeEnum EnumValue { get; set; }

        [Parameter("g", HelpText = "A float value.")]
        [Summary("A float value.")]
        public float PrecisionValue { get; set; }

        [Parameter("h", HelpText = "A collection.")]
        [Summary("A collection.")]
        public string[] Collection { get; set; }
    }
}