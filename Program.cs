using System;
using System.Collections.Generic;

namespace SLCU
{
    public class Program
    {
        static string weatherFile = @"C:\Users\chick\OneDrive\Documents\Career\Current Opportunities\Student Loan Credit Union\weather.dat";
        //static string soccerFile = @"C:\Users\chick\OneDrive\Documents\Career\Current Opportunities\Student Loan Credit Union\football.dat";

        public static void Main(string[] args)
        {
            Console.WriteLine("Reading data file...");

            var days = new List<WeatherData>();

            var reader = new DataFileReader();
            var weatherData = reader.ParseFile(weatherFile);

            // First two rows are headers and last row is a total
            for (var x = 2; x < weatherData.Length - 3; x++)
            {
                var line = reader.ParseLine(weatherData[x]);
                var newDay = new WeatherData
                {
                    Day = Convert.ToInt32(line[1]) > 0 ? Convert.ToInt32(line[1]) : 0,
                    High = Convert.ToInt32(line[2]) > 0 ? Convert.ToInt32(line[2]) : 0,
                    Low = Convert.ToInt32(line[3]) > 0 ? Convert.ToInt32(line[3]) : 0
                };
                days.Add(newDay);
            }

            var calculator = new WeatherRangeCalculator();
            var day = calculator.CalculateMinimumRange(days);

            Console.WriteLine("Smallest temperature spread:");
            Console.WriteLine($"Day: {day?.Day}, High: {day?.High}, Low {day?.Low}, Spread {day?.Range}");
        }
    }
}

