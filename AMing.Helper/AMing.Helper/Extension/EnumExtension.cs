using AMing.Helper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMing.Helper.Extension;

namespace AMing.Helper.Extension
{
    public static class EnumExtension
    {
        public static EnumInfoAttribute GetEnumInfoByName(Type type, string name)
        {
            var field = type.GetField(name);
            var attrs = field.GetCustomAttributes(typeof(EnumInfoAttribute), true);
            if (attrs != null && attrs.Length > 0)
            {
                var numInfoAttr = attrs[0] as EnumInfoAttribute;

                return numInfoAttr;
            }

            return null;
        }
        /// <summary>
        /// 获取枚举附加值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumdata">枚举</param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static object GetData<T>(this T enumdata, Func<EnumInfoAttribute, object> callback)
        {
            object des = string.Empty;
            var type = typeof(T);
            var name = type.GetEnumName(enumdata);
            var attr = GetEnumInfoByName(type, name);

            return callback(attr);
        }

        #region Get Object Data

        public static object GetData1<T>(this T enumdata)
        {
            return enumdata.GetData<T>(attr => { return attr == null ? null : attr.Data1; });
        }

        public static object GetData2<T>(this T enumdata)
        {
            return enumdata.GetData<T>(attr => { return attr == null ? null : attr.Data2; });
        }

        public static object GetData3<T>(this T enumdata)
        {
            return enumdata.GetData<T>(attr => { return attr == null ? null : attr.Data3; });
        }

        public static object GetData4<T>(this T enumdata)
        {
            return enumdata.GetData<T>(attr => { return attr == null ? null : attr.Data4; });
        }

        public static object GetData5<T>(this T enumdata)
        {
            return enumdata.GetData<T>(attr => { return attr == null ? null : attr.Data5; });
        }

        #endregion


        #region Get Format Type Data

        public static Return_Type GetData1<T, Return_Type>(this T enumdata)
        {
            var obj = enumdata.GetData1<T>();

            return ObjectExtension.To<Return_Type>(obj);
        }
        public static Return_Type GetData2<T, Return_Type>(this T enumdata)
        {
            var obj = enumdata.GetData2<T>();

            return ObjectExtension.To<Return_Type>(obj);
        }
        public static Return_Type GetData3<T, Return_Type>(this T enumdata)
        {
            var obj = enumdata.GetData3<T>();

            return ObjectExtension.To<Return_Type>(obj);
        }
        public static Return_Type GetData4<T, Return_Type>(this T enumdata)
        {
            var obj = enumdata.GetData4<T>();

            return ObjectExtension.To<Return_Type>(obj);
        }
        public static Return_Type GetData5<T, Return_Type>(this T enumdata)
        {
            var obj = enumdata.GetData5<T>();

            return ObjectExtension.To<Return_Type>(obj);
        }

        #endregion
    }
}
