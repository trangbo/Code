using static System.Console;

namespace Csharp
{
    class MainProgram
    {
        static void Main()
        {
            var test = new RandomNumberclass();

            test[1] = "0";

            WriteLine(test[0]);
        }
    }
    
   class RandomNumberclass
   {
        public string LastName;
        private string Firstname;
        public string CityofBirth;

        public string this[int index]
        {
            set
            {
                switch (index)
                {
                    case 0: LastName = value;
                        break;
                    case 1: Firstname = value;
                        break;
                    case 2: CityofBirth = value;
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException("index");
                }
            }

            get
            {
                switch (index)
                {
                    case 0: return LastName;
                    case 1: return Firstname;
                    case 2: return CityofBirth;

                    default:
                        throw new ArgumentOutOfRangeException("index");
                }
            }    
        }
   }
}