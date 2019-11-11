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
        /// Astar Search recursive method
        /// </summary>
        /// <param name="start">Starting node</param>
        /// <param name="goal">Goal node</param>
        /// <param name="route">Route of nodes through the graph should start with starting node</param>
        /// <returns></returns>
        public static Node[] search(Node start, Node goal, Node[] route) {
            // test for base case / stop condition
            if (start.Equals(goal)){
                //make space in route and add cheapest node
                Node[] routePlusOne = new Node[route.Length + 1];
                for (int i = 0; i < route.Length; i++)
                {
                    routePlusOne[i] = route[i];
                }
                routePlusOne[route.Length] = goal;

                return route;
            }
            else { //else make recusive call
                //set first edge->node as cheapest
                Node cheapest = start;
                double fn = start.hn + start.edges[0].gn;
                //find new lowest fn
                for (int i = 0; i < start.edges.Length; i++)
                {
                    if ((start.hn + start.edges[i].gn) < fn)
                    {
                       cheapest = start.edges[i].node;
                    }
                }

                //make space in route and add cheapest node
                Node[] routePlusOne = new Node[route.Length + 1];
                for (int i = 0; i < route.Length; i++)
                {
                    routePlusOne[i] = route[i];
                }
                routePlusOne[route.Length] = cheapest;

                //recursive call
                search(cheapest, goal, routePlusOne);
            }
 
            return null;
        }
    }
}
