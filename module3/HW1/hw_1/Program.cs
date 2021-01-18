using System;

namespace task3
{
    delegate double delegateConvertTemperature(double a);
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
            TemperatureConverterImp obj = new TemperatureConverterImp();
            double tempCel = 55.51;
            double tempFar = 33.3;
            delegateConvertTemperature CToF = new delegateConvertTemperature(obj.CelsiusToFarenheit);
            delegateConvertTemperature FToC = new delegateConvertTemperature(obj.CelsiusToFarenheit);
            Console.WriteLine($"{CToF?.Invoke(tempCel):f3}");
            Console.WriteLine($"{FToC?.Invoke(tempFar):f3}");
        }
    }
}
