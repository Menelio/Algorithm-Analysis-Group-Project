using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public class Exhaustive
    {
        /// <summary>
        /// Exhaustive search 
        /// </summary>
        /// <param name="start">Starting node</param>
        /// <param name="goal">Goal node</param>
        /// <param name="graph">Graph</param>
        /// <returns>Shortest route threw graph</returns>
        public static Route Search(Node start, Node goal, Graph graph)
        {
            //open routes
            Route[] open = new Route[1];
            //final routes
            Route[] routes = new Route[0];
            
            //set first route in open to starting node
            open[0] = new Route(start);

            //index of last element in route.node[]
            int il;

            //expand all paths and sort unfinished in open and finish into routes
            for (int j = 0; j < open.Length; j++)
            {
                il = open[j].nodes.Length - 1;
                for (int i = 0; i < open[j].nodes[il].edges.Length; i++)
                {
                    //create new route and store in temp
                   Route temp = new Route(Utils.AppentToArray(open[j].nodes,
                         open[j].nodes[il].edges[i].node),
                         open[j].totalGn + open[j].nodes[il].edges[i].gn);
                    
                    //if complete store in routes
                    if (Utils.ContainsName(temp.nodes, goal.name) &&
                        Utils.NoRepeateNode(open[j].nodes[il].edges[i].node, open[j].nodes) &&
                       
                        temp.nodes[temp.nodes.Length-1].name.Equals(goal.name)) {
                        routes = Utils.AppentToArray(routes, temp);
                    }
                    //if contains no repeats stop in open
                    if (Utils.NoRepeateNode(open[j].nodes[il].edges[i].node, open[j].nodes))
                    {
                        open = Utils.AppentToArray(open,temp);
                    }
                }
              
            }
            //create and search for cheapest route to return
            Route cheapest = routes[0];
            for (int i = 0; i < routes.Length; i++) {
                if (routes[i].totalGn < cheapest.totalGn){
                    cheapest = routes[i];
                }
            }

            return cheapest;
        }
    }
}
