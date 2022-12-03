using DayTwo;

namespace DayTwoTests
{
    public class DayTwoTest
    {
        private readonly string _data;
        public DayTwoTest()
        {
            _data = File.ReadAllText("./TestData/testInput.txt");
        }

        [Fact]
        public void PartOne()
        {
            Challenge uot = new Challenge();
            int expected = 15;

            int actual = uot.PartOne(_data);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartTwo()
        {
            Challenge uot = new Challenge();
            int expected = 12;

            int actual = uot.PartTwo(_data);
            Assert.Equal(expected, actual);
        }
    }
}