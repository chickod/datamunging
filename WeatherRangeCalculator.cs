using System.Collections.Generic;
using System.Linq;

namespace SLCU
{
    internal class WeatherRangeCalculator
    {
        public WeatherData? CalculateMinimumRange(List<WeatherData> days)
        {
            foreach (var day in days)
            {
                day.Range = day.High - day.Low;
            }

            return days
                .OrderByDescending(d => d.Range)
                .FirstOrDefault();
        }
    }
}
