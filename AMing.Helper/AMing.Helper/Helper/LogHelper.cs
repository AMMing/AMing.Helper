using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AMing.Helper.Helper
{
    /// <summary>
    /// 日志相关操作类
    /// </summary>
    public class LogHelper
    {
        public static string AppDir = AppDomain.CurrentDomain.BaseDirectory;

        public static void Write(Exception ex, params string[] message)
        {
            string logDir = AppDir + "\\App_Data\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\" + DateTime.Now.Hour + "\\";
            string errorFile = "Error_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            string logFile = "Log_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            try
            {
                try
                {
                    if (!Directory.Exists(logDir))
                    {
                        Directory.CreateDirectory(logDir);
                    }
                }
                catch { }

                string title = string.Empty;
                if (message.Length > 0)
                {
                    title = message[0];
                }

                File.AppendAllText(logDir + errorFile,
                     @"
Title:" + title + @"
Time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + @"
Message:" + ex.Message + @"
Source :" + ex.Source + @"
Trace :" + ex.StackTrace + @"
---------------------------------------------------");






            }
            catch { }
        }


        public static void Write(string message)
        {
            string logDir = AppDir + "\\App_Data\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\" + DateTime.Now.Hour + "\\";
            string errorFile = "Error_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            string logFile = "Log_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            try
            {
                try
                {
                    if (!Directory.Exists(logDir))
                    {
                        Directory.CreateDirectory(logDir);
                    }
                }
                catch { }

                File.AppendAllText(logDir + errorFile,
                     @"
Time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + @"
Message:" + message + @"
---------------------------------------------------");



            }
            catch { }
        }

    }
}
