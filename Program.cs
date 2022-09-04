namespace SLCU3
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            string weatherFile = "weather.dat";
            string footballFile = "football.dat";
            List<Data> weatherDays = new();
            List<Data> footballTeams = new();

            // Extract relevant fields from data file            
            if (!string.IsNullOrEmpty(weatherFile))
            {
                var reader = new DataFileReader(weatherFile);
                var weatherData = reader.ParseFile();
                
                for (var x = 2; x < weatherData.Length - 3; x++)
                {
                    var fields = reader.ParseLine(weatherData[x]);
                    var newDay = new Data
                    {
                        Id = fields[1],
                        FirstField = Convert.ToInt32(fields[2]),
                        SecondField = Convert.ToInt32(fields[3])
                    };
                    weatherDays.Add(newDay);
                }
            } 

            // Extract relevant fields from data file
            if (!string.IsNullOrEmpty(footballFile))
            {
                var reader = new DataFileReader(footballFile);
                var footballData = reader.ParseFile();

                for (var x = 1; x < footballData.Length - 5; x++)
                {
                    var fields = reader.ParseLine(footballData[x]);
                    var newTeam = new Data
                    {
                        Id = fields[2],
                        FirstField = Convert.ToInt32(fields[7]),
                        SecondField = Convert.ToInt32(fields[9])
                    };
                    footballTeams.Add(newTeam);
                }
            }

            // Calculate minimum values (temperature range for weather data and plus/minus for football data)
            var calc = new Calculator();
            var smallestDay = calc.GetSmallestInterval(weatherDays);
            var smallestPlusMinus = calc.GetSmallestInterval(footballTeams);

            // Print results to console window
            PrintResults(smallestDay, smallestPlusMinus);
        } 

        static void PrintResults(Data weather, Data football)
        {
            Console.WriteLine("Obtaining weather data...");
            Console.WriteLine("Smallest Daily Temperature Interval:");
            Console.WriteLine($"Day: {weather?.Id}, " +
                              $"High Temperature: {weather?.FirstField}, Low Temperature: {weather?.SecondField}, Interval: {weather?.Interval}");

            Console.WriteLine();

            Console.WriteLine("Obtaining football data...");
            Console.WriteLine("Worst Plus/Minus ratio:");
            Console.WriteLine($"Team: {football?.Id}, Goals For: {football?.FirstField}, " +
                              $"Goals Against: {football?.SecondField}, Plus/Minus: {football?.Interval}");
        }
    }
}

