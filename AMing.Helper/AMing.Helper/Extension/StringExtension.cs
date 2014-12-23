using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AMing.Helper.Extension
{
    public static class StringExtension
    {
        /// <summary>
        /// 将指定字符串中的格式项替换为指定数组中相应对象的字符串表示形式。
        /// </summary>
        /// <param name="val">复合格式字符串。</param>
        /// <param name="args">一个对象数组，其中包含零个或多个要设置格式的对象。</param>
        /// <returns>format 的副本，其中的格式项已替换为 args 中相应对象的字符串表示形式。</returns>
        public static string ToFormat(this string val, params object[] args)
        {
            return string.Format(val, args);
        }

        /// <summary>   
        /// 移除HTML标签   
        /// </summary>   
        /// <param name="content">html内容</param>   
        /// <returns>结果</returns>
        public static string RemoveHtmlTag(this string content)
        {
            var regexstr = "<[^>]*>";
            return Regex.Replace(content, regexstr, string.Empty, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 过滤脚本
        /// </summary>
        /// <param name="content">html内容</param>
        /// <returns>结果</returns>
        public static string RemoveScript(this string content)
        {
            string regexstr = @"(?i)<script([^>])*>(\w|\W)*</script([^>])*>";
            return Regex.Replace(content, regexstr, string.Empty, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 获取XX与XX之间的字符串
        /// </summary>
        /// <param name="content"></param>
        /// <param name="s_val"></param>
        /// <param name="e_val"></param>
        /// <returns></returns>
        public static string GetAmongString(this string content, string s_val, string e_val)
        {
            string among = content;
            int index = among.ToLower().IndexOf(s_val);
            if (index < 0)
            {
                return null;
            }
            among = among.Substring(index + s_val.Length);
            index = among.IndexOf(e_val);
            if (index < 0)
            {
                return null;
            }
            among = among.Substring(0, index);

            return among;
        }



        /// <summary>
        /// 获取XX与XX之间的字符串
        /// </summary>
        /// <param name="content"></param>
        /// <param name="s_val"></param>
        /// <param name="e_val"></param>
        /// <param name="out_val"></param>
        /// <returns></returns>
        public static bool TryGetAmongString(this string content, string s_val, string e_val, out string out_val)
        {
            out_val = null;
            try
            {
                out_val = GetAmongString(content, s_val, e_val);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
