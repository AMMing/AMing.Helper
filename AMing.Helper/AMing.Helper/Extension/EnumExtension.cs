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
        public static object GetData(this Enum enumdata, Func<EnumInfoAttribute, object> callback)
        {
            object des = string.Empty;
            var type = enumdata.GetType();
            var name = type.GetEnumName(enumdata);
            var attr = GetEnumInfoByName(type, name);

            return callback(attr);
        }

        #region Get Object Data

        public static object GetData1(this Enum enumdata)
        {
            return enumdata.GetData(attr => { return attr == null ? null : attr.Data1; });
        }

        public static object GetData2(this Enum enumdata)
        {
            return enumdata.GetData(attr => { return attr == null ? null : attr.Data2; });
        }

        public static object GetData3(this Enum enumdata)
        {
            return enumdata.GetData(attr => { return attr == null ? null : attr.Data3; });
        }

        public static object GetData4(this Enum enumdata)
        {
            return enumdata.GetData(attr => { return attr == null ? null : attr.Data4; });
        }

        public static object GetData5(this Enum enumdata)
        {
            return enumdata.GetData(attr => { return attr == null ? null : attr.Data5; });
        }

        #endregion


        #region Get Format Type Data

        public static T GetData1<T>(this Enum enumdata)
        {
            var obj = enumdata.GetData1();

            return ObjectExtension.To<T>(obj);
        }
        public static T GetData2<T>(this Enum enumdata)
        {
            var obj = enumdata.GetData2();

            return ObjectExtension.To<T>(obj);
        }
        public static T GetData3<T>(this Enum enumdata)
        {
            var obj = enumdata.GetData3();

            return ObjectExtension.To<T>(obj);
        }
        public static T GetData4<T>(this Enum enumdata)
        {
            var obj = enumdata.GetData4();

            return ObjectExtension.To<T>(obj);
        }
        public static T GetData5<T>(this Enum enumdata)
        {
            var obj = enumdata.GetData5();

            return ObjectExtension.To<T>(obj);
        }

        #endregion
    }
}
