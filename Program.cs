using System;
using System.Collections.Generic;

namespace SLCU2
{
    public class Program
    {
        static string soccerFile = @"C:\Users\chick\OneDrive\Documents\Career\Current Opportunities\Student Loan Credit Union\football.dat";

        public static void Main(string[] args)
        {
            Console.WriteLine("Reading data file...");

            var teams = new List<FootballData>();

            var reader = new DataFileReader();
            var soccerData = reader.ParseFile(soccerFile);

            // First row is a header
            for (var x = 1; x < soccerData.Length - 5; x++)
            {
                var line = reader.ParseLine(soccerData[x]);
                var newTeam = new FootballData
                {
                    Team = line[2].ToString(),
                    GoalsFor = Convert.ToInt32(line[7]),
                    GoalsAgainst = Convert.ToInt32(line[9])
                };
                teams.Add(newTeam);
            }

            var calculator = new PlusMinusCalculator();
            var team = calculator.CalculatePlusMinus(teams);

            Console.WriteLine("Worst plus/minus ratio:");
            Console.WriteLine($"Team: {team?.Team}, Goals For: {team?.GoalsFor}, Goals Against: {team?.GoalsAgainst}, Plus/Minus: {team?.PlusMinus}");
        }
    }
}
