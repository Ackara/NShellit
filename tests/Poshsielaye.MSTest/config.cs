using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acklann.Project
{
	public static partial class TestDataDirectory
	{
		public const string FOLDER_NAME = "TestData";

		public static string FullPath
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FOLDER_NAME); }
        }

				
		public static FileInfo GetFile(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            string searchPattern = $"*{Path.GetExtension(fileName)}";

            string appDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            return new DirectoryInfo(appDirectory).GetFiles(searchPattern, SearchOption.AllDirectories)
                .First(x => x.Name.Equals(fileName, StringComparison.CurrentCultureIgnoreCase));
        }

        public static string GetFileContent(string fileName)
        {
            return File.ReadAllText(GetFile(fileName).FullName);
        }
	}

	[TestClass]
	public class ApprovalTestsCleaner
	{
		[AssemblyInitialize]
		public static void Cleanup(TestContext context)
		{
            foreach (var filePath in Directory.GetFiles(TestDataDirectory.FullPath, "*min.*", SearchOption.AllDirectories))
            {
                File.Delete(filePath);
            }
			ApprovalTests.Maintenance.ApprovalMaintenance.CleanUpAbandonedFiles();
		}
	}

	public static class TestFile
	{
			}

	public static class DataFile
	{
			}
}
