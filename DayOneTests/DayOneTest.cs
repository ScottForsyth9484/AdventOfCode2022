namespace DayOneTests
{
    public class DayOneTest
    {
        private readonly string _data;
        public DayOneTest()
        {
            _data = File.ReadAllText("./TestData/testInput.txt");
        }

        [Fact]
        public void PartOne()
        {
            var uot = new DayOne.Challenge();
            int expected = 24000;

            int actual = uot.PartOne(_data);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartTwo()
        {
            var uot = new DayOne.Challenge();
            int expected = 45000;

            int actual = uot.PartTwo(_data);
            Assert.Equal(expected, actual);
        }
    }
}