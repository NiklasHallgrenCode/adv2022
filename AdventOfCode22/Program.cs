using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StructureMap;

namespace AdventOfCode2022
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(new DefaultRegistry());
            var assignments = container.GetInstance<Assignments>();

            assignments.Day2Part2();
        }

    }
}
