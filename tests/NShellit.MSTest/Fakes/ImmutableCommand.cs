using Acklann.NShellit.Attributes;
using System;

namespace Acklann.NShellit.Fakes
{
    [Command("immutable", Cmdlet = "Start-Foo")]
    [Example("fake.exe john 117")]
    public struct ImmutableCommand : IFakeCommand
    {
        public ImmutableCommand(int id)
        {
            Id = id;
            Name = "null";
            Dob = default(DateTime);
            Category = FakeEnum.North;
            AccessCodes = new int[0];
        }

        [UseConstructor]
        public ImmutableCommand(int id, string name, DateTime dob, FakeEnum category, params int[] accessCodes)
        {
            Id = id;
            Dob = dob;
            Name = name;
            Category = category;
            AccessCodes = accessCodes;
        }

        [Parameter]
        public readonly int[] AccessCodes;

        [Parameter]
        public int Id { get; }

        [Parameter]
        public string Name { get; }

        [Parameter]
        public DateTime Dob { get; }

        [Parameter]
        public FakeEnum Category { get; }
    }
}