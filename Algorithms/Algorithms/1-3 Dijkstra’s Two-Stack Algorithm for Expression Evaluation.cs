using System;

namespace Algorithms
{
    public class Evaluate
    {
        public static int Evaluation()
        {
            var operators = new Stack<char>();
            var operands = new Stack<int>();
            char c;
            int sum = 0;

            while ((c = Convert.ToChar(Console.Read())) != '\r')
            {
                if (c == '(') ;
                else if (c == '+' || c == '-' || c == '*' || c == '/') operators.Push(c);
                else if (c == ')')
                {
                    sum = operands.Pop();

                    sum = operators.Pop() switch
                    {
                        '+' => operands.Pop() + sum,
                        '-' => operands.Pop() - sum,
                        '*' => operands.Pop() * sum,
                        '/' => operands.Pop() / sum,
                    };

                    operands.Push(sum);
                }

                else operands.Push(int.Parse(char.ToString(c)));
            }
            
            return sum;
        }
    }
}
