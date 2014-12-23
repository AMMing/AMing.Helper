using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace AMing.Helper.Helper
{
    public class HttpHelper
    {
        /// <summary>
        /// HttpGet
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="callback"></param>
        public string Get(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                request.AllowAutoRedirect = true;
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Timeout = 10000;

                WebResponse rep = request.GetResponse();
                using (Stream stream = rep.GetResponseStream())
                using (StreamReader sr = new StreamReader(stream))
                {
                    string content = sr.ReadToEnd();
                    return content;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                if (request != null)
                    request.Abort();
            }
        }

        /// <summary>
        /// HttpPost
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="callback"></param>
        public string Post(string url, string postData)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            try
            {
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                if (!string.IsNullOrEmpty(postData))
                {
                    byte[] postdata = Encoding.UTF8.GetBytes(postData);
                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(postdata, 0, postdata.Length);
                    }
                    WebResponse rep = request.GetResponse();
                    using (Stream stream = rep.GetResponseStream())
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        string content = sr.ReadToEnd();
                        return content;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (request != null)
                    request.Abort();
            }
        }


        /// <summary>
        /// HttpPost
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="callback"></param>
        public string Post_Json(string url, string postData)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            try
            {
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;
                request.ContentType = "application/json";
                if (!string.IsNullOrEmpty(postData))
                {
                    byte[] postdata = Encoding.UTF8.GetBytes(postData);
                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(postdata, 0, postdata.Length);
                    }
                    WebResponse rep = request.GetResponse();
                    using (Stream stream = rep.GetResponseStream())
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        string content = sr.ReadToEnd();
                        return content;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (request != null)
                    request.Abort();
            }
        }

    }
}
