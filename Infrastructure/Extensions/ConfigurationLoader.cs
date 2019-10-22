
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Extensions
{
    public static class ConfigurationLoader
    {
        public static T GetConfig<T>(this IConfiguration configuration,string key=default(string))
        {
            T obj = Activator.CreateInstance<T>();
            configuration.GetSection(string.IsNullOrEmpty(key) ? typeof(T).Name : key).Bind(obj);
            return obj;
        }
    }
}
