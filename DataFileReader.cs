using System;
using System.IO;
using System.Text.RegularExpressions;

namespace SLCU3
{
    public class DataFileReader 
    {
        private readonly string? basePath;
        private readonly string? baseDirectory;
        private string fileName;

        public DataFileReader(string path)
        {
            basePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            baseDirectory = Path.GetDirectoryName(basePath);
            fileName = $"{baseDirectory}\\{path}";
        }
       
        public string[] ParseFile()
        {
            return File.ReadAllText(fileName).Split(new string[] { "\n" }, StringSplitOptions.None);           
        }

        public string[] ParseLine(string line)
        {
            return Regex.Split(line, @"\s+");
        }
    }
}
