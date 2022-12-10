using DayEight;
using System.Diagnostics;

namespace DayEightTests
{
    public class DayEightTest
    {
        string _data;
        public DayEightTest()
        {
            _data = File.ReadAllText("./TestData/testInput.txt");
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
        }
        [Fact]
        public void PartOne()
        {
            long expected = 21;
            Challenge uot = new Challenge();

            long actual = uot.PartOne(_data);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartTwo()
        {
            long expected = 8;
            Challenge uot = new Challenge();

            long actual = uot.PartTwo(_data);
            Assert.Equal(expected, actual);
        }
    }
}