using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Utils
{
    public static class ObjectExtensions
    {
        public static T Clone<T>(this T obj)
        {
            var cloneMethod = obj.GetType()
                .GetMethod("MemberwiseClone", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            var result = (T)cloneMethod?.Invoke(obj, null);
            return result;
        }

        public static T CloneWith<T, K>(this T obj, Expression<Func<T, K>> property, K value)
        {
            var cloneMethod = obj.GetType()
                .GetMethod("MemberwiseClone", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            var result = (T)cloneMethod?.Invoke(obj, null);
            var memberAccess = (MemberExpression)property.Body;
            var propertyInfo = (PropertyInfo)memberAccess.Member;
            propertyInfo.SetValue(result, value);
            return result;
        }

        public static T With<T, K>(this T obj, Expression<Func<T, K>> property, K value)
        {
            var memberAccess = (MemberExpression)property.Body;
            var propertyInfo = (PropertyInfo)memberAccess.Member;
            propertyInfo.SetValue(obj, value);
            return obj;
        }
    }
}
