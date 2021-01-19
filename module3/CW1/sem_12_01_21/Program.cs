using System;
using System.Linq;

namespace sem_12_01_21
{
    delegate void PrintArr(int[] arr);
    delegate int[] GetArr(int a);
    class Program
    {
        private static int[] GetNumbArray(int num)
        {
            int[] res = new int[(int)Math.Log10(num) + 1];
            int k = 0;
            while (num > 0)
            {
                res[k] = num % 10;
                k += 1;
                num /= 10;
            }
            res.Reverse();
            return res;
        }
        private static void Print(int[] arr)
        {
            foreach (int elem in arr)
            {
                Console.WriteLine(elem);
            }
        }
        static void Main(string[] args)
        {
            int n = 78934;
            int[] myarr = { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            PrintArr print = Print;
            GetArr newArr = GetNumbArray;
            print?.Invoke(myarr);
            newArr?.Invoke(n);
            Console.WriteLine(newArr.Method);
            Console.WriteLine(newArr.Target); 
            Console.WriteLine(print.Method);
            Console.WriteLine(print.Target);
        }
        
    }
}
