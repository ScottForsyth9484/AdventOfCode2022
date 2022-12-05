using BaseSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayFive
{
    public class Challenge : IChallenge2
    {
        public string PartOne(string data)
        {
            string[] dataSets = data.Split(Environment.NewLine + Environment.NewLine);
            Stack<string>[] stacks = GetStacks(dataSets[0]);

            IEnumerable<Move> moves = dataSets[1].Split(Environment.NewLine)
                .Select(m => new Move(m));

            foreach(var move in moves)
            {
                for(int i = 0; i < move.Count; i++)
                {
                    string s = stacks[move.From].Pop();
                    stacks[move.To].Push(s);
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach(var stack in stacks)
            {
                sb.Append(stack.Pop());
            }

            return sb.ToString(); 
        }

        Stack<string>[] GetStacks(string data)
        {
            var rows = data.Replace("    ", " [@]").Replace("][","] [").Replace("[","").Replace("]","").Split(Environment.NewLine);
            int maxStacks = rows.Where(m => m.StartsWith(" 1")).First().Select(m => Char.IsNumber(m) ? int.Parse(m.ToString()) : 0).Max();
            Stack<string>[] stacks= new Stack<string>[maxStacks];
            rows.ToList().ForEach(m =>
            {
                var rowData = m.Trim().Split(" ");
                for (int i = 0; i < rowData.Length; i++)
                {
                    if(rowData[i] == "@" || rowData[i] == "" || Char.IsNumber(rowData[i][0]))
                    {
                        continue;
                    }

                    if (stacks[i] == null)
                    {
                        stacks[i] = new Stack<string>();
                    }

                    
                    stacks[i].Push(rowData[i]);
                }
            });
            for (int i = 0; i < stacks.Length; i++)
            {
                stacks[i] = new Stack<string>(stacks[i]);
            }

            return stacks;
            
        }

        public string PartTwo(string data)
        {
            string[] dataSets = data.Split(Environment.NewLine + Environment.NewLine);
            Stack<string>[] stacks = GetStacks(dataSets[0]);

            IEnumerable<Move> moves = dataSets[1].Split(Environment.NewLine)
                .Select(m => new Move(m));

            foreach (var move in moves)
            {
                Stack<string> movements = new Stack<string>();
                for (int i = 0; i < move.Count; i++)
                {
                    movements.Push(stacks[move.From].Pop());
                }

                foreach (var m in movements) {
                    stacks[move.To].Push(m);
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (var stack in stacks)
            {
                sb.Append(stack.Pop());
            }

            return sb.ToString(); 
        }
    }

    public struct Move
    {
        public int Count { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public Move(string movement)
        {
            string[] parsed = movement.Split(" ");
            Count = int.Parse(parsed[1]);
            From = int.Parse(parsed[3]) -1;
            To = int.Parse(parsed[5]) -1;

        }
    }
}
