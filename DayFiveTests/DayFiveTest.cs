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
            string expected = "CMZ";
            Challenge uot = new Challenge();

            string actual = uot.PartOne(_data);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartTwo()
        {
            string expected = "MCD";
            Challenge uot = new Challenge();

            string actual = uot.PartTwo(_data);
            Assert.Equal(expected, actual);
        }
    }
}