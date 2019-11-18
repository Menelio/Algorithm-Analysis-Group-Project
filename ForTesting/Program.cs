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
        {                                  //A  B  C  D  E  F  G 
            double[,] a = new double[,] { { -1, 2,-1, 3,-1,-1,-1 },//A {B,D}
                                          {  2,-1, 2, 3,-1,-1,-1 },//B {A,C,D}
                                          { -1, 2,-1, 5, 4,-1,-1 },//C {B,D,E}
                                          {  3, 3, 5,-1,-1, 4,-1 },//D {A,B,C,F}
                                          { -1,-1, 4,-1, 4,-1, 3 },//E {C,F.G}
                                          { -1,-1,-1, 4, 4,-1, 5 },//F {D,E,G}
                                          { -1,-1,-1,-1, 3, 5,-1 },//G {F,E}
            };

            Node[] nodes = new Node[7];

           
            nodes[0] = new Node(0.0, 6.0, 23.0, "A");
            nodes[1] = new Node(0.0, 14.0, 22.0, "B");
            nodes[2] = new Node(0.0, 21.0, 25.0, "C");
            nodes[3] = new Node(0.0, 8.0, 16.0, "D");
            nodes[4] = new Node(0.0, 17.0, 20.0, "E");
            nodes[5] = new Node(0.0, 13.0, 8.0, "F");
            nodes[6] = new Node(0.0, 24.0, 11.0, "G");


            Graph g = new Graph(a, nodes);



            g.setHnOfNodes(g.nodes[6]);

            for (int i = 0; i < g.nodes.Length; i++) {
                Console.WriteLine(g.nodes[i].name + "= " + g.nodes[i].hn);
            }

            Node[] route= new Node[0];

            route = Astar.search(g.nodes[0], g.nodes[6],route);

            Console.WriteLine(route.Length);
            for (int i=0;i < route.Length; i++) {
                Console.WriteLine(route[i].name);
            }

            //for (int i = 0; i < route.Length; i++) {
              //  Console.WriteLine(">>"+route[i].name);
            //}


            Console.ReadKey();
        }

    }
}
