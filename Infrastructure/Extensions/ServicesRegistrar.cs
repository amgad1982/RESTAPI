using Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Infrastructure.Extensions
{

    public enum ServiceScope
    {
        Scoped,
        Singleton,
        Transite
    }
    public static class ServicesRegistrar
    {
        private static IEnumerable<T> LoadAssemblyTypes<T>(Assembly assembly)
        {
            return  assembly.ExportedTypes.Where(x =>
               typeof(T).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<T>().ToList();
        }
        public static void RegisterFromAssembly<T>(this IServiceCollection services,Assembly assembly,ServiceScope scope)
        {
            LoadAssemblyTypes<T>(assembly).ToList().ForEach(t =>
            {
                switch (scope)
                {
                    case ServiceScope.Singleton:
                        services.AddSingleton(typeof(T), t);
                        break;
                    case ServiceScope.Scoped:
                        services.AddScoped(typeof(T), t.GetType());
                        break;
                    case ServiceScope.Transite:
                        services.AddTransient(typeof(T), t.GetType());
                        break;
                }
            });
        }

        public static void RegisterIServiceServicesFromAssembly(this IServiceCollection services, IConfiguration configuration,Assembly assembly)
        {
            LoadAssemblyTypes<IService>(assembly).ToList().ForEach(t => t.RegisterService(services, configuration));
        }
    }
}
