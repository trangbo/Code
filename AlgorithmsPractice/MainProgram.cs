using static System.Console;

namespace AlgorithmsPractice
{
    class MainProgram
    {
        static void Main()
        {
            var array = new string[] {"abc", "abd", "iopppppp", "ujhuhub", "m"};
            WriteLine(AlgorithmBo.MaxProduct(array));
        }
    }
}