using BaseSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTwo
{
    public class Challenge : IChallenge
    {
        public int PartOne(string data)
        {
            return data.Split(Environment.NewLine).Select(m => new Round(m).Player).Sum();
        }

        public int PartTwo(string data)
        {
            return data.Split(Environment.NewLine).Select(m => new SecondRound(m).Player).Sum();
        }
    }
}
