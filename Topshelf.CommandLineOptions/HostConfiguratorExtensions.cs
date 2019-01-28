using System;
using System.Linq;
using Topshelf.HostConfigurators;

namespace Topshelf.CommandLineOptions
{
    public static class HostConfiguratorExtensions
    {
        public static T GetCommandlineOptions<T>(this HostConfigurator configurator) where T : class, new()
        {
            var convertor = new ValueConvertor();
            var options = new T();

            foreach (var pInfo in options.GetType().GetProperties())
            {
                var type = Nullable.GetUnderlyingType(pInfo.PropertyType) ?? pInfo.PropertyType;
                var optName = pInfo.GetCustomAttributes(typeof(OptionAttribute), false).Cast<OptionAttribute>().FirstOrDefault()?.OptionName;
                var currentValue = pInfo.GetValue(options);

                configurator.AddCommandLineDefinition(optName ?? pInfo.Name, val => pInfo.SetValue(options, convertor.ConvertValue(type, val, currentValue)));
            }

            return options;
        }
    }
}
