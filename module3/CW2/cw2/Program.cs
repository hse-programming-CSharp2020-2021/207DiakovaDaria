using System;

namespace cw2
{
    class Plant
    {
        private double growth;
        private double photosensitivity;
        private double frostresistance;
        public double Frostresistance
        {
            get
            {
                return frostresistance;
            }
            set
            {
                if (value > 100 || value < 0)
                {
                    throw new ArgumentException("Морозоустойчивость может только в промежутке от 0 до 100!");
                }
                else
                {
                    frostresistance = value;
                }
            }
        }
        public double Photosensitivity
        {
            get
            {
                return photosensitivity;
            }
            set
            {
                if (value > 100 || value < 0)
                {
                    throw new ArgumentException("Светочуствительность может только в промежутке от 0 до 100!");
                }
                else
                {
                    photosensitivity = value;
                }
            }
        }
        public double Growth
        {
            get
            {
                return growth;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Рост не может быть отрицательным!");
                }
                else
                {
                    growth = value;
                }
            }
        }
        public Plant(double growth, double photosensitivity, double frostresistance)
        {
            this.growth = growth;
            this.photosensitivity = photosensitivity;
            this.frostresistance = frostresistance;
        }

        public override string ToString()
        {
            return $"Growth: {growth:f3}; Photosensivity: {photosensitivity:f3}; Frostresistance: {frostresistance:f3}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) && n <= 0)
            {
                Console.WriteLine("Неверный ввод. Попробуйте еще раз!");
            }
            Plant[] plants = new Plant[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                plants[i] = new Plant(rnd.Next(25, 100) + rnd.NextDouble(), 
                    rnd.Next(0, 100) + rnd.NextDouble(), 
                    rnd.Next(0, 80) + rnd.NextDouble());
            }
            Console.WriteLine("Исходный массив растений:");
            Array.ForEach(plants, pl => Console.WriteLine(pl));

            Array.Sort(plants, (pl1, pl2) =>
            {
                if (pl1.Growth > pl2.Growth)
                    return 1;
                else return -1;
            });
            Console.WriteLine("Массив после сортировки по росту:");
            Array.ForEach(plants, pl => Console.WriteLine(pl));

            Array.Sort(plants, (pl1, pl2) =>
            {
                if (pl1.Frostresistance > pl2.Frostresistance)
                    return 1;
                else return -1;
            });
            Console.WriteLine("Массив после сортировки по морозоустойчивости:");
            Array.ForEach(plants, pl => Console.WriteLine(pl));

            Array.Sort(plants, (pl1, pl2) =>
            {
                if (pl1.Photosensitivity > pl2.Photosensitivity)
                    return 1;
                else return -1;
            });
            Console.WriteLine("Массив после сортировки по светочувствительности:");
            Array.ForEach(plants, pl => Console.WriteLine(pl));
        }
    }
}
