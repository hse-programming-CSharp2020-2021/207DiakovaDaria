using System;

namespace task2
{
    delegate int Cast(double a);
    class Program
    {
        static void Main(string[] args)
        {
            ;
            Cast del1 = delegate (double p)
            {
                if ((int)p % 2 == 0) { return (int)p; }
                else { return (int)(p + 1); }
            };
            Cast del2 = delegate (double m)
            {
                return (int)Math.Log10(m) + 1;
            };
            double num = 2.8346;
            double num2 = 7.32;
            Cast multcast = del1;
            multcast += del2;
            Console.WriteLine("del1 test:");
            Console.WriteLine(del1(num));
            Console.WriteLine(del1(num2));
            Console.WriteLine("del2 test:");
            Console.WriteLine(del2(num));
            Console.WriteLine(del2(num2));
            Console.WriteLine("multcast test:");
            Console.WriteLine(multcast(num));
            Console.WriteLine(multcast(num2));
        }
    }
}
