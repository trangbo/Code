using static System.Console;

namespace Csharp
{
    class MainProgram
    {
        static void Main()
        {
           var v1 = new RandomNumberclass();
           var v2 = new RandomNumberclass { X = 3 };
        }
    }
    
   class RandomNumberclass
   {
       private static Random RandomKey;
       public int X = 2;

       static RandomNumberclass()
       {
           RandomKey = new Random();
       }

       public int GetRandomNumber()
       {
           return RandomKey.Next();
       }
   }
}