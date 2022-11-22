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
                .SelectMany(a => a.GetTypes().Where(t => !t.IsAbstract)) //Get all non-abstract types
                .SelectMany(t => t.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)
                    .Where(m => !m.IsConstructor && m.GetParameters().Length == 0
                    && m.GetCustomAttribute<ServiceFactoryAttribute>() != null 
                    && m.ReturnType != typeof(void))) //Get all valid methods
                .ToList().ForEach(m => factories.Add(m.ReturnType, m)); //Add to factories
        }

        public static void Test()
        {
            
        }

        public static T Create<T>() where T : class
        {
            if (!factories.ContainsKey(typeof(T)))
                throw new ArgumentException($"Service factory of type {typeof(T)} isn't specified.");

            return factories[typeof(T)].Invoke(null, null) as T;
        }
        /*
        /// <summary>
        /// Returns a service object of type <typeparamref name="T" />. When no service of that types exist, it tries to create it using a factory it found.
        /// </summary>
        /// <typeparam name="T">The type of the service</typeparam>
        /// <returns>Service of type <typeparamref name="T"/></returns>
        /// <exception cref="ArgumentException"></exception>
        public static T? Get<T>() where T : class
        {
            /*foreach (object service in cachedServices)
                if (service is T)
                    return service as T;* /

            if(!factories.ContainsKey(typeof(T)))
                throw new ArgumentException($"Service factory of type {typeof(T)} isn't specified.");

            
            object newService = factories[typeof(T)].Invoke(null, null);
            //cachedServices.Add(newService);
            return newService as T;
        }*/
    }
}
