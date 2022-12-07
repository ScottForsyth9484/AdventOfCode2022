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
        [Fact]
        public void PartOne()
        {
            long expected = 95437;
            Challenge uot = new Challenge();

            long actual = uot.PartOne(_data);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartTwo()
        {
            long expected = 24933642;
            Challenge uot = new Challenge();

            long actual = uot.PartTwo(_data);
            Assert.Equal(expected, actual);
        }
    }
}