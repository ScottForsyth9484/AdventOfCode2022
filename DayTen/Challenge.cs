using BaseSetup;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace DayEleven
{
    public class Challenge : IChallenge3
    {
        public long PartOne(string data)
        {
            return Process(data, 20, true);
            
        }
        long lcm;
        public long PartTwo(string data)
        {
            return Process(data, 10000, false);
        }

        long Process(string data, int rounds, bool worry)
        {
            string[] splitData = data.Split(Environment.NewLine + Environment.NewLine);
            Monkey[] monkeys = new Monkey[splitData.Length];
            for (int i = 0; i < splitData.Length; i++)
            {
                monkeys[i] = new Monkey(splitData[i]);
            }

            lcm = monkeys[0]._testDivisor;
            for (int i = 1; i < monkeys.Length; i++)
            {
                lcm = (long)Utilities.FindLCM(lcm, monkeys[i]._testDivisor);
            }
            
            for (int i = 0; i < rounds; i++)
            {
                for (int m = 0; m < monkeys.Length; m++)
                {
                    while (monkeys[m].Items.Any())
                    {
                        var result = monkeys[m].InspectAndTest(worry,lcm);
                        if (result.worryValue.HasValue && result.targetMonkey.HasValue)
                        {
                            monkeys[result.targetMonkey.Value].Items.Enqueue(result.worryValue.Value);
                        }
                    }
                }
            }

            return monkeys.OrderByDescending(m => m.InspectionCount).Take(2).Aggregate((long)1, (acc, val) => acc * val.InspectionCount);
        }
    }


    public class Monkey
    {
        
        private string _operator = "";
        private long _operatorValue;
        public long _testDivisor;
        private int _trueMonkey;
        private int _falseMonkey;
        private bool _operateItself = false;
        public Monkey(string setup)
        {
            string[] data = setup.Split(Environment.NewLine);
            data[1].Replace(" ","").Remove(0,14).Split(",").Select(x=> long.Parse(x)).ToList().ForEach(m=> Items.Enqueue(m));
            data[2].Split(" ").TakeLast(2).ToList().ForEach(m =>
            {
                if (long.TryParse(m, out long v))
                {
                    _operatorValue = v;
                }
                else if(m == "old")
                {
                    _operateItself = true;
                }
                else
                {
                    _operator = m;
                }
            });
            _testDivisor = long.Parse(data[3].Split(" ").Last());
            _trueMonkey = int.Parse(data[4].Split(" ").Last());
            _falseMonkey = int.Parse(data[5].Split(" ").Last());
        }
        public Queue<long> Items { get; private set; } = new Queue<long>();
        public long InspectionCount { get; private set; } = 0;
        public (int? targetMonkey, long? worryValue) InspectAndTest(bool worry,long lcm)
        {
            if (Items.Count == 0)
            {
                return (null, null);
            }
            
            long worryValue = Items.Dequeue();
            if (_operateItself)
            {
                _operatorValue = worryValue;
            }
            
            switch (_operator)
            {
                case "+": worryValue += _operatorValue; break;
                case "*": worryValue *= _operatorValue; break;
            }

            if (worry)
            {
                worryValue /= 3;
            }
            else
            {
                worryValue %= lcm;
            }
            int targetMonkey = _falseMonkey;

            if (worryValue % _testDivisor == 0)
            {
                targetMonkey = _trueMonkey;
            }
            InspectionCount++;
            return (targetMonkey, worryValue);
            
        }
    }
}
