using Acklann.Poshley.Extensions;
using Acklann.Poshley.Fakes;
using Acklann.Poshley.Help;
using ApprovalTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace Acklann.Poshley.Tests
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void TryConvert_should_convert_string_to_given_type()
        {
            // Arrange
            var samples = new(string Arg, object Expected)[]
            {
                ("1", true),
                ("0", false),
                ("123", 123),
                ("1.23", 1.23f),
                ("abc", "abc"),
                ("true", true),
                ("false", false),
                ("8", FakeEnum.West),
                ("west", FakeEnum.West),
                ("1, 2, 3", new int[] {1, 2, 3}),
                ("a,b,c", new string[] { "a", "b", "c" }),
                ("2002-02-02", new DateTime(2002,2,2))
            };

            // Act
            foreach (var (Value, Expected) in samples)
            {
                if ("" == Value) Debugger.Break();
                var success = Parser.TryConvert(Value, Expected.GetType(), out object result);

                // Assert
                success.ShouldBeTrue();
                result.ShouldBe(Expected, $"could not convert '{Value}' to {Expected.GetType().Name}");
            }
        }

        [TestMethod]
        public void TryConvert_should_return_false_when_null_args_are_passed()
        {
            object result;
            Parser.TryConvert("john doe", null, out result).ShouldBeFalse();
            Parser.TryConvert(null, typeof(int), out result).ShouldBeFalse();
        }

        [TestMethod]
        public void TryMap_should_create_valid_command_from_command_list()
        {
            var sut = new Parser();
            sut.DefineCommand(string.Empty)
                .WithParameter<string[]>("Input")
                    .Alias("i", "Files")
                    .SetDefault(new string[0])
                .WithParameter<string>("Output")
                    .Alias("o", "Destination")
                    .SetDefault("default.csv")
                .WithParameter<bool>("Force")
                    .Alias("f")
                    .SetDefault(false);

            sut.DefineCommand("foo")
                .WithParameter("Gender", typeof(char))
                    .Alias("g")
                    .SetDefault('f')
                .WithParameter<DateTime>("Dob")
                    .Alias("d")
                    .SetDefault(new DateTime(2002, 02, 02));

            sut.DefineCommand("bar")
                .WithParameter<FakeEnum>("Direction")
                    .Alias("d")
                    .SetDefault(FakeEnum.North | FakeEnum.West);

            RunTryMapTest(sut, new string[]
            {
                "foo",
                "bar south",
                "bar -d NoRth",
                "f1 -f file.xml",
                "-f:off f2 out.xml",
                "f1,f2,f3 out.xml 0",
                "foo -d 2015-05-15 -g f",
                "-f -destination file.txt -i f1"
            });
        }

        [TestMethod]
        public void TryMap_should_return_errors_when_invalid_args_are_passed()
        {
            var sut = new Parser(new ParserSettings(), Mock.Create<IHelpBuilder>());
            sut.DefineCommand(string.Empty)
                .WithParameter<string>("Name")
                    .Alias("n")
                    .SetDefault("john")
                .WithParameter<int>("Age")
                    .Alias("a")
                    .SetDefault(18)
                .WithParameter<bool>("Avaiable")
                    .Alias("o")
                    .SetDefault(false);

            sut.DefineCommand("req")
                .WithParameter<int>("Id")
                .Required();

            RunTryMapTest(sut, new string[]
            {
                "req",
                "mary one -o",
                "mary 18 -o -na"
            }, expectErrors: true);
        }

        [TestMethod]
        public void TryMap_should_return_false_when_command_do_not_exist()
        {
            var mockHelpBuilder = Mock.Create<IHelpBuilder>();
            mockHelpBuilder.Arrange(x => x.PrintHelp(Arg.AnyString, Arg.IsAny<CommandInfo[]>()))
                .OccursOnce();

            var sut = new Parser(new ParserSettings(), mockHelpBuilder);
            sut.DefineCommand("commit")
                .WithParameter<string>("Message")
                .Alias("m")
                .SetDefault(string.Empty);

            // Act
            var failed = !sut.TryMap(new string[] { "deploy -m run" }, out CommandInfo result, out string error);

            // Assert
            failed.ShouldBeTrue();
            mockHelpBuilder.AssertAll();
            error.ShouldNotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public void TryMap_should_create_command_when_its_member_name_is_used()
        {
            var sut = new Parser();
            sut.DefineCommand<NonDecoratedCommand>("foo")
                .WithParameter(x=> x.NumericValue)
                .Required()
                .WithParameter(x=> x.TextValue)
                .SetDefault("gazy");

            RunTryMapTest(sut, new string[]
            {
                $"foo -{nameof(NonDecoratedCommand.NumericValue)} 321",
                $"foo -{nameof(NonDecoratedCommand.TextValue)} abc -{nameof(NonDecoratedCommand.NumericValue)} 123",
            });

        }

        [TestMethod]
        public void Map_should_invoke_the_right_callback_method()
        {
            // Arrange
            string[] args(string text) => text.Split(' ');

            string errorMsg = null;
            bool didNotCastHelpCommand = true, didNotCastVersionCommand = true;
            MutableCommand instance2 = null;
            NonDecoratedCommand instance1 = null;
            ImmutableCommand instance3 = default(ImmutableCommand);

            var mockHelpBuilder = Mock.Create<IHelpBuilder>();
            mockHelpBuilder.Arrange(x => x.PrintHelp(Arg.AnyString, Arg.IsAny<CommandInfo[]>()))
                .Occurs(3);

            mockHelpBuilder.Arrange(x => x.PrintVersion())
                .OccursOnce();

            // Act
            /* Internal */
            var successExitCode = new Parser(new ParserSettings(), mockHelpBuilder).Map<MutableCommand, ImmutableCommand, int>($"{MutableCommand.Name} -b 99 -a".Split(' '),
                (a) => { instance2 = a; return 0; },
                (b) => 0,
                (e) => 1);

            var errorExitCode = new Parser(new ParserSettings(), mockHelpBuilder).Map<ImmutableCommand, MutableCommand, int>(new string[0],
                (a) => 0,
                (b) => 0,
                (e) => { errorMsg = e; return 1; });

            (new Parser()).Map<MutableCommand, NonDecoratedCommand>(args("1"),
                (a) => { },
                (b) => { instance1 = b; },
                (e) => { });

            /* Public */
            (new Parser()).Map<object>(args("immutable 1"), new Type[] { typeof(MutableCommand), typeof(ImmutableCommand) },
                (s) => { instance3 = (ImmutableCommand)s; }, (e) => { });

            (new Parser(new ParserSettings() { EnableHelpCommand = true }, mockHelpBuilder)).Map<IFakeCommand>(args("help"), new Type[] { typeof(ImmutableCommand) },
                (s) => { didNotCastHelpCommand = false; }, (e) => { didNotCastHelpCommand = false; });

            (new Parser(new ParserSettings() { EnableHelpCommand = true }, mockHelpBuilder)).Map<IFakeCommand>(args("help immutable"), new Type[] { typeof(ImmutableCommand) },
                (s) => { didNotCastHelpCommand = false; }, (e) => { didNotCastHelpCommand = false; });

            (new Parser(new ParserSettings() { EnableVersionCommand = true }, mockHelpBuilder)).Map<IFakeCommand>(args("version"), new Type[] { typeof(ImmutableCommand) },
                (s) => { didNotCastVersionCommand = false; }, (e) => { didNotCastVersionCommand = false; });

            var nullErrorExitCode = new Parser().Map<IFakeCommand, int>(args("invalid -e 109"), new Type[] { },
                (s) => 0, null);

            // Assert
            errorExitCode.ShouldBe(1);
            successExitCode.ShouldBe(0);
            errorMsg.ShouldNotBeNullOrEmpty();
            nullErrorExitCode.ShouldBe(default(int));

            instance1.ShouldNotBeNull();
            instance2.ShouldNotBeNull();
            instance3.Id.ShouldBe(1);
            instance3.Dob.ShouldBe(default(DateTime));

            didNotCastHelpCommand.ShouldBeTrue();
            didNotCastVersionCommand.ShouldBeTrue();

            mockHelpBuilder.AssertAll();
        }

        private static void RunTryMapTest(Parser parser, string[] samples, bool expectErrors = false)
        {
            var results = new List<(bool Passed, string Error, string In, string Out)>();
            Func<object, string> get = (x) => ((x?.GetType()?.IsArray ?? false) ? string.Join(",", (object[])x) : Convert.ToString(x ?? string.Empty));

            // Act
            foreach (var item in samples)
            {
                string[] arg = item?.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var success = parser.TryMap(arg, out CommandInfo command, out string error);

                results.Add((success, error, item, string.Join(Environment.NewLine, command.Select(
                    (x) => string.Format("{0} {1} = {2}", x.DataType.Name, x.MemberName, (x.Value == null ? $"(default: {x.Default})" : get(x.Value)))))));
            }

            // Assert
            string template = @"
args: {0}

{1}
{2}

=========================
";
            Approvals.VerifyAll(results, x => string.Format(template, x.In, (x.Passed ? "PASSED" : $"ERROR: {x.Error}"), x.Out).Trim());
            results.ShouldAllBe(x => x.Passed == !expectErrors);
        }
    }
}