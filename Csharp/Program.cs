using static System.Console;
using static Csharp.A;

namespace Csharp
{
    class MainProgram
    {
        static void Main()
        {
            A c = new A();
            WriteLine(c.MyValue);

            c.MyValue = 20;
            WriteLine(c.MyValue);
            A.
            TheRealValue3
        }
    }
    class A
    {
        private int theRealValue = 10;  //Camel

        public int TheReadlValue // Pascal
        {
            set { theRealValue = value > 100 ? 100 : value; }
            get { return theRealValue; }
        }

        private int _theRealValue2;  //underline with Camel

        public int TheRealValue2
        {
             set => _theRealValue2 = value > 0 ? 1 : 0;
             get => _theRealValue2;
        }

        public static int TheRealValue3
        {
            set; get;
        }
    }

}