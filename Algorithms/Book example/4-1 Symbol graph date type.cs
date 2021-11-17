using System;

namespace Algorithms
{
    
    public class SymbolGraph
    {
        private SequentialSearchST<string, int> St; // String -> index
        private string[] Keys;  // index -> String
        private Graph G;    // the graph
    
        public SymbolGraph(string stream, string sp)
        {
            St = new SequentialSearchST<string, int>();
            while (in.hasNextLine()) // builds the index
            {
                String[] a = in.readLine().split(sp); // by reading strings
                for (int i = 0; i < a.length; i++) // to associate each
                    if (!st.contains(a[i])) // distinct string
                        st.put(a[i], st.size()); // with an index.
            }


        }
    }
    
}
