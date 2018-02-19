using Acklann.NShellit.Fakes;
using ApprovalTests;
using ApprovalTests.Namers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Shouldly;
using System;

namespace Acklann.NShellit.Tests
{
    [TestClass]
    public class CommandInfoTest
    {
        [TestMethod]
        public void ConvertFrom_should_create_command_from_a_type()
        {
            foreach (var sample in new Type[]
            {
                typeof(MutableCommand),
                typeof(ImmutableCommand),
                typeof(NonDecoratedCommand)
            })
            {
                using (ApprovalResults.ForScenario(sample.Name))
                {
                    var result = CommandInfo.ConvertFrom(sample);
                    Approvals.VerifyJson(result.ToJson(showType: true));
                }
            }
        }

        [TestMethod]
        public void ConvertFrom_should_threw_exception_when_null_is_passed()
        {
            Type type = null;
            Should.Throw<ArgumentNullException>(() => { CommandInfo.ConvertFrom(type); });
        }

        [TestMethod]
        public void ToObject_should_convert_command_to_mutable_object()
        {
            // Arrange
            var sut = new CommandInfo(MutableCommand.Name,
                new Argument("Rogue") { Value = "1" },
                new Argument(nameof(MutableCommand.Collection), typeof(string[])) { Value = new string[] { "x", "y", "z" } },
                new Argument(nameof(MutableCommand.Switch), typeof(bool)) { Value = true },
                new Argument(nameof(MutableCommand.CharValue), typeof(char)) { Value = 'X' },
                new Argument(nameof(MutableCommand.NumericValue), typeof(int)) { Value = 101 },
                new Argument(nameof(MutableCommand.DateValue), typeof(DateTime)) { Value = DateTime.Parse("2005-05-05 05:05:05") },
                new Argument(nameof(MutableCommand.TextValue)) { Value = "some text" },
                new Argument(nameof(MutableCommand.EnumValue), typeof(FakeEnum)) { Value = FakeEnum.South }
            );

            // Act
            var result = sut.ToObject<MutableCommand>();

            // Assert
            Approvals.VerifyJson(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        [TestMethod]
        public void ToObject_should_convert_command_to_immutable_object()
        {
            // Arrange
            var sut = new CommandInfo(string.Empty,
                new Argument("Rouge") { Value = "non existing" },
                new Argument(nameof(ImmutableCommand.Id), typeof(int)) { Value = 123 },
                new Argument(nameof(ImmutableCommand.Name), typeof(string)) { Value = "John Doe" },
                new Argument(nameof(ImmutableCommand.Dob), typeof(DateTime)) { Value = DateTime.Parse("2016-06-14") },
                new Argument(nameof(ImmutableCommand.Category), typeof(FakeEnum)) { Value = FakeEnum.North | FakeEnum.East },
                new Argument(nameof(ImmutableCommand.AccessCodes), typeof(int[])) { Value = new int[] { 1, 2, 3, 5, 8, 13 } }
                );

            // Act
            var result = sut.ToObject<ImmutableCommand>();

            // Assert
            Approvals.VerifyJson(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        [TestMethod]
        public void ToObject_should_convert_command_to_non_decorated_object()
        {
            // Arrange
            var sut = new CommandInfo(string.Empty,
            new Argument(nameof(NonDecoratedCommand.Switch), typeof(bool)) { Value = true },
            new Argument(nameof(NonDecoratedCommand.CharValue), typeof(char)) { Value = 'c' },
            new Argument(nameof(NonDecoratedCommand.NumericValue), typeof(int)) { Value = 123 },
            new Argument(nameof(NonDecoratedCommand.TextValue), typeof(string)) { Value = "a string" },
            new Argument(nameof(NonDecoratedCommand.PrecisionValue), typeof(float)) { Value = 1.23f },
            new Argument(nameof(NonDecoratedCommand.EnumValue), typeof(FakeEnum)) { Value = FakeEnum.East },
            new Argument(nameof(NonDecoratedCommand.Collection), typeof(string[])) { Value = new string[] { "abc", "xyz" } });

            // Act
            var result = sut.ToObject<NonDecoratedCommand>();

            // Assert
            Approvals.VerifyJson(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        [TestMethod]
        public void ToObject_should_threw_exception_when_null_is_passed()
        {
            Type type = null;
            var sut = new CommandInfo("foogazy");
            Should.Throw<ArgumentNullException>(() => { sut.ToObject(type); });
        }
    }
}