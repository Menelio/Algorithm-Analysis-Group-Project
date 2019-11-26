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
            //Test Graphs////////////////////////////////////////////////////////////////////////////

            //Test Graph1

            Node[] n1 = new Node[7];

            n1[0] = new Node(0.0, 6.0, 23.0, "A");
            n1[1] = new Node(0.0, 14.0, 22.0, "B");
            n1[2] = new Node(0.0, 21.0, 25.0, "C");
            n1[3] = new Node(0.0, 8.0, 16.0, "D");
            n1[4] = new Node(0.0, 17.0, 20.0, "E");
            n1[5] = new Node(0.0, 13.0, 8.0, "F");
            n1[6] = new Node(0.0, 24.0, 11.0, "G");

                                            //A  B  C  D  E  F  G 
            double[,] e1 = new double[,] { { -1, 2,-1, 3,-1,-1,-1 },//A {B,D}
                                           {  2,-1, 2, 3,-1,-1,-1 },//B {A,C,D}
                                           { -1, 2,-1, 5, 4,-1,-1 },//C {B,D,E}
                                           {  3, 3, 5,-1,-1, 4,-1 },//D {A,B,C,F}
                                           { -1,-1, 4,-1, 4,-1, 3 },//E {C,F.G}
                                           { -1,-1,-1, 4, 4,-1, 5 },//F {D,E,G}
                                           { -1,-1,-1,-1, 3, 5,-1 },//G {F,E}
            };
            Graph g1 = new Graph(e1, n1);
            g1.setHnOfNodes(g1.nodes[6]);

            //Test Graph2 
               
            Node[] n2 = new Node[4];
            n2[0] = new Node(0.0, 1.0, 5.0, "a");
            n2[1] = new Node(0.0, 4.0, 5.0, "b");
            n2[2] = new Node(0.0, 1.0, 1.0, "c");
            n2[3] = new Node(0.0, 4.0, 1.0, "d");
            
                                          // A  B  C  D
            double[,] e2 = new double[,] { {-1, 5, 1,-1 },//A
                                           { 5,-1, 3, 1 },//B
                                           { 1, 3,-1,-1 },//C
                                           {-1, 1,-1,-1 },//D
                                        };


            Graph g2 = new Graph(e2, n2);
            g2.setHnOfNodes(g2.nodes[3]);
            /////////////////////////////////////////////////////////////////////////////


            Route r2 = Astar.Search(n1[0], n1[6], g1);

            for (int i = 0; i < r2.nodes.Length; i++) {
                Console.WriteLine(r2.nodes[i].name);
            }

            //PAUSE
            Console.ReadKey();
        }

    }
}
