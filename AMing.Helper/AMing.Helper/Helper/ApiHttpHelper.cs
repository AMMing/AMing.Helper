using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace AMing.Helper.Helper
{
    public class HttpExHelper
    {
        /// <summary>
        /// HttpGet
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="callback"></param>
        public Model.HttpResult Get(string url)
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
                    return new Model.HttpResult
                    {
                        Data = content
                    };
                }
            }
            catch (Exception ex)
            {
                return new Model.HttpResult
                {
                    Error = ex
                };
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
        public Model.HttpResult Post(string url, string postData)
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
                        return new Model.HttpResult
                        {
                            Data = content
                        };
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return new Model.HttpResult
                {
                    Error = ex
                };
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
        public Model.HttpResult Post_Json(string url, string postData)
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
                        return new Model.HttpResult
                        {
                            Data = content
                        };
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return new Model.HttpResult
                {
                    Error = ex
                };
            }
            finally
            {
                if (request != null)
                    request.Abort();
            }
        }


        public Model.HttpResult PostMultiPartData(string url, byte[] data, string boundary)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                request.ContentType = "multipart/form-data; boundary=" + boundary;
                request.Method = "POST";
                request.KeepAlive = true;
                request.Credentials = System.Net.CredentialCache.DefaultCredentials;
                using (Stream reqSteam = request.GetRequestStream())
                {
                    reqSteam.Write(data, 0, data.Length);
                    WebResponse rep = request.GetResponse();
                    using (Stream repStream = rep.GetResponseStream())
                    {
                        using (StreamReader sr = new StreamReader(repStream))
                        {
                            string content = sr.ReadToEnd();
                            return new Model.HttpResult
                            {
                                Data = content
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new Model.HttpResult
                {
                    Error = ex
                };
            }
            finally
            {
                if (request != null)
                    request.Abort();
            }
        }

    }
}
