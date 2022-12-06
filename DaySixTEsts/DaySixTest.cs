using DaySix;
using Xunit;

namespace DaySixTEsts
{
    public class DaySixTest
    {
        string _data;
        public DaySixTest()
        {
            _data = File.ReadAllText("./TestData/testInput.txt");
        }
        [Theory]
        [InlineData(7, "mjqjpqmgbljsphdztnvjfqwrcgsmlb")]
        [InlineData(5, "bvwbjplbgvbhsrlpgdmjqwftvncz")]
        [InlineData(6, "nppdvjthqldpwncqszvftbrmjlhg")]
        [InlineData(10, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg")]
        [InlineData(11, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")]
        public void PartOne(int expected, string value)
        {
            
            Challenge uot = new Challenge();

            int actual = uot.PartOne(value);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(19, "mjqjpqmgbljsphdztnvjfqwrcgsmlb")]
        [InlineData(23, "bvwbjplbgvbhsrlpgdmjqwftvncz")]
        [InlineData(23, "nppdvjthqldpwncqszvftbrmjlhg")]
        [InlineData(29, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg")]
        [InlineData(26, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")]
        public void PartTwo(int expected, string value)
        {
            Challenge uot = new Challenge();

            int actual = uot.PartTwo(value);
            Assert.Equal(expected, actual);
        }
    }
}