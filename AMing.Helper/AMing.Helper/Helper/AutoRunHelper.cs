using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMing.Helper.Helper
{
    public class AutoRunHelper
    { 
        /// <summary>
        /// 添加开机自启动
        /// </summary>
        /// <param name="ExePath">程序路径</param>
        /// <param name="KeyName">键值(只能用英文数字)</param>
        /// <returns>是否成功</returns>
        public static bool AddAutoRunkey(string ExePath, string KeyName)
        {
            //class Micosoft.Win32.RegistryKey. 表示Window注册表中项级节点,此类是注册表装.
            RegistryKey loca = Registry.CurrentUser;
            RegistryKey run = loca.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            try
            {
                //SetValue:存储值的名称
                run.SetValue(KeyName, ExePath);
                loca.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 删除开启自启动
        /// </summary>
        /// <param name="KeyName">键值</param>
        /// <returns>是否删除成</returns>
        public static bool DelAutoRunkey(string KeyName)
        {
            //class Micosoft.Win32.RegistryKey. 表示Window注册表中项级节点,此类是注册表装.
            RegistryKey loca = Registry.CurrentUser;
            RegistryKey run = loca.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            try
            {
                //SetValue:存储值的名称
                run.DeleteValue(KeyName);
                loca.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 检查是否有启动项
        /// </summary>
        /// <param name="KeyName">键值</param>
        /// <returns>是否有启动项</returns>
        public static bool GetAutoRun(string KeyName)
        {
            RegistryKey loca = Registry.CurrentUser;
            RegistryKey run = loca.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            if (run.GetValue(KeyName) == null)
                return false;
            else
                return true;
        }
    }
}
