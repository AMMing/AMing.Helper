using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMing.Helper.Extension
{
    public static class IDictionaryExtension
    {
        /// <summary>
        /// 获取指定key的value
        /// </summary>
        /// <typeparam name="TKey">字典中键的类型。</typeparam>
        /// <typeparam name="TValue">字典中值的类型。</typeparam>
        /// <param name="iDictionary">字典数据</param>
        /// <param name="key">查询的key</param>
        /// <returns>查询结果</returns>
        public static TValue GetKeyValue<TKey, TValue>(this IDictionary<TKey, TValue> iDictionary, TKey key)
        {
            if (iDictionary.ContainsKey(key))
            {
                return iDictionary[key];
            }
            else
            {
                return default(TValue);
            }
        }
        /// <summary>
        /// 获取指定key的value
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="iDictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TValue GetKeyValue<TKey, TValue>(this IDictionary<TKey, TValue> iDictionary, TKey key, TValue defaultValue)
        {
            if (iDictionary.ContainsKey(key))
            {
                return iDictionary[key];
            }
            else
            {
                return defaultValue;
            }
        }
    }
}
