using System.Collections.Generic;
using System.Linq;

namespace SLCU3
{
    public class Calculator : ICalculator<Data>
    {
        public Data? GetSmallestInterval(List<Data> data)
        {
            var ids = new List<Data>();

            if (data.Count > 0)
            {
                foreach (var row in data)
                {
                    var newRow = new Data
                    {
                        Id = !string.IsNullOrEmpty(row.Id) ? row.Id : string.Empty,
                        FirstField = row.FirstField,
                        SecondField = row.SecondField,
                        Interval = row.FirstField - row.SecondField
                    };
                    ids.Add(newRow);
                }
            }

            return ids
                .OrderBy(d => d.Interval)
                .FirstOrDefault();            
        }
    }
}
