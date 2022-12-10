using DayNine;
using System.Diagnostics;

namespace DayNineTests
{
    public class DayNineTest
    {
        string _data, _data2;
        public DayNineTest()
        {
            _data = File.ReadAllText("./TestData/testInput.txt");
            _data2 = File.ReadAllText("./TestData/testInput2.txt");
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
        }
        [Fact]
        public void PartOne()
        {
            long expected = 13;
            Challenge uot = new Challenge();

            long actual = uot.PartOne(_data);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(true,0,0,0,0)]
        [InlineData(true, 0, 0, 1, 0)]
        [InlineData(true, 0, 0, 1, 1)]
        [InlineData(false, 0, 0, 1, 2)]
        [InlineData(false, 0, 0, 2, 2)]
        [InlineData(false, 0, 0, -1, -2)]
        [InlineData(true, -1, -1, -2, -2)]
        [InlineData(true, -1, -1, -1, -2)]
        [InlineData(false, -1, -1, 1, -1)]
        [InlineData(false, -3, -2, -1, -4)]
        public void CloseProximity(bool expected,int tailRow, int tailColumn, int headRow, int headColumn)
        {
            Challenge uot = new Challenge();

            bool actual = uot.InCloseProximity(tailColumn, tailRow, headColumn, headRow);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("", 0, 0, 0, 0)]
        [InlineData("", 0, 0, 1, 0)]
        [InlineData("", 0, 0, 1, 1)]
        [InlineData("R", 0, 0, 0, 2)]
        [InlineData("U", 0, 0, 2, 0)]
        [InlineData("D", 0, 0, -2,0)]
        [InlineData("L", -1, -1, -1, -3)]
        [InlineData("UR", 0, 0, 1, 2)]
        [InlineData("DR", 0, 0, -2, 1)]
        [InlineData("UL", 0, 0, 2, -1)]
        [InlineData("DL", 0, 0, -1, -2)]
        [InlineData("UL", -3, -2, -1, -4)]
        public void ViableMove(string expected, int tailRow, int tailColumn, int headRow, int headColumn)
        {
            Challenge uot = new Challenge();

            string actual = uot.GetViableMove(tailColumn, tailRow, headColumn, headRow).dir;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartTwo1()
        {
            long expected = 1;
            Challenge uot = new Challenge();

            long actual = uot.PartTwo(_data);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PartTwo2()
        {
            long expected = 36;
            Challenge uot = new Challenge();

            long actual = uot.PartTwo(_data2);
            Assert.Equal(expected, actual);
        }
    }
}