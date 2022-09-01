namespace SLCU
{
    public class WeatherData
    {
        public int Day { get; set; }
        public int High { get; set; }
        public int Low { get; set; }
        public int Range { get; set; }

        public WeatherData() { }

        public WeatherData(int day, int high, int low)
        {
            Day = day;
            High = high;
            Low = low;            
        }

        public WeatherData(int day, int high, int low, int range)
        {
            Day = day;
            High = high;
            Low = low;           
            Range = range;
        }
    }
}
