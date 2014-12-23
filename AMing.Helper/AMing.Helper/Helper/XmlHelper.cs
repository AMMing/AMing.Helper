using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AMing.Helper.Helper
{
    public class XmlHelper
    { 
        /// <summary>
        /// 序列化Xml
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string Serialize<T>(object obj)
        {
            try
            {
                string xml = null;
                using (System.IO.TextWriter writer = new System.IO.StringWriter())
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(writer, obj);
                    xml = writer.ToString();
                }

                return xml;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
