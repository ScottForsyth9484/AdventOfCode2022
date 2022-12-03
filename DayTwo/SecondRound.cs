using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTwo
{
    internal class SecondRound
    {
        public SecondRound(string input)
        {
            Split(input);
        }
        public int Player { get; set; }
        void Split(string input)
        {
            string[] values = input.Split(" ");

            values[1] = GetPlay(values);
            Player = Value(values[1]);
            Player += (int)GetOutcome(values);
        }

        string GetPlay(string[] val)
        {
            if (val[1] == "Y") return val[0];
            switch (val[0])
            {
                case "A" when val[1] == "X":
                    return "C";
                case "A":
                    return "B";
                case "B" when val[1] == "X":
                    return "A";
                case "B":
                    return "C";
                case "C" when val[1] == "X":
                    return "B";
                default: return "A";

            }
        }

        int Value(string val)
        {
            switch (val)
            {
                case "A":
                case "X": return 1;
                case "B":
                case "Y": return 2;
                case "C":
                case "Z": return 3;
            }

            return 0;
        }

        outcome GetOutcome(string[] val)
        {
            if (val[0] == val[1])
            {
                return outcome.Draw;
            }
            //Rock beats scissors
            //Paper beats Rock
            //Scissors beats Paper
            if ((val[0] == "A" && val[1] == "C") || (val[0] == "B" && val[1] == "A") || (val[0] == "C" && val[1] == "B"))
            {
                return outcome.Lose;
            }

            return outcome.Win;
        }

    }
}
