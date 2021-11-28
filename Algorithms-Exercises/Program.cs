using System.ComponentModel.DataAnnotations;
using System.Timers;
using static System.Console;

namespace Algorithms_Exercises
{
    class Program
    {
        
        int Factorial(int inValue)
        {
            if (inValue <= 1)
                return inValue;
            else
                return inValue * Factorial(inValue - 1);
        }
        static void Main(string[] args)
        {
            int v1 = 1, v2 = 2;

            WriteLine($"{v1}, {v2}");

            Max(ref v1, ref v2)++;

            Max(a: v1, b: v2);
            Max(a: v2);

            WriteLine($"{v1}, {v2}");
        }
    }
    class MyClass
    {
        private int N = 5;
        public static void ListInts(int[] inVals)
        {
            if ((inVals != null) && (inVals.Length != 0))
            {
                inVals[1] = 10;
            }
        }

        public ref int RefToValue()
        {
            return ref N;
        }

        public void Display()
        {
            Console.WriteLine($"Value is {N}");
        }
    }



    
}