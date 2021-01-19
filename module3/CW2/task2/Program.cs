using System;

namespace task2
{
    delegate string ConvertRule(string str);
    class Converter
    {
        public string Convert(string str, ConvertRule cr)
        {
            return(cr(str));
        }
    }
    class Program
    {
        public static string RemoveDigits(string str)
        {
            string newStr = "";
            for (int i = 0; i < str.Length; i++)
            {
                if ((int)str[i] > 57 || (int)str[i] < 48)
                {
                    newStr += str[i];
                }
            }
            return newStr;
        }

        public static string RemoveSpaces(string str)
        {
            string newStr = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    newStr+=str[i];
                }
            }
            return newStr;
        }

        static void Main(string[] args)
        {
            string[] test = { "NewString  1", "dgtedndhb", "_123Del;sf_!1 ", " 1a ", "3jh3hj 2!" };
            ConvertRule cr = new ConvertRule(RemoveDigits);
            foreach (string elem in test)
            {
                Console.WriteLine(RemoveDigits(elem));
            }
            Console.WriteLine();
            foreach (string elem in test)
            {
                Console.WriteLine(RemoveSpaces(elem));
            }
            Console.WriteLine();
            Converter conv = new Converter();
            foreach (string elem in test)
            {
                Console.WriteLine(conv.Convert(elem, cr));
            }
            cr += RemoveSpaces;
            Console.WriteLine();
            foreach (string elem in test)
            {
                Console.WriteLine(conv.Convert(elem, cr));
            }
        }
    }
}
