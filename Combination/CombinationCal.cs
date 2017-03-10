using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combination
{
    public class CombinationCal
    {
        const int NUM = 0;//NUM为要选取的元素个数
        const int arr_len = 0;//arr_len为原始数组的长度，为定值
        //arr为原始数组
        //start为遍历起始位置
        //result保存结果，为一维数组
        //count为result数组的索引值，起辅助作用
        //NUM为要选取的元素个数
        //arr_len为原始数组的长度，为定值

        public void combine_increase(int[] arr, int start, int[] result, int count)
        {
            int i = 0;
            for (i = start; i < arr_len + 1 - count; i++)
            {
                result[count - 1] = i;
                if (count - 1 == 0)
                {
                    int j;
                    for (j = NUM - 1; j >= 0; j--)
                        Console.Write(arr[result[j]] + "\t");
                    Console.WriteLine();
                }
                else
                    combine_increase(arr, i + 1, result, count - 1);
            }
        }
    }
}
