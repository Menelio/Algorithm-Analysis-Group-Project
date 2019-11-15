using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectLibrary;
namespace ForTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] a = new double[,] { { -1,2,4},
                                          { 3,4,3 },
                                          { 5,6,1 }};

            Node[] nodes = new Node[3];

           
            nodes[0] = new Node(0.0, 1.0, 1.0, "a");
            nodes[1] = new Node(0.0, 4.0, 1.0, "b");
            nodes[2] = new Node(0.0, 4.0, 5.0, "b");

            Graph g = new Graph(a, nodes);

            g.setHnOfNodes(nodes[2]);

            Console.WriteLine(g.nodes[0].hn);

            Console.ReadKey();
        }

    }
}
