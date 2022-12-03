using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTwo
{
    internal class Round
    {
        public Round(string input)
        {
            Split(input);
        }
        public int Player { get; set; }
        void Split(string input)
        {
            string[] values = input.Split(" ");


            Player = Value(values[1]);
            Player += (int)GetOutcome(values);


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
            if (Value(val[0]) == Value(val[1]))
            {
                return outcome.Draw;
            }
            //Rock beats scissors
            //Paper beats Rock
            //Scissors beats Paper
            if ((val[0] == "A" && val[1] == "Z") || (val[0] == "B" && val[1] == "X") || (val[0] == "C" && val[1] == "Y"))
            {
                return outcome.Lose;
            }

            return outcome.Win;
        }

    }
}
