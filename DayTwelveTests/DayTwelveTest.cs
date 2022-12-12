using DayTwelve;

namespace DayTwelveTests
{
    public class DayTwelveTest
    {
        string _data;
        public DayTwelveTest()
        {
            _data = File.ReadAllText("./TestData/testInput.txt");
        }
        [Fact]
        public void PartOne()
        {
            long expected = 31;
            Challenge uot = new Challenge();

            long actual = uot.PartOne(_data);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartTwo()
        {
            long expected = 2713310158;
            Challenge uot = new Challenge();

            long actual = uot.PartTwo(_data);
            Assert.Equal(expected, actual);
        }
    }
}