using Acklann.NShellit.Extensions;
using Acklann.NShellit.Fakes;
using Acklann.NShellit.Generators;
using ApprovalTests;
using ApprovalTests.Namers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Acklann.NShellit.Tests
{
    [TestClass]
    public class PackageGeneratorTest
    {
        [TestMethod]
        public void PSModuleGenerator_should_create_a_publishable_powershell_module()
        {
            var sut = new PSModuleGenerator();
            RunPackageTest(sut, filesToExamine: () => (from f in Directory.EnumerateFiles(sut.PackageDirectory, "*", SearchOption.AllDirectories)
                                                       where Path.GetExtension(f) == ".ps1" /*|| Path.GetExtension(f) == ".psd1"*/
                                                       select f));
        }

        //[TestMethod]
        public void NodeModuleGenerator_should_create_a_publishable_powershell_module()
        {
            IShellWrapper sut = null;
            RunPackageTest(sut, filesToExamine: () => (from f in Directory.EnumerateFiles(sut.PackageDirectory, "*", SearchOption.AllDirectories)
                                                       where Path.GetExtension(f) == ".js"
                                                       select f));
        }

        private static IEnumerable<CommandInfo> GetCommandList()
        {
            var one = new CommandInfo<NonDecoratedCommand>("one") { Cmdlet = "Write-Foo" };
            one.SetDescription("This is a good command.")
                .WithParameter(x => x.NumericValue)
                    .SetDescription("An id value.")
                    .Required()
                .WithParameter(x => x.PrecisionValue, "coordinate")
                    .SetDescription("An number value.")
                    .SetAlias("point")
                    .SetDefault(0)
                .WithParameter(x => x.CharValue)
                    .SetDescription("A char value.")
                    .SetAlias("c")
                    .SetDefault('c')
                .WithParameter(x => x.Collection)
                    .SetDescription("An array")
                    .SetAlias("l", "list")
                    .SetDefault(new string[] { "a", "b", "c" })
                .WithParameter(x => x.DateValue)
                    .SetDescription("A date value.")
                    .SetAlias("d", "date")
                    .SetDefault(DateTime.Now)
                .WithParameter(x => x.EnumValue)
                    .SetDescription("A fake value.")
                    .SetAlias("e")
                    .SetDefault(FakeEnum.North);

            one.AddLinks("Write-Host");
            one.AddExample("Write-Foo", "This does something.");
            one.AddExample("Write-Foo", "This does something.", true);
            
            var two = new CommandInfo("two");
            two.SetDescription("This is a synopsis.")
                .WithParameter<string>("Id")
                .SetDescription("An id value.")
                .Required()
                .WithParameter("Contact", typeof(string), "phone")
                .SetDescription("A phone number")
                .SetAlias("tel");

            return new CommandInfo[] { one, two };
        }

        private static void RunPackageTest(IShellWrapper sut, Func<IEnumerable<string>> filesToExamine)
        {
            //  Act
            sut.GeneratePackage(GetCommandList(), typeof(PackageGeneratorTest).Assembly.Location);
            var package = new DirectoryInfo(sut.PackageDirectory);
            var fileList = (from f in package.GetFiles("*", SearchOption.AllDirectories)
                            select f.FullName.Replace(package.FullName, string.Empty));

            // Assert
            package.Exists.ShouldBeTrue();

            using (ApprovalResults.ForScenario("fileList"))
            {
                Approvals.VerifyAll(fileList, "PS");
            }

            foreach (string file in filesToExamine())
            {
                using (ApprovalResults.ForScenario(Path.GetFileNameWithoutExtension(file)))
                {
                    Approvals.Verify(File.ReadAllText(file));
                }
            }
        }
    }
}