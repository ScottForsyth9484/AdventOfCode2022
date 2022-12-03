using DayThree;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace DayThreeTests
{
    public class DayThreeTest
    {
        private readonly string _data;
        public DayThreeTest()
        {
            _data = File.ReadAllText("./TestData/testInput.txt");
        }

        [Fact]
        public void PartOne()
        {
            Challenge uot = new Challenge();
            int expected = 157;

            int actual = uot.PartOne(_data);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartTwo()
        {
            Challenge uot = new Challenge();
            int expected = 70;

            int actual = uot.PartTwo(_data);
            Assert.Equal(expected, actual);
        }
    }
}