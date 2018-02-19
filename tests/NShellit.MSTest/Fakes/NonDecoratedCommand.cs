using System;

namespace Acklann.NShellit.Fakes
{
    public class NonDecoratedCommand : IFakeCommand
    {
        public bool Switch;

        public int NumericValue { get; set; }

        public char CharValue { get; set; }

        public string TextValue { get; set; }

        public DateTime DateValue { get; set; }

        public FakeEnum EnumValue { get; set; }

        public float PrecisionValue { get; set; }

        public string[] Collection { get; set; }
    }
}