using System;

namespace Algorithms
{
    public class TopM
    {
        public static void Main(String[] args)
        {
            //Print the top M lines in the input stream
            int M = Int32.Parse(args[0]);
            var pq = new MinPQ<Transaction>(M + 1);
            string? input;

            while ((input = Console.ReadLine()) != null)
            {
                //Create an entry from the next line and put on the PQ
                pq.insert(new Transaction(input));

                if (pq.size() > M)
                    pq.delMin();    //Remove minimum if M+1 entries on the PQ
            }

            var stack = new Stack<Transaction>();

            while (!pq.isEmpty())
                stack.Push(pq.delMin());

            foreach (var t in stack)
                Console.WriteLine(t);
        }             
    }
}
