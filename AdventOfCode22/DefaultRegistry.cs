using StructureMap;

namespace AdventOfCode2022
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            For<Assignments>().Use<Assignments>();
        }
    }
}