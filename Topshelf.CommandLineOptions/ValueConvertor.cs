using System;

namespace Topshelf.CommandLineOptions
{
    internal class ValueConvertor
    {
        public object ConvertValue(Type targetType, object value, object defaultValue = null)
        {
            if (typeof(IConvertible).IsAssignableFrom(targetType))
            {
                if (targetType == typeof(bool) && value.ToString()?.Length == 0)
                {
                    return true; // boolean property needs just a flag, no need for a value
                }

                return Convert.ChangeType(value ?? defaultValue ?? targetType.GetDefaultValue(), targetType);
            }
            else
            {
                return Convert.ToString(value ?? "");
            }
        }
    }
}
