using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AMing.Helper.Helper
{
    public class HtmlRegexHelper
    {
        #region Get

        /// <summary>
        /// 获取指定属性的Html区域内容
        /// </summary>
        /// <param name="htmlString">Html文档字符串</param>
        /// <param name="attr">属性</param>
        /// <param name="val">值</param>
        /// <returns></returns>
        public static IList<string> GetHtmlElementString(string htmlString, string attr, string val)
        {
            IList<string> htmlList = new List<string>();
            //string regexString = "<(?<HtmlTag>[\\w]+)[^>]*\\sclass=(?<Quote>[\"']?)l_post(?(Quote)\\k<Quote>)[\"']?[^>]*>(((?<Nested><\\k<HtmlTag>[^>]*>)|</\\k<HtmlTag>>(?<-Nested>)|.*?)*)</\\k<HtmlTag>>";
            string regexString = string.Format("<(?<HtmlTag>[\\w]+)[^>]*\\s{0}=(?<Quote>[\"']?){1}(?(Quote)\\k<Quote>)[\"']?[^>]*>(((?<Nested><\\k<HtmlTag>[^>]*>)|</\\k<HtmlTag>>(?<-Nested>)|.*?)*)</\\k<HtmlTag>>", attr, val);
            MatchCollection m = Regex.Matches(htmlString, regexString.Trim(), RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);
            foreach (Match subm in m)
            {
                htmlList.Add(subm.Groups[0].Value.Replace("amp;", ""));
            }

            return htmlList;
        }
        /// <summary>
        /// 获取指定属性的Html区域内容
        /// </summary>
        /// <param name="htmlString">Html文档字符串</param>
        /// <param name="attr">属性</param>
        /// <param name="val">值</param>
        /// <returns></returns>
        public static IList<string> GetHtmlElementString(string htmlString, string element)
        {
            IList<string> htmlList = new List<string>();
            string regexString = string.Format("<(?<{0}>[\\w]+)[^>]*\\s(?<Quote>[\"']?)(?(Quote)\\k<Quote>)[\"']?[^>]*>(((?<Nested><\\k<{0}>[^>]*>)|</\\k<{0}>>(?<-Nested>)|.*?)*)</\\k<{0}>>", element);
            MatchCollection m = Regex.Matches(htmlString, regexString.Trim(), RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);
            foreach (Match subm in m)
            {
                htmlList.Add(subm.Groups[0].Value.Replace("amp;", ""));
            }

            return htmlList;
        }
        /// <summary>
        /// 获取指定属性的Html区域内容
        /// </summary>
        /// <param name="htmlString">Html文档字符串</param>
        /// <param name="attr">属性</param>
        /// <param name="val">值</param>
        /// <returns></returns>
        public static string GetHtmlOneElementString(string htmlString, string attr, string val)
        {
            string regexString = string.Format("<(?<HtmlTag>[\\w]+)[^>]*\\s{0}=(?<Quote>[\"']?){1}(?(Quote)\\k<Quote>)[\"']?[^>]*>(((?<Nested><\\k<HtmlTag>[^>]*>)|</\\k<HtmlTag>>(?<-Nested>)|.*?)*)</\\k<HtmlTag>>", attr, val);
            MatchCollection m = Regex.Matches(htmlString, regexString.Trim(), RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);
            if (m.Count > 0)
            {
                return m[0].Groups[0].Value.Replace("amp;", "");
            }
            return "";
        }

        /// <summary> 
        /// 取得HTML中所有图片的 URL。 
        /// </summary> 
        /// <param name="sHtmlText">HTML代码</param> 
        /// <returns>图片的URL列表</returns> 
        public static IList<string> GetHtmlImageUrlList(string sHtmlText)
        {
            IList<string> imglist = new List<string>();
            // 定义正则表达式用来匹配 img 标签 
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
            // 搜索匹配的字符串 
            MatchCollection matches = regImg.Matches(sHtmlText);
            // 取得匹配项列表 
            foreach (Match match in matches)
            {
                imglist.Add(match.Groups["imgUrl"].Value);
            }

            return imglist;
        }

        #endregion

        #region Remove

        /// <summary>
        /// 去除HTML标记
        /// </summary>
        /// <param name="Htmlstring">Html文档字符串</param>
        /// <returns></returns>
        public static string RemoveHTML(string Htmlstring)
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "",
              RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "",
              RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");

            return Htmlstring;
        }
        /// <summary>
        /// 去除Script标记
        /// </summary>
        /// <param name="Htmlstring">Html文档字符串</param>
        /// <returns></returns>
        public static string RemoveScript(string Htmlstring)
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "",
              RegexOptions.IgnoreCase);
            return Htmlstring;
        }

        #endregion
    }
}
