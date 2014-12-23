using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AMing.Helper.Security
{
    public class RSAEncrypt
    {
        public RSAEncrypt()
        {
            rsa = new RSACryptoServiceProvider();
        }
        public RSAEncrypt(string key_xml)
            : this()
        {
            rsa.FromXmlString(key_xml);
        }

        RSACryptoServiceProvider rsa;
        /// <summary>
        /// 获取或设置密钥与公钥XML
        /// </summary>
        public string PrivateKey
        {
            get
            {
                return rsa.ToXmlString(true);
            }
            set
            {
                rsa.FromXmlString(value);
            }
        }
        /// <summary>
        /// 获取公钥XML
        /// </summary>
        public string PubilcKey
        {
            get
            {
                return rsa.ToXmlString(false);
            }
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string Encrypt(string data)
        {
            byte[] data_b = Encoding.GetEncoding("gb2312").GetBytes(data);

            byte[] result = rsa.Encrypt(data_b, false);

            string rsa_data = Convert.ToBase64String(result);

            return rsa_data;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="rsa_data"></param>
        /// <returns></returns>
        public string Decrypt(string rsa_data)
        {
            byte[] data_b = Convert.FromBase64String(rsa_data);
            byte[] result = rsa.Decrypt(data_b, false);

            string data = Encoding.GetEncoding("gb2312").GetString(result);

            return data;
        }
    }
}
