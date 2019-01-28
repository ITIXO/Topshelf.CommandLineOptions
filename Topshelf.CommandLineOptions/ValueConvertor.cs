using System;

namespace Topshelf.CommandLineOptions
{
    internal class ValueConvertor
    {
        public object ConvertValue(Type targetType, object value, object defaultValue = null)
        {
            if (typeof(IConvertible).IsAssignableFrom(targetType))
            {
                return Convert.ChangeType(value ?? defaultValue ?? targetType.GetDefaultValue(), targetType);
            }
            else
            {
                return Convert.ToString(value ?? "");
            }
        }
    }
}
