using BaseSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DayNine
{
    public class Challenge : IChallenge
    {
        //6105 - too high
        public int PartOne(string data)
        {

            HashSet<string> visited = new HashSet<string>();
            int TailColumn = 0, TailRow = 0;
            int HeadColumn = 0, HeadRow = 0;
            visited.Add($"{TailRow},{TailColumn}");
            Console.WriteLine($"Head\t{HeadRow},{HeadColumn}");
            Console.WriteLine($"Tail\t{TailRow},{TailColumn}");
            string[] steps = data.Split(Environment.NewLine);
            foreach(string inst in steps)
            {
                string[] instructions = inst.Split(" ");
                int value = int.Parse(instructions[1]);
                for(int i = 0;i < value; i++)
                {
                    //Move Head
                    switch (instructions[0])
                    {
                        case "U": HeadRow += 1;
                            break;
                        case "D":
                            HeadRow -= 1;
                            break;
                        case "L":
                            HeadColumn -= 1;
                            break;
                        case "R":
                            HeadColumn += 1;
                            break;
                    }
                    Console.WriteLine($"Head\t{HeadRow},{HeadColumn}");
                    //Move Tail
                    if (!InCloseProximity(TailColumn, TailRow, HeadColumn, HeadRow))
                    {
                        var move = GetViableMove(TailColumn, TailRow, HeadColumn, HeadRow);
                        switch (move.dir)
                        {
                            case "U":
                                TailRow += 1;
                                break;
                            case "D":
                                TailRow -= 1;
                                break;
                            case "L":
                                TailColumn -= 1;
                                break;
                            case "R":
                                TailColumn += 1;
                                break;
                            case "UR":
                                TailColumn += 1;
                                TailRow += 1;
                                break;
                            case "DR":
                                TailColumn += 1;
                                TailRow -= 1;
                                break;
                            case "UL":
                                TailColumn -= 1;
                                TailRow += 1;
                                break;
                            case "DL":
                                TailColumn -= 1;
                                TailRow -= 1;
                                break;
                        }
                    }

                    if (visited.Add($"{TailRow},{TailColumn}"))
                    {
                        Console.WriteLine($"Tail\t{TailRow},{TailColumn}");
                    }
                }                
            }

            return visited.Count;
        }

        public bool InCloseProximity(int tailColumn, int tailRow, int headColumn,int headRow)
        {
            if(Math.Abs(tailColumn - headColumn) > 1
                || Math.Abs(tailRow - headRow) > 1){
                return false;
            }
            return true;
        }

        public (string dir,int value) GetViableMove(int tailColumn, int tailRow, int headColumn, int headRow)
        {
            if(InCloseProximity(tailColumn,tailRow,headColumn,headRow))
            {
                return ("",0);//No move
            }

            //Same Row
            if(tailRow == headRow)
            {
                if(tailColumn < headColumn)
                {
                    return ("R", 1);
                }
                else
                {
                    return ("L", 1);
                }
            }
            //Same Column
            if(tailColumn == headColumn)
            {
                if(tailRow < headRow)
                {
                    return ("U", 1);
                }
                else
                {
                    return ("D", 1);
                }
            }

            if(tailRow < headRow) 
            {
                if(tailColumn < headColumn)
                {
                    return ("UR", 1);
                }
                else
                {
                    return ("UL", 1);
                }
            }
            if (tailColumn < headColumn)
            {
                return ("DR", 1);
                }
            else
            {
                return ("DL", 1);
            }

        }

        public int PartTwo(string data)
        {
            HashSet<string> visited = new HashSet<string>();
           
            Knot headKnot = new Knot();
            Knot[] knots = new Knot[9];
            for(int i = 0;i < 9; i++)
            {
                knots[i] = new Knot();
            }
            visited.Add($"{knots[8].Row},{knots[8].Column}");

            string[] steps = data.Split(Environment.NewLine);
            foreach (string inst in steps)
            {
                string[] instructions = inst.Split(" ");
                int value = int.Parse(instructions[1]);
                for (int i = 0; i < value; i++)
                {
                    //Move Head
                    switch (instructions[0])
                    {
                        case "U":
                            headKnot.Row += 1;
                            break;
                        case "D":
                            headKnot.Row -= 1;
                            break;
                        case "L":
                            headKnot.Column -= 1;
                            break;
                        case "R":
                            headKnot.Column += 1;
                            break;
                    }
                    for (int k = 0; k < 9; k++) {
                        Knot currentKnot = knots[k];
                        Knot prevKnot = k == 0 ? headKnot : knots[k - 1];
                        //Move Tail
                        if (!InCloseProximity(currentKnot.Column, currentKnot.Row, prevKnot.Column, prevKnot.Row))
                        {
                            var move = GetViableMove(currentKnot.Column, currentKnot.Row, prevKnot.Column, prevKnot.Row);
                            switch (move.dir)
                            {
                                case "U":
                                    knots[k].Row += 1;
                                    break;
                                case "D":
                                    knots[k].Row -= 1;
                                    break;
                                case "L":
                                    knots[k].Column -= 1;
                                    break;
                                case "R":
                                    knots[k].Column += 1;
                                    break;
                                case "UR":
                                    knots[k].Column += 1;
                                    knots[k].Row += 1;
                                    break;
                                case "DR":
                                    knots[k].Column += 1;
                                    knots[k].Row -= 1;
                                    break;
                                case "UL":
                                    knots[k].Column -= 1;
                                    knots[k].Row += 1;
                                    break;
                                case "DL":
                                    knots[k].Column -= 1;
                                    knots[k].Row -= 1;
                                    break;
                            }
                        }
                    }
                    visited.Add($"{knots[8].Row},{knots[8].Column}");
                    
                }
            }

            return visited.Count;
        }
    }

    struct Knot
    {
        public int Column { get; set; }
        public int Row { get; set; }
    }
}
