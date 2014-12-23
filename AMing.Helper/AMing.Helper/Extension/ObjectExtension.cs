using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMing.Helper.Extension
{
    public static class ObjectExtension
    {
        /// <summary>
        /// 转成指定类型
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="type">类型</param>
        /// <returns>转换的结果</returns>
        public static object ChangeType(object value, Type type)
        {
            if (value == null && type.IsGenericType) return Activator.CreateInstance(type);
            if (value == null) return null;
            if (type == value.GetType()) return value;
            if (type.IsEnum)
            {
                if (value is string)
                    return Enum.Parse(type, value as string);
                else
                    return Enum.ToObject(type, value);
            }
            if (!type.IsInterface && type.IsGenericType)
            {
                Type innerType = type.GetGenericArguments()[0];
                object innerValue = ChangeType(value, innerType);
                return Activator.CreateInstance(type, new object[] { innerValue });
            }
            if (value is string && type == typeof(Guid)) return new Guid(value as string);
            if (value is string && type == typeof(Version)) return new Version(value as string);
            if (!(value is IConvertible)) return value;
            return Convert.ChangeType(value, type);
        }

        /// <summary>
        /// 转成指定类型
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="val">值</param>
        /// <param name="defaultval">转换失败的设置的值</param>
        /// <returns>转换的结果</returns>
        public static T To<T>(this object val, T defaultval = default(T))
        {
            object obj = null;
            try
            {
                obj = ChangeType(val, typeof(T));
            }
            catch (Exception)
            {
            }
            obj = obj ?? defaultval;

            return (T)obj;
        }
    }
}
