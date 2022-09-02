using System.Collections.Generic;
using System.Linq;

namespace SLCU2
{
    public class PlusMinusCalculator
    {
        public FootballData? CalculatePlusMinus(List<FootballData> teams)
        {
            foreach (var team in teams)
            {
                team.PlusMinus = team.GoalsFor - team.GoalsAgainst;
            }

            return teams
                .OrderBy(t => t.PlusMinus)
                .FirstOrDefault();
        }
    }
}
