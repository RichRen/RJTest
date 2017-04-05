using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CommonTest
{
    class Program
    {
        class SwappingStrings
        {
            static void SwapStrings(int[] arr1, int[] arr2)
            // The string parameter is passed by reference.
            // Any changes on parameters will affect the original variables.
            {
                int[] temp = { 1 };
                arr1 = arr2;
                arr2 = temp;
                System.Console.WriteLine("Inside the method: {0} {1}", arr1[0], arr2[0]);
            }

            static void Main()
            {
                int[] arr1 = { 1 };
                int[] arr2 = { 2};
                System.Console.WriteLine("Inside Main, before swapping: {0} {1}", arr1[0], arr2[0]);

                SwapStrings(arr1, arr2);   // Passing strings by reference
                System.Console.WriteLine("Inside Main, after swapping: {0} {1}", arr1[0], arr2[0]);

                Console.Read();
            }
        }
    }
}
