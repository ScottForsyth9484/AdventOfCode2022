namespace DayThree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] data = File.ReadAllLines("./input.txt");
            Console.WriteLine($"Priority sum = {Priority(data).Sum()}");
            Console.WriteLine($"Group Priority sum = {Part2(data)}");
        }

        static IEnumerable<int> Priority(string[] data) => data.Select(m => 
                new List<IEnumerable<char>>
                    {
                        m.Take((int)(m.Length / 2)),
                        m.Skip((int)(m.Length / 2))
                    })
            .Select(k => k[0].Where(c => k[1].Contains(c)).First())
            .Select(d=> GetValue(d));


        static int Part2(string[] data) => Enumerable.Range(0, data.Length / 3)
                .Select(i => data.Skip(i * 3).Take(3).ToArray())
                .Select(m => GroupPriority(m))
                .Sum();             

        static int GroupPriority(string[] data) => GetValue(data[0].First(m => data[1].Contains(m) && data[2].Contains(m)));

        

        static int GetValue(char c) => Char.IsLower(c) ? ((int)c) - 96 : ((int)c) - 38;
        
    }
}