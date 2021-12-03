using static System.Console;

namespace AlgorithmsPractice
{
    class MainProgram
    {
        static void Main()
        {
            var array = new int[] {5,1,4,3};
            WriteLine(AlgorithmBo.MinSubArrayLen(7, array));
        }
    }
}