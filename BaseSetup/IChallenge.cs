using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSetup
{
    public interface IChallenge
    {
        public int PartOne(string data);
        public int PartTwo(string data);
    }

    public interface IChallenge2
    {
        public string PartOne(string data);
        public string PartTwo(string data);
    }

    public interface IChallenge3
    {
        public long PartOne(string data);
        public long PartTwo(string data);
    }
}
