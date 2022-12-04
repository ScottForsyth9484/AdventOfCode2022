using BaseSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayFour
{
    public class Challenge : IChallenge
    {
        public int PartOne(string data)
        {
            return data.Split(Environment.NewLine)
                .Select(m => m.Split(","))
                .Select(m => FullyOverlap(m))
                .Sum();           
        }

        public int PartTwo(string data)
        {
            return data.Split(Environment.NewLine)
                .Select(m => m.Split(","))
                .Select(m => PartiallyOverlap(m))
                .Sum();
        }

        int FullyOverlap(string[] assignments)
        {
            Scores elf1 = new Scores(assignments[0]);
            Scores elf2 = new Scores(assignments[1]);

            if((elf1.Min >= elf2.Min && elf1.Max <= elf2.Max) ||
                (elf2.Min >= elf1.Min && elf2.Max <= elf1.Max))
            {
                return 1;
            }

            return 0;
        }

        int PartiallyOverlap(string[] assignments)
        {
            Scores elf1 = new Scores(assignments[0]);
            Scores elf2 = new Scores(assignments[1]);

            if ((elf1.Min >= elf2.Min && elf1.Min <= elf2.Max) ||
                (elf2.Min >= elf1.Min && elf2.Min <= elf1.Max))
            {
                return 1;
            }

            return 0;
        }
    }

    public struct Scores
    {

        public Scores(string range)
        {
            
            string[] data = range.Split("-");
            Min = int.Parse(data[0]);
            Max = int.Parse(data[1]);
        }
        public int Min { get; set; }
        public int Max { get; set; }
    }

}
