using System.Reflection;

namespace Acklann.NShellit
{
    /// <summary>
    /// Provides information about the executing assembly.
    /// </summary>
    public static class AppInfo
    {
        static AppInfo()
        {
            Assembly assembly = (Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly());
            AssemblyName name = assembly.GetName();

            Product = (assembly.GetCustomAttribute<AssemblyProductAttribute>()?.Product ?? name.Name);
            Description = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description;
            Copyright = assembly.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright;
            Company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company;
            Version = name.Version.ToString();
        }

        /// <summary>
        /// The product name of the assembly manifest.
        /// </summary>
        public static readonly string Product;

        /// <summary>
        /// The version number of the assembly manifest.
        /// </summary>
        public static readonly string Version;

        /// <summary>
        /// The company name of the assembly manifest.
        /// </summary>
        public static readonly string Company;

        /// <summary>
        /// The copyright of the assembly manifest.
        /// </summary>
        public static readonly string Copyright;

        /// <summary>
        /// The description of the assembly manifest.
        /// </summary>
        public static readonly string Description;
    }
}