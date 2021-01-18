using System;

namespace task3
{
    delegate double delegateConvertTemperature(double a);
    static class StaticTempConverters
    {
        public static double CelsiusToKelvin(double cel)
        {
            return (double)(cel + 273.15);
        }
        public static double KelvinToCelsius(double kel)
        {
            return (double)(kel - 273.15);
        }
        public static double ReaumurToCelsius(double rem)
        {
            return (double)(5 / 4 * rem);
        }
        public static double CelsiusToReaumur(double cel)
        {
            return (double)(4 / 5 * cel);
        }
        public static double CelsiusToRankin(double cel)
        {
            return (double)(9 / 5 * (cel + 273.15));
        }
        public static double RankinToCelsius(double ran)
        {
            return (double)(5 / 9 * (ran - 491.67));
        }
    }
    class TemperatureConverterImp
    {
        public double CelsiusToFarenheit(double cel)
        {
            return (double)(9 / 5 * cel + 32);
        }
        public double FarenheitToCelsius(double far)
        {
            return (double)(5 / 9 * (far - 32));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TemperatureConverterImp obj1 = new TemperatureConverterImp();
            delegateConvertTemperature[] TempConvert = new delegateConvertTemperature[8];
            TempConvert[0] = new delegateConvertTemperature(obj1.CelsiusToFarenheit);
            TempConvert[1] = new delegateConvertTemperature(obj1.FarenheitToCelsius);
            TempConvert[2] = new delegateConvertTemperature(StaticTempConverters.CelsiusToKelvin);
            TempConvert[3] = new delegateConvertTemperature(StaticTempConverters.KelvinToCelsius);
            TempConvert[4] = new delegateConvertTemperature(StaticTempConverters.CelsiusToRankin);
            TempConvert[5] = new delegateConvertTemperature(StaticTempConverters.RankinToCelsius);
            TempConvert[6] = new delegateConvertTemperature(StaticTempConverters.CelsiusToReaumur);
            TempConvert[7] = new delegateConvertTemperature(StaticTempConverters.ReaumurToCelsius);
            double temp;
            while (!double.TryParse(Console.ReadLine(), out temp))
            {
                Console.WriteLine("Error");
            }
            foreach (var elem in TempConvert)
            {
                Console.WriteLine($"{elem?.Invoke(temp):f3}");
            }
        }
    }
}
