using BaseSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTen
{
    public class Challenge : IChallenge4
    {
        readonly List<int> _signalStrengthPoints = new List<int>
            {
                20,60,100,140,180,220
            };
        public int PartOne(string data)
        {
            int X = 1;
            int cycle = 0;
            
            int signalStrength = 0;
            foreach(var instruction in data.Split(Environment.NewLine))
            {
                var input = ParseInstruction(instruction);
                switch (input.cmd)
                {
                    case "noop":
                        cycle++;
                        signalStrength += GetSignalStrength(cycle, X);
                        break;
                    case "addx":
                        for(int i = 0;i < 2; i++)
                        {
                            cycle++;
                            signalStrength += GetSignalStrength(cycle, X);
                        }
                        X += input.val;
                        break;
                }
            }

            return signalStrength;
        }

        int GetSignalStrength(int cycle, int x)
        {
            if (!_signalStrengthPoints.Contains(cycle)) return 0;

            return cycle * x;
        }

        (string cmd, int val) ParseInstruction(string instruction)
        {
            string[] data = instruction.Split(" ");
            return (data[0], data.Length == 1 ? 0 : int.Parse(data[1]));
        }

        public string PartTwo(string data)
        {
            int X = 1;
            int cycle = 0;
            string[] crt = new string[240];
            int pixel = 0;
            foreach (var instruction in data.Split(Environment.NewLine))
            {
                var input = ParseInstruction(instruction);
                switch (input.cmd)
                {
                    case "noop":
                        int offsetPositionnoop = cycle - (40 * ((cycle / 40)));
                        cycle++;
                        if (offsetPositionnoop >= X - 1 && offsetPositionnoop <= X + 1)
                        {
                            crt[pixel] = "#";
                        }
                        else
                        {
                            crt[pixel] = ".";
                        }
                        pixel++;
                        break;
                    case "addx":
                        for (int i = 0; i < 2; i++)
                        {
                            int offsetPosition = cycle - (40 * ((cycle / 40)));
                            cycle++;
                            if(offsetPosition >= X-1 && offsetPosition <= X+1)
                            {
                                crt[pixel] = "#";
                            }
                            else
                            {
                                crt[pixel] = ".";
                            }
                            pixel++;
                        }
                        X += input.val;
                        break;
                }
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 6; i++){
                if (i == 5)
                {
                    sb.Append(string.Join("", crt.Skip(i * 40).Take(40)));
                }
                else
                {
                    sb.AppendLine(string.Join("", crt.Skip(i * 40).Take(40)));
                }
            }
            return sb.ToString();
        }

        
    }
}
