using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMing.Helper.Extension;

namespace TestConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            EnumInfo();

            Console.Read();
        }


        static void EnumInfo()
        {
            var temp = TempEnum.A;
            //var temp = TempEnum.B;
            var data1 = temp.GetData1<string>();
            var data2 = temp.GetData2<int>();
            var data3 = temp.GetData3<double>();
            var data4 = temp.GetData4<int>();
            var data5 = temp.GetData5<string>();
        }

        enum TempEnum
        {
            [AMing.Helper.Attributes.EnumInfo(Data1 = "string_data1", Data2 = 123456789, Data3 = 123.321d, Data4 = 987654321, Data5 = "string_data5")]
            A,
            B
        }
    }
}
