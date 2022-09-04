using System;
using System.Collections.Generic;

namespace SLCU
{
    public class Program
    {
        static string weatherFile = "weather.dat";

        public static void Main(string[] args)
        {
            Console.WriteLine("Reading data file...");

            var days = new List<WeatherData>();

            var reader = new DataFileReader(weatherFile);
            var weatherData = reader.ParseFile();

            // First row is a header
            for (var x = 2; x < weatherData.Length - 3; x++)
            {
                var line = reader.ParseLine(weatherData[x]);
                var newDay = new WeatherData
                {
                    Day = line[1].ToString(),
                    High = Convert.ToInt32(line[2]),
                    Low = Convert.ToInt32(line[3])
                };
                days.Add(newDay);
            }

            var calculator = new WeatherRangeCalculator();
            var day = calculator.CalculateMinimumRange(days);

            Console.WriteLine("Worst plus/minus ratio:");
            Console.WriteLine($"Day: {day?.Day}, High Temperature: {day?.High}, Goals Against: {day?.Low}, Interval: {day?.Range}");
        }
    }
}

