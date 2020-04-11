using System;
using System.Collections.Generic;
using System.Linq;

namespace Roulette
{
    public class Wheel
    {
        public IList<Number> Numbers { get; }

        public Wheel()
        {
            Numbers = BuildNumbers();
            ValidateNumbers();
        }
        
        public Number Spin()
        {
            return Numbers[new Random(new Random().Next()).Next(Numbers.Count)];
        }

        private List<Number> BuildNumbers()
        {
            return new List<Number>
            {
                new Number
                {
                    Value = -1,
                    Color = Color.Green
                },
                new Number
                {
                    Value = 0,
                    Color = Color.Green
                },
                new Number
                {
                    Value = 1,
                    Color = Color.Red
                },
                new Number
                {
                    Value = 2,
                    Color = Color.Black
                },
                new Number
                {
                    Value = 3,
                    Color = Color.Red
                },
                new Number
                {
                    Value = 4,
                    Color = Color.Black
                },
                new Number
                {
                    Value = 5,
                    Color = Color.Red
                },
                new Number
                {
                    Value = 6,
                    Color = Color.Black
                },
                new Number
                {
                    Value = 7,
                    Color = Color.Red
                },
                new Number
                {
                    Value = 8,
                    Color = Color.Black
                },
                new Number
                {
                    Value = 9,
                    Color = Color.Red
                },
                new Number
                {
                    Value = 10,
                    Color = Color.Black
                },
                new Number
                {
                    Value = 11,
                    Color = Color.Black
                },
                new Number
                {
                    Value = 12,
                    Color = Color.Red
                },
                new Number
                {
                    Value = 13,
                    Color = Color.Black
                },
                new Number
                {
                    Value = 14,
                    Color = Color.Red
                },
                new Number
                {
                    Value = 15,
                    Color = Color.Black
                },
                new Number
                {
                    Value = 16,
                    Color = Color.Red
                },
                new Number
                {
                    Value = 17,
                    Color = Color.Black
                },
                new Number
                {
                    Value = 18,
                    Color = Color.Red
                },
                new Number
                {
                    Value = 19,
                    Color = Color.Red
                },
                new Number
                {
                    Value = 20,
                    Color = Color.Black
                },
                new Number
                {
                    Value = 21,
                    Color = Color.Red
                },
                new Number
                {
                    Value = 22,
                    Color = Color.Black
                },
                new Number
                {
                    Value = 23,
                    Color = Color.Red
                },
                new Number
                {
                    Value = 24,
                    Color = Color.Black
                },
                new Number
                {
                    Value = 25,
                    Color = Color.Red
                },
                new Number
                {
                    Value = 26,
                    Color = Color.Black
                },
                new Number
                {
                    Value = 27,
                    Color = Color.Red
                },
                new Number
                {
                    Value = 28,
                    Color = Color.Black
                },
                new Number
                {
                    Value = 29,
                    Color = Color.Black
                },
                new Number
                {
                    Value = 30,
                    Color = Color.Red
                },
                new Number
                {
                    Value = 31,
                    Color = Color.Black
                },
                new Number
                {
                    Value = 32,
                    Color = Color.Red
                },
                new Number
                {
                    Value = 33,
                    Color = Color.Black
                },
                new Number
                {
                    Value = 34,
                    Color = Color.Red
                },
                new Number
                {
                    Value = 35,
                    Color = Color.Black
                },
                new Number
                {
                    Value = 36,
                    Color = Color.Red
                }
            };
        }

        private void ValidateNumbers()
        {
            if (Numbers.Count(n => n.Color == Color.Green) != 2)
            {
                throw new Exception("Invalid wheel, wrong number of green");
            }
            if (Numbers.Count(n => n.Color == Color.Black) != 18)
            {
                throw new Exception("Invalid wheel, wrong number of black");
            }
            if (Numbers.Count(n => n.Color == Color.Red) != 18)
            {
                throw new Exception("Invalid wheel, wrong number of red");
            }

            if (Numbers.GroupBy(n => n.Value).Any(g => g.Count() > 1))
            {
                throw new Exception("There's a duplicate number");
            }
        }
    }
}