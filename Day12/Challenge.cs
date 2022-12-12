using BaseSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayTwelve
{
    public class Challenge : IChallenge
    {
        public string output = "";
        public int PartOne(string data)
        {
            char[][] matrix = CreateMatrix(data);
            (int X, int Y) startPoint = FindValue(matrix, 'S');
            if(startPoint.X == -1 || startPoint.Y == -1)
            {
                throw new IndexOutOfRangeException("Could not find start point");
            }
            (int X, int Y) endPoint = FindValue(matrix, 'E');
            if (endPoint.X == -1 || endPoint.Y == -1)
            {
                throw new IndexOutOfRangeException("Could not find end point");
            }
                        
            int currentX = startPoint.X;
            int currentY = startPoint.Y;
            int steps = 0;
            List<string> visited = new List<string>();
            visited.Add($"{currentX},{currentY}");
            char[][] moves = matrix;
            while (currentX != endPoint.X || currentY != endPoint.Y)
            {
                List<Tuple<int, int>> viable = GetViableMoves(matrix, currentX, currentY);

                Tuple<int, int>? next = viable.OrderBy(m=> (m.Item1 - endPoint.X) + (m.Item2 - endPoint.Y)).FirstOrDefault(m => !visited.Contains($"{m.Item1},{m.Item2}"));
                if (next != null)
                {
                    if(next.Item1 == currentX)
                    {
                        if(next.Item2 > currentY)
                        {
                            moves[currentX][currentY] = '>';
                        }
                        else
                        {
                            moves[currentX][currentY] = '<';
                        }
                    }
                    else
                    {
                        if (next.Item1 > currentX)
                        {
                            moves[currentX][currentY] = 'V';
                        }
                        else
                        {
                            moves[currentX][currentY] = '^';
                        }
                    }
                    steps++;
                    currentX = next.Item1;
                    currentY = next.Item2;
                    visited.Add($"{next.Item1},{next.Item2}");
                }
                else
                {

                }
            }

            output = string.Join(Environment.NewLine, moves.Select(m => string.Join("", m)));
            return steps;

        }


        public int PartTwo(string data)
        {
            throw new NotImplementedException();
        }

        char[][] CreateMatrix(string data)
        {
            return data.Split(Environment.NewLine).Select(m => m.ToArray()).ToArray();
        }

        (int X, int Y) FindValue(char[][] matrix, char value)
        {
            for(int i = 0; i < matrix.Length; i++)
            {
                for(int j = 0;j < matrix[i].Length; j++)
                {
                    if(matrix[i][j] == value)
                    {
                        return (i, j);
                    }
                }
            }

            return (-1, -1);
        }
        //zz
        int GetValue(Char input)
        {
            if(input == 'S')
            {
                return (int)'a';
            }
            if(input == 'E')
            {
                return (int)'z';
            }
            return (int)input;            
        }

        bool CanMove(Char current, Char target)
        {
            return Math.Abs(GetValue(current) - GetValue(target)) < 2;
        }

        List<Tuple<int,int>> GetViableMoves(char[][] matrix, int currentX, int currentY)
        {
            List<Tuple<int,int>> result = new List<Tuple<int,int>>();
            Char current = matrix[currentX][currentY];
            for(int i = currentX - 1;i <= currentX + 1;i += 2)
            {
                if (i < 0 || i >= matrix.Length) continue;

                if (CanMove(current, matrix[i][currentY]))
                {
                    result.Add(new Tuple<int,int>(i, currentY));
                }
            }

            for(int i = currentY - 1;i <= currentY + 1;i += 2)
            {
                if (i < 0 || i >= matrix[currentX].Length) continue;
                if (CanMove(current, matrix[currentX][i]))
                {
                    result.Add(new Tuple<int, int>(currentX,i));
                }
            }

            return result;
        }
    }
}
