using Acklann.NShellit.Extensions;
using Acklann.NShellit.Fakes;
using Acklann.NShellit.Help;
using ApprovalTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acklann.NShellit.Tests
{
    [TestClass]
    public class HelpBuildTest
    {
        [TestMethod]
        public void PrintHelp_should_show_menu_for_all_commands()
        {
            // Arrange
            var c1 = new CommandInfo("get-childitem") { Description = "This is the add description." };
            var c2 = new CommandInfo("version") { Description = "This is the version description." };
            var c3 = new CommandInfo("help") { Description = "This is the help description" };

            var sut = new EditableHelpBuilder(true);
            EditableHelpBuilder.HeaderFormatString = nameof(HelpBuildTest);

            // Act
            sut.PrintHelp(new CommandInfo[] { c1, c2, c3 });

            // Assert
            Approvals.Verify(sut.Debug);
        }

        [TestMethod]
        public void PrintHelp_should_show_menu_for_one_command()
        {
            // Arrange
            var command = new CommandInfo("commit");
            command.WithParameter<string>("Author")
                .SetDescription("This is the author name.")
                .SetDefault("john");

            command.WithParameter<string>("Message")
                .Alias("m", "message", "msg")
                .SetDescription("This is a message.")
                .Required();

            command.WithParameter<bool>("Append")
                .Alias("a", "append")
                .SetDescription("This is a boolean.");

            command.WithParameter<Sex>("Date")
                .Alias("d")
                .SetDescription("The commit date");

            command.AddExample("commit -m foobar", "This is an example.");
            command.AddExample("commit -a", "This is another example.");
            command.AddLinks("http://github.com/Ackara");
            command.AddLinks("http://codeplex.com/Ackara");

            var sut = new EditableHelpBuilder(true);
            EditableHelpBuilder.HeaderFormatString = "{2}";

            // Act
            sut.PrintHelp(command);

            // Assert
            Approvals.Verify(sut.Debug);
        }

        [TestMethod]
        public void PrintHelp_should_show_error()
        {
            // Arrange
            var sut = new EditableHelpBuilder(true) { Error = "Bad Option: -force" };

            var command = new CommandInfo("commit");
            command.WithParameter<string>("Message")
                .Alias("m", "message", "msg")
                .SetDescription("This is a message.")
                .Required();

            // Act
            sut.PrintHelp(command);

            // Assert
            Approvals.Verify(sut.Debug);
        }
    }
}