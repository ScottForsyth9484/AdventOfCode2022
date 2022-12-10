using BaseSetup;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayEight
{
    public class Challenge : IChallenge
    {
        public int PartOne(string data)
        {
            int[][] d = data.Split(Environment.NewLine).Select(m => m.ToCharArray().Select(k => int.Parse(k.ToString())).ToArray()).ToArray();
            int cols = d[0].Length;
            int visible = 0;
            visible += (cols * 2) + ((d.Length * 2) - 4);
            bool shouldBreak = true;
            for(int i = 1, l = d.Length - 1; i < l; i++) //Each Row
            {
                for (int j = 1; j < cols - 1; j++) //Each col
                {
                    shouldBreak = true;
                    int height = d[i][j];

                    for (int c = 0; c < i; c++) //Rows Above
                    {
                        if (d[c][j] >= height) //one is higher so not visible
                        {                            
                            shouldBreak = false;
                            break;
                        }
                    }
                    if (shouldBreak) {
                        visible++;
                        continue; }
                    shouldBreak = true;
                    for (int c = i + 1; c <= l; c++) //Rows Below
                    {
                        if (d[c][j] >= height)//one is higher so not visible
                        {
                            shouldBreak = false;
                            break;
                        }
                    }
                    if (shouldBreak)
                    {
                        visible++;
                        continue;
                    }
                    shouldBreak = true;
                    for (int r = 0; r < j; r++)//Columns left
                    {
                        if (d[i][r] >= height)//one is higher so not visible
                        {
                            shouldBreak = false;
                            break;
                        }
                    }

                    if (shouldBreak)
                    {
                        visible++;
                        continue;
                    }
                    shouldBreak = true;
                    for (int r = j + 1; r < cols; r++)//Columns right
                    {
                        if (d[i][r] >= height)//one is higher so not visible
                        {
                            shouldBreak = false;
                            break;
                        }
                    }

                    if (shouldBreak)
                    {
                        visible++;
                    }
                }
            }

            return visible;
        }

        public int PartTwo(string data)
        {
            int[][] d = data.Split(Environment.NewLine).Select(m => m.ToCharArray().Select(k => int.Parse(k.ToString())).ToArray()).ToArray();
            int cols = d[0].Length;
            int maxScore = 0;
            bool shouldBreak = true;
            for (int i = 1, l = d.Length - 1; i < l; i++) //Each Row
            {
                for (int j = 1; j < cols - 1; j++) //Each col
                {
                    int height = d[i][j];
                    int score = 0;
                    int counter = 0;
                    for (int c = i - 1; c >= 0; c--) //Rows Above
                    {
                        counter++;
                        if (d[c][j] >= height) //one is higher so not visible
                        {                            
                            break;
                        }
                    }
                    score = counter;
                    counter = 0;
                    for (int c = i + 1; c <= l; c++) //Rows Below
                    {
                        counter++;
                        if (d[c][j] >= height)//one is higher so not visible
                        {
                            score *= counter;
                            break;
                        }
                    }
                    counter = 0;
                    for (int r = j - 1; r >=0; r--)//Columns left
                    {
                        counter++;
                        if (d[i][r] >= height)//one is higher so not visible
                        {                            
                            break;
                        }
                    }
                    score *= counter;

                    counter = 0;
                    for (int r = j + 1; r < cols; r++)//Columns right
                    {
                        counter++;
                        if (d[i][r] >= height)//one is higher so not visible
                        {
                            break;
                        }
                    }
                    score *= counter;
                    if (score > maxScore)
                    {
                        maxScore = score;
                    }
                }
            }

            return maxScore;
        }
    }
}
