using System.ComponentModel.DataAnnotations;

namespace DayOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<long> data = GroupedData(File.ReadAllText("input.txt"));

            Console.WriteLine($"new max is {data.Max()}");
            Console.WriteLine($"new top 3 total is {data.OrderByDescending(m=>m).Take(3).Sum()}");

        }

        static IEnumerable<long> GroupedData (string data) => data.Split(Environment.NewLine + Environment.NewLine).Select(m =>
                m.Split(Environment.NewLine).Select(k => long.Parse(k)).Sum()
            );
    }
}