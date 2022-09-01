using System;
using System.IO;
using System.Text.RegularExpressions;

namespace SLCU
{
    public class DataFileReader
    {
        public string[] ParseFile(string path)
        {
            string[] lines = File.ReadAllText(path).Split(new string[] { "\n" }, StringSplitOptions.None);
            return lines;
        }

        public string[] ParseLine(string line)
        {
            //string[] fields = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string[] fields = Regex.Split(line, @"\s+");
            return fields;
        }
    }
}
