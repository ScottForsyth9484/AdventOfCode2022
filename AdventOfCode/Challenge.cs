using BaseSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne
{
    public class Challenge : IChallenge
    {
        public int PartOne(string data)
        {
            return GroupedData(data).Max();
        }

        public int PartTwo(string data)
        {
            return GroupedData(data).OrderByDescending(m => m).Take(3).Sum();
        }


       IEnumerable<int> GroupedData(string data) => data.Split(Environment.NewLine + Environment.NewLine).Select(m =>
                m.Split(Environment.NewLine).Select(k => int.Parse(k)).Sum()
            );
    }
}
