using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumTest
{
    class Program
    {
        enum Days { Saturday, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday };

        enum Color1 : short
        {
            Black = 0,
            Red = 1,
            Green = 2,
            Blue = 4
        };

        [Flags]
        enum Color2 : short
        {
            Black = 0,
            Red = 1,
            Green = 2,
            Blue = 8
        };
        static void Main(string[] args)
        {
            EnumTest();
            Console.ReadKey();
        }

        /// <summary>
        /// 测试Enum
        /// </summary>
        public static void EnumTest()
        {
            Type days = typeof(Days);
            //演示打印一个枚举成员的枚举名
            Console.WriteLine("演示打印一个枚举成员的枚举名:");
            Console.WriteLine("1-{0}", Enum.GetName(days, 1));

            // 使用GetNames演示打印所有枚举名：
            Console.WriteLine("使用GetNames演示打印所有枚举名：");
            string[] enumNames = Enum.GetNames(days);//获取所有枚举名
            for (int i = 0; i < enumNames.Length; i++)
            {
                Console.WriteLine("{0}-{1}", i, enumNames[i]);
            }
            //演示使用GetValue获取并打印所有枚举值
            Console.WriteLine("演示使用GetValue获取并打印所有枚举值：");
            int[] enumValues = (int[])Enum.GetValues(days);
            for (int i = 0; i < enumValues.Length; i++)
            {
                Console.WriteLine("{0}-{1}", enumValues[i], (Days)i);
            }
            //演示使用IsDefined判断枚举中是否存在具有指定枚举值
            Console.WriteLine("演示使用IsDefined判断枚举中是否存在具有指定枚举值：");
            Console.WriteLine("Enum.IsDefined={0}", Enum.IsDefined(days, 8));
            //现在演示Enum.Parse
            //将一个或多个枚举常数的名称或数字值的字符串表示转换成等效的枚举对象。
            Console.WriteLine("将一个或多个枚举常数的名称或数字值的字符串表示转换成等效的枚举对象");
            for (int i = 0; i < enumNames.Length; i++)
            {
                Console.WriteLine("{0}-{1}", i, Enum.Parse(days, i.ToString()));
                //等价于
                //Console.WriteLine("{0}-{1}", (int)(Enum.Parse(days,i.ToString())),  Enum.Parse(days,i.ToString()));
                //也等价于
                //  Console.WriteLine("{0}-{1}",i,enumNames[i]);
            }
        }
        /// <summary>
        /// 测试Flag
        /// </summary>
        public static void FlagsAttributeTest()
        {
            Console.WriteLine("测试未使用FlagsAttribute属性");
            Color1 MyColor1 = Color1.Red | Color1.Blue & Color1.Green;
            //我先不运行计算一下看看是那个:0001|0100&0010=0001  应该是Red
            Console.WriteLine("MyColor1={0}", MyColor1);
            Color1 MyColor_1 = Color1.Red | Color1.Blue;
            //我先不运行计算一下看看是那个:0001|0100=0101  应该是5
            Console.WriteLine("MyColor_1={0}", MyColor_1);
            Console.WriteLine("测试使用FlagsAttribute属性");
            Color2 MyColor2 = Color2.Red | Color2.Blue;
            //我先不运行计算一下看看是那个:0001|0100=0101应该是Red,Blue
            Console.WriteLine("MyColor2={0}", MyColor2);

            Console.WriteLine("------------------求交集------------------");
            Color2 color3 = MyColor2 & Color2.Blue;//求交集
            Console.WriteLine(color3);
        }
    }
}
