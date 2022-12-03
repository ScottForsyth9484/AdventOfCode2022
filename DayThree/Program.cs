namespace DayThree
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            string data = File.ReadAllText("./input.txt");
            Challenge challenge = new Challenge();
            Console.WriteLine($"Priority sum = {challenge.PartOne(data)}");
            Console.WriteLine($"Group Priority sum = {challenge.PartTwo(data)}");
        }              
        
    }
}