using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public class Assignments
    {
        public void Day1Part1()
        {
            var calorieList = System.IO.File.ReadAllText(@"..\..\Day1.txt").Replace(Environment.NewLine, ",");

            int highestValue = 0;

            foreach(var calories in calorieList.Split(new string[] { ",," }, StringSplitOptions.None))
            {
                int value = calories.Split(',').Sum(c => int.Parse(c));

                if (value > highestValue)
                    highestValue = value;
            }
            

            Console.WriteLine(highestValue);
            Console.ReadKey();
        }

        public void Day1Part2()
        {
            var calorieList = System.IO.File.ReadAllText(@"..\..\Day1.txt").Replace(Environment.NewLine, ",");

            List<int> allValues = new List<int>();

            foreach (var calories in calorieList.Split(new string[] { ",," }, StringSplitOptions.None))
            {
                allValues.Add(calories.Split(',').Sum(c => int.Parse(c)));

            }

            allValues = allValues.OrderByDescending(a => a).ToList();

            var result = allValues.Take(3).Sum();

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
