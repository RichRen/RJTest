using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combination
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3 ,4};
            int num = 2;
            int[] record = new int[num];

            combine_increase(arr, 0, record, num);

            Console.Read();
        }

        //const int NUM = 2;//NUM为要选取的元素个数
        //const int arr_len = 3;//arr_len为原始数组的长度，为定值
        //arr为原始数组
        //start为遍历起始位置
        //record保存结果，为一维数组
        //count为record数组的索引值，起辅助作用
        //NUM为要选取的元素个数
        //arr_len为原始数组的长度，为定值

        static void combine_increase(int[] arr, int start, int[] record, int count)
        {
            for (int i = start; i < arr.Length + 1 - count; i++)
            {
                record[count - 1] = i;
                if (count - 1 == 0)
                {
                    for (int j = record.Length - 1; j >= 0; j--)
                        Console.Write(arr[record[j]] + "\t");
                    Console.WriteLine("  xxx"+record[0]+""+ record[1]);
                }
                else
                    combine_increase(arr, i + 1, record, count - 1);
            }
        }
    }
}
