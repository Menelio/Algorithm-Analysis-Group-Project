using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public class Astar
    {
        /// <summary>
        /// Overloaded Wrapper method for Astar.search.
        /// Both start and goal have to be nodes in graph
        /// </summary>
        /// <param name="start">Starting node</param>
        /// <param name="goal">Goal node</param>
        /// <param name="graph">Graph</param>
        /// <returns>Shortest route threw graph</returns>
        public static Route Search(Node start, Node goal, Graph graph) {
            try
            {
                if (!Utils.NoRepeateNode(start, graph.nodes) && !Utils.NoRepeateNode(goal, graph.nodes))
                {
                    graph.setHnOfNodes(goal);
                    Route startingRoute = new Route(start);
                    Route[] openRoutes = new Route[0];
                    return search(start, goal, startingRoute, openRoutes);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (System.Exception e) {
                Console.WriteLine("Either goal or start were not in graph, in Search(Node start,"
                        + "Node goal, Graph graph)\n Stack trace:"+ e.StackTrace);
                return null;
            } 
        }
        


        //Method that preforms actual A* search 
        private static Route search(Node start, Node goal, Route currRoute, Route[] open) {
            if (start.name.Equals(goal.name))
            {
                return currRoute;
            }
            else
            {
                //create new routes from nodes connected to start node and add them to open
                for (int i = 0; i < start.edges.Length; i++)
                {
                    open = Utils.AppentToArray(open,  //append to open
                        new Route(                    //a new route 
                        Utils.AppentToArray(          //made from
                        currRoute.nodes, start.edges[i].node), //currRoute + start.edges[i].node
                        currRoute.totalGn + start.edges[i].gn) //add edge's gn to totalGn
                        );
                }
                
                //select cheapst route to open Last node
                int indexOfCheapest = 0;
                Route cheapest = open[0];
                for (int i = 0; i < open.Length; i++)
                {
                    if (open[i].fn < cheapest.fn)
                    {
                        cheapest = open[i];
                        indexOfCheapest = i;
                    }
                }
                //close/remove cheapest route from open
                open=Utils.RemoveAt(open, indexOfCheapest);
                return search(cheapest.nodes[cheapest.nodes.Length - 1], goal, cheapest, open);

            }
            }
    }
}



