using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AMing.Helper.Helper
{
    public class TextFileHelper
    {
        /// <summary>
        /// 读取txt文本内容
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string TxtFileRead(string filepath)
        {
            System.IO.FileInfo fileInfo = new FileInfo(filepath);
            if (fileInfo.Exists)
            {
                using (var stream = fileInfo.Open(System.IO.FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 保存Txt文件
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="txt"></param>
        public static void TxtFileWrite(string filepath, string txt)
        {
            string folder = System.IO.Path.GetDirectoryName(filepath);

            System.IO.DirectoryInfo dirInfo = new DirectoryInfo(folder);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            System.IO.FileInfo fileInfo = new FileInfo(filepath);
            if (fileInfo.Exists)
            {
                System.IO.File.SetAttributes(filepath, FileAttributes.Normal);
            }
            using (var stream = fileInfo.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    sw.Write(txt);
                }
            }
        }


        /// <summary>
        /// 追加内容到txt文件中
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="txt"></param>
        public static void AppendAllText(string filepath, string txt)
        {
            string folder = System.IO.Path.GetDirectoryName(filepath);

            System.IO.DirectoryInfo dirInfo = new DirectoryInfo(folder);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            System.IO.FileInfo fileInfo = new FileInfo(filepath);
            if (fileInfo.Exists)
            {
                System.IO.File.SetAttributes(filepath, FileAttributes.Normal);
            }

            File.AppendAllText(filepath, txt);
        }




        /// <summary>
        /// 按行读取txt文本内容
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static List<string> TxtFileReadLines(string filepath)
        {
            System.IO.FileInfo fileInfo = new FileInfo(filepath);
            if (fileInfo.Exists)
            {
                using (var stream = fileInfo.Open(System.IO.FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        string sLine = "";
                        List<string> LineList = new List<string>();
                        while (sLine != null)
                        {
                            sLine = sr.ReadLine();
                            if (sLine != null && !sLine.Equals(""))
                            {
                                LineList.Add(sLine);
                            }
                        }
                        sr.Close();
                        return LineList;

                    }
                }
            }
            else
            {
                return null;
            }
        }
    }
}
