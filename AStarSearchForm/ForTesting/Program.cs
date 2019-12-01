using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectLibrary;
using System.Diagnostics;
using System.Threading;

namespace ForTesting
{
    class Program
    {
        static void Main(string[] args)
        {

            Graph g1 = RandomGraph.Generate(100, 1500, 1500);
            g1.setHnOfNodes(g1.nodes[g1.nodes.Length - 1]);
            //warmup
            Astar.Search(g1.nodes[0], g1.nodes[g1.nodes.Length - 1], g1);
            Exhaustive.Search(g1.nodes[0], g1.nodes[g1.nodes.Length - 1], g1);

            for (int i = 1; i < 100; i++)
            {
                int n = 10*i;
                double x = 1000 * i;
                double y = 1000 * i;

                ///////////////////////////////////////////////////////////////////////////////////
                Graph g = RandomGraph.Generate(n, x, y);

                Stopwatch stopWatch1 = new Stopwatch();
                stopWatch1.Start();

                Route r1 = Astar.Search(g.nodes[0], g.nodes[g.nodes.Length - 1], g);
                

                stopWatch1.Stop();

                ////////////////////////////////////////////////////////////////////////////////////

                Stopwatch stopWatch2 = new Stopwatch();
                stopWatch2.Start();

                Route r2 = Exhaustive.Search(g.nodes[0], g.nodes[g.nodes.Length - 1], g);

                stopWatch2.Stop();

                ///////////////////////////////////////////////////////////////////////////////////

                Console.WriteLine("--------------------------> "+i);
                Console.WriteLine("A* RunTime = " + stopWatch1.ElapsedTicks);
                Console.WriteLine("Ex RunTime = " + stopWatch2.ElapsedTicks);
                Console.WriteLine("--------------------------");
            }
            //PAUSE
            Console.ReadKey();
        }

    }
}
