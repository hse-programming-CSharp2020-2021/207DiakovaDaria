using System;
using System.Collections.Generic;

namespace task4
{
    class Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class Robot
    {
        // класс для представления робота
        int x, y; // положение робота на плоскости 
        int N;
        public Robot(int n)
        {
            N = n;
        }
        List<Point> points = new List<Point>();
        public void Right()
        {
            ++x;
            if (x > N)
            {
                Console.WriteLine(N);
                throw new ArgumentException("Робот вышел за границы поля!");
            }
            else
            {
                points.Add(Position());
            }
        }
        public void Left()
        {
            --x;
            if (x > N)
            {
                throw new ArgumentException("Робот вышел за границы поля!");
            }
            else
            {
                points.Add(Position());
            }
        }
        public void Forward()
        {
            ++y;
            if (y > N)
            {
                throw new ArgumentException("Робот вышел за границы поля!");
            }
            else
            {
                points.Add(Position());
            }
        }  // вперед
        public void Backward()
        {
            --y;
            if (y > N)
            {
                throw new ArgumentException("Робот вышел за границы поля!");
            }
            else
            {
                points.Add(Position());
            }
        }  // назад
        public Point Position()
        {  // сообщить координаты
            Point position = new Point(x, y);
            return position;
        }
        public bool Cont(Point el)
        {
            foreach (Point point in points)
            {
                if (el.x == point.x && el.y == point.y)
                {
                    return true;
                }
            }
            return false;
        }
        public void Out()
        {
            char[,] field = new char[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Point el = new Point(i, j);
                    Point f = Position();
                    if (f.x == el.x && f.y == el.y)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine('*');
                        Console.ResetColor();
                    }
                    else if (Cont(el))
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine('+');
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
        }
    }
    delegate void Steps(); // делегат-тип
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Введите ограничения координат на квадратное поле");
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Неверный ввод, попробуйте снова");
            }
            Console.WriteLine("Введите программу");
            string[] s = Console.ReadLine().Split(" ");
            for (int i = 0; i < s.Length; i++)
            {
                while (!s[i].Equals("R") && !s[i].Equals("L")
                    && !s[i].Equals("F") && !s[i].Equals("B") && !s[i].Equals("RF")
                    && !s[i].Equals("RB") && !s[i].Equals("LF") && !s[i].Equals("LB"))
                {
                    Console.WriteLine("Неверный ввод. Попробуйте снова");
                    s = Console.ReadLine().Split(" ");
                }
            }
            Robot rob = new Robot(n);    // конкретный робот 
            Steps path = delegate () { };
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case "R":
                        path += rob.Right;
                        break;
                    case "B":
                        path += rob.Backward;
                        break;
                    case "F":
                        path += rob.Forward;
                        break;
                    case "L":
                        path += rob.Left;
                        break;
                    case "RF":
                        path += rob.Right;
                        path += rob.Forward;
                        break;
                    case "RB":
                        path += rob.Right;
                        path += rob.Backward;
                        break;
                    case "LF":
                        path += rob.Left;
                        path += rob.Forward;
                        break;
                    case "LB":
                        path += rob.Left;
                        path += rob.Backward;
                        break;
                }
            }
            path += rob.Out;
            try
            {
                path?.Invoke();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            Console.WriteLine("Для завершения нажмите любую клавишу.");
            Console.ReadKey();

        }
    }
}
