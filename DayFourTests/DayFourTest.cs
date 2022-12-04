using DayFour;

namespace DayFourTests
{
    public class DayFourTest
    {
        string _data;
        public DayFourTest()
        {
            _data = File.ReadAllText("./TestData/testInput.txt");
        }
        [Fact]
        public void PartOne()
        {
            int expected = 2;
            Challenge uot = new Challenge();

            int actual = uot.PartOne(_data);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartTwo()
        {
            int expected = 4;
            Challenge uot = new Challenge();

            int actual = uot.PartTwo(_data);
            Assert.Equal(expected, actual);
        }
    }
}