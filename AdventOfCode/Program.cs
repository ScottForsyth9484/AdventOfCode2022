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

        static IEnumerable<long> GroupedData (string data) => data.Split("\r\n\r\n").Select(m =>
                m.Split("\r\n").Select(k => long.Parse(k)).Sum()
            );
    }
}