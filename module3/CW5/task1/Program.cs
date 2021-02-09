using System;
using System.Collections.Generic;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int k;
            while (!int.TryParse(Console.ReadLine(), out k) && k <= 0)
            {
                Console.WriteLine("Неверный ввод");
            }
            LinkedList<int> numsList = new LinkedList<int>();
            Stack<int> numsStack = new Stack<int>();
            while (k != 0)
            {
                numsList.AddFirst(k % 10);
                numsStack.Push(k % 10);
                k /= 10;
            }
            foreach (int item in numsList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            numsStack.Peek();
            foreach (int item in numsStack)
            {
                Console.Write(item + " ");
            }
        }
    }
}
