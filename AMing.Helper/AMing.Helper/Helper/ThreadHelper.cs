using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMing.Helper.Helper
{
    public class ThreadHelper
    {
        /// <summary>
        /// 后台处理(多线程)
        /// </summary>
        /// <param name="method">执行方法</param>
        public void Thread_Background(Action method)
        {
            System.Threading.Thread thread = new System.Threading.Thread((obj) =>
            {
                method();
            });
            thread.IsBackground = true;
            thread.Name = "后台处理用线程";
            thread.Start();
        }
    }
}
