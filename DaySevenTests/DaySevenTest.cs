using DaySeven;

namespace DaySevenTests
{
    public class DaySevenTest
    {
        string _data;
        public DaySevenTest()
        {
            _data = File.ReadAllText("./TestData/testInput.txt");
        }
        [Theory]
        [InlineData(7, "mjqjpqmgbljsphdztnvjfqwrcgsmlb")]
        public void PartOne(int expected, string value)
        {

            Challenge uot = new Challenge();

            int actual = uot.PartOne(value);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(19, "mjqjpqmgbljsphdztnvjfqwrcgsmlb")]
        public void PartTwo(int expected, string value)
        {
            Challenge uot = new Challenge();

            int actual = uot.PartTwo(value);
            Assert.Equal(expected, actual);
        }
    }
}