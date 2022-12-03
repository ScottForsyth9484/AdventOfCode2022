using BaseSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayThree
{
    public class Challenge : IChallenge
    {
        public int PartOne(string data) => data.Split(Environment.NewLine).Select(m => 
                new List<IEnumerable<char>>
                    {
                        m.Take(m.Length / 2),
                        m.Skip(m.Length / 2)
                    })
            .Select(k => k[0].First(c => k[1].Contains(c)))
            .Select(d=> GetValue(d))
            .Sum();

        public int PartTwo(string data) => Enumerable.Range(0, data.Split(Environment.NewLine).Length / 3)
                .Select(i => data.Split(Environment.NewLine).Skip(i * 3).Take(3).ToArray())
                .Select(m => GroupPriority(m))
                .Sum();

        int GroupPriority(string[] data) => GetValue(data[0].First(m => data[1].Contains(m) && data[2].Contains(m)));

        int GetValue(char c) => Char.IsLower(c) ? ((int)c) - 96 : ((int)c) - 38;
    }
}
