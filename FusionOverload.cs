using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WpfApplication1
{
    public class Program
    {
        [STAThreadAttribute]
        public static void Main()
        {
            var assemblies = new Dictionary<string, Assembly>();
            var executingAssembly = Assembly.GetExecutingAssembly();
            var resources = executingAssembly.GetManifestResourceNames().Where(n => n.EndsWith(".dll"));

            foreach (string resource in resources)
            {
                using (var stream = executingAssembly.GetManifestResourceStream(resource))
                {
                    if (stream == null)
                        continue;

                    var bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, bytes.Length);
                    try
                    {
                        assemblies.Add(resource, Assembly.Load(bytes));
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.Print(string.Format("Failed to load: {0}, Exception: {1}", resource, ex.Message));
                    }
                }
            }

            AppDomain.CurrentDomain.AssemblyResolve += (s, assembly) =>
            {
                var resources = executingAssembly.GetManifestResourceNames().Where(n => n.EndsWith(".dll"));

                var assemblyName = new AssemblyName(assembly.Name);

                var path = string.Format("{0}.dll", assemblyName.Name);

                if (assemblies.ContainsKey(path))
                {
                    return assemblies[path];
                }

                return null;
            };

            App.Main();
        }
    }
}