using System;
using System.Reflection;

namespace Acklann.NShellit
{
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

        public static readonly string Product;
        public static readonly string Version;
        public static readonly string Company;
        public static readonly string Copyright;
        public static readonly string Description;
    }
}