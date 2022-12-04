using DayFive;
using System.Xml.Linq;

namespace DayFiveTests
{
    public class DayFiveTest
    {
        string _data;
        public DayFiveTest()
        {
            _data = File.ReadAllText("./TestData/testInput.txt");
        }
        [Fact]
        public void PartOne()
        {
            int expected = 0;
            Challenge uot = new Challenge();

            int actual = uot.PartOne(_data);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartTwo()
        {
            int expected = 0;
            Challenge uot = new Challenge();

            int actual = uot.PartTwo(_data);
            Assert.Equal(expected, actual);
        }
    }
}