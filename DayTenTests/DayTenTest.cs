using DayTen;
using System.Diagnostics;

namespace DayTenTests
{
    public class DayTenTest
    {
        string _data;
        public DayTenTest()
        {
            _data = File.ReadAllText("./TestData/testInput.txt");
        }
        [Fact]
        public void PartOne()
        {
            long expected = 13140;
            Challenge uot = new Challenge();

            long actual = uot.PartOne(_data);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartTwo()
        {
            string expected = @"##..##..##..##..##..##..##..##..##..##..
###...###...###...###...###...###...###.
####....####....####....####....####....
#####.....#####.....#####.....#####.....
######......######......######......####
#######.......#######.......#######.....";
            Challenge uot = new Challenge();

            string actual = uot.PartTwo(_data);
            Assert.Equal(expected, actual);
        }

    }
}