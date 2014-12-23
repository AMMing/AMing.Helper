using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMing.Helper.Extension;

namespace AMing.Helper.Helper
{
    public class SecurityHelper
    {
        /// <summary>
        /// 打乱过的md5加密
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string Md5_Security(string val)
        {
            string m1 = Security.MD5Encrypt.Encrypt(val);
            string m2 = Security.MD5Encrypt.Encrypt("{0}{1}{0}".ToFormat(val, m1));

            string m3 = string.Empty;

            int count = m1.Length;
            if (m2.Length > count)
            {
                count = m2.Length;
            }

            for (int i = 0; i < count; i++)
            {
                if (i < m1.Length)
                {
                    m3 += m1[i].ToString();
                }
                if (i < m2.Length)
                {
                    m3 += m2[i].ToString();
                }
            }

            m3 = Security.MD5Encrypt.Encrypt(m3.ToLower());

            return m3;
        }
    }
}
