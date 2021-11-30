using static System.Console;

namespace AlgorithmsPractice
{
    class MainProgram
    {
        static void Main()
        {
            var result = AlgorithmBo.CountBitsB(5);

            foreach (var i in result)
            {
                WriteLine(i);
            }
        }
    }
}