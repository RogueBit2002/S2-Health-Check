using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace HetBetereGroepje.HealthCheck.Factory
{
    public static class ServiceFactory
    {
        private static Dictionary<Type, MethodInfo> factories = new Dictionary<Type, MethodInfo>();
        //private static List<object> cachedServices = new List<object>();

        private static void LoadAssemblies()
        {
            IEnumerable<string> loadedPaths = AppDomain.CurrentDomain.GetAssemblies().Select(a => a.Location);
            
            Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
                .Where(r => !loadedPaths.Contains(r, StringComparer.InvariantCultureIgnoreCase))
                .ToList().ForEach(path => AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path)));
        }

        /// <summary>
        /// Initalize the ServiceProvider (loading all assemblies and searching for all factories)
        /// </summary>
        public static void Init()
        {
            factories.Clear();

            LoadAssemblies();

            AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .SelectMany(t => t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
                .Where(m => !m.IsConstructor && m.GetParameters().Length == 0
                && m.GetCustomAttribute<ServiceFactoryAttribute>() != null
                && (m.ReturnType.GetTypeInfo().IsClass || m.ReturnType.GetTypeInfo().IsInterface))
                .ToList().ForEach(m => factories.Add(m.ReturnType, m));
        }

        public static T Create<T>() where T : class
        {
            if (!factories.ContainsKey(typeof(T)))
                throw new ArgumentException($"Service factory of type {typeof(T)} isn't specified.");

            return factories[typeof(T)].Invoke(null, null) as T;
        }
    }
}
