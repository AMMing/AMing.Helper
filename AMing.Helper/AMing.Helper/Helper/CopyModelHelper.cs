using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMing.Helper.Helper
{
    public class CopyModelHelper
    {
        /// <summary>
        /// 复制实体上面的数据到继承该模型的实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T_Base"></typeparam>
        /// <param name="heritor"></param>
        /// <param name="basedata"></param>
        /// <returns></returns>
        public static T Copy<T, T_Base>(T heritor, T_Base basedata)
            where T : T_Base
        {
            Type t_b = typeof(T_Base);
            var props = t_b.GetProperties();
            foreach (var item in props)
            {
                object b_val = item.GetValue(basedata, null);
                item.SetValue(heritor, b_val, null);
            }

            return heritor;
        }

        /// <summary>
        /// 复制实体上面的数据到另外一个实体
        /// </summary>
        /// <typeparam name="T_Source"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T CopyTo<T_Source, T>(T_Source source, T data)
        {
            Type classType = typeof(T);
            Type sourceType = typeof(T_Source);
            var props = classType.GetProperties();
            foreach (var item in props)
            {
                var s_item = sourceType.GetProperty(item.Name);
                if (s_item != null)
                {
                    object source_val = s_item.GetValue(source, null);
                    if (source_val == null)
                    {
                        continue;
                    }
                    var newval = Extension.ObjectExtension.ChangeType(source_val, item.PropertyType);
                    item.SetValue(data, newval, null);
                }
            }

            return data;
        }
    }
}
