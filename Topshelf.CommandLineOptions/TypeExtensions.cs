using System;
using System.Linq.Expressions;

namespace Topshelf.CommandLineOptions
{
    internal static class TypeExtensions
    {
        public static object GetDefaultValue(this Type type)
        {
            if (type == null) throw new ArgumentNullException("type");

            Expression<Func<object>> e = Expression.Lambda<Func<object>>(
                Expression.Convert(Expression.Default(type), typeof(object))
            );

            return e.Compile()();
        }
    }
}
