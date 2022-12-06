using BaseSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaySix
{
    public class Challenge : IChallenge
    {
        public int PartOne(string data)
        {
            for(int i = 0;i < data.Length; i++)
            {
              if(data.Skip(i).Take(4).GroupBy(m=>m).Any(k=>k.Count() > 1))
                {
                    continue;
                }
              return i + 4;
            }
            return data.Length;
        }

        public int PartTwo(string data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data.Skip(i).Take(14).GroupBy(m => m).Any(k => k.Count() > 1))
                {
                    continue;
                }
                return i + 14;
            }
            return data.Length;
        }
    }
}
