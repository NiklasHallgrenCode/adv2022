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

        public void Day2Part1()
        {
            var inputList = System.IO.File.ReadAllText(@"..\..\Day2.txt").Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();

            int result = 0;

            foreach (var inputRow in inputList)
            {
                var inputOpponent = GetRpsInput(inputRow.Split(' ').First());
                var inputMe = GetRpsInput(inputRow.Split(' ').Last());

                if(inputMe == Rock)                
                    result += 1;
                else if (inputMe == Paper)
                    result += 2;
                else if (inputMe == Scissor)
                    result += 3;

                result += inputMe == inputOpponent ? 3 : MatchResult(inputMe, inputOpponent);

            }

            Console.WriteLine(result);
            Console.ReadKey();
        }

        public void Day2Part2()
        {
            var inputList = System.IO.File.ReadAllText(@"..\..\Day2.txt").Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();

            int result = 0;

            foreach (var inputRow in inputList)
            {
                var inputOpponent = GetRpsInput(inputRow.Split(' ').First());
                var inputOutcome = GetOutcomeInput(inputRow.Split(' ').Last());

                result += GetResult(inputOutcome, inputOpponent);
                
            }

            Console.WriteLine(result);
            Console.ReadKey();
        }



        private const string Rock = "rock";
        private const string Paper = "paper";
        private const string Scissor = "scissor";

        private const string Win = "win";
        private const string Draw = "draw";
        private const string Lose = "lose";

        private int GetResult(string matchResult, string rpsValue)
        {
            if(matchResult == Draw)
            {
                return GetShapeValue(rpsValue) + 3;
            }

            if(matchResult == Win)
            {
                return GetShapeValue(MatchWin(rpsValue)) + 6;
            }

            return GetShapeValue(MatchLose(rpsValue));
            
        }

        private int GetShapeValue(string shape)
        {
            switch (shape)
            {
                case Rock:
                    return 1;
                case Paper:
                    return 2;
                default:
                    return 3;
            }
        }

        private string GetOutcomeInput(string rpsValue)
        {
            switch (rpsValue)
            {
                case "X":
                    return Lose;
                case "Y":
                    return Draw;
                case "Z":
                    return Win;
            }
            return null;
        }

        private string GetRpsInput(string rpsValue)
        {
            switch (rpsValue)
            {
                case "A":
                case "X":
                    return Rock;
                case "B":
                case "Y":
                    return Paper;
                case "C":
                case "Z":
                    return Scissor;
            }
            return null;
        }

        private int MatchResult(string meInput, string opponentInput)
        {
            if (meInput == Rock)
                return opponentInput == Scissor ? 6 : 0;
            if (meInput == Paper)
                return opponentInput == Rock ? 6 : 0;

            return opponentInput == Paper ? 6 : 0;
        }

        private string MatchWin(string opponentRpsValue)
        {
            switch (opponentRpsValue)
            {
                case Rock:
                    return Paper;
                case Paper:
                    return Scissor;
                default:
                    return Rock;
            }
        }

        private string MatchLose(string opponentRpsValue)
        {
            switch (opponentRpsValue)
            {
                case Rock:
                    return Scissor;
                case Paper:
                    return Rock;
                default:
                    return Paper;
            }
        }
    }
}
