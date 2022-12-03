using System.Diagnostics.CodeAnalysis;
using System.Windows.Markup;

namespace DayTwo
{
    public class Program
    {
        static void Main(string[] args)
        {
            string data = File.ReadAllText("input.txt");
            Challenge challenge = new Challenge();
            Console.WriteLine($"Total score: {challenge.PartOne(data)}");
            Console.WriteLine($"New Total score: {challenge.PartTwo(data)}");
        }       
    }      
}