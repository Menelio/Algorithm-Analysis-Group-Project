using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public class Route
    {
        //nodes in this route
        public Node[] nodes { get; set; }

        //Name of this route
        public String  name { get; set; }

        //f(n) of last node in this route
        public double fn { get; set; }
        /*total g(n) from all edge in route 
         * (must be set from outside as no edges stored in route
         * and is necessary for calculating f(n)*/
        public double totalGn { get; set; }



        /// <summary>
        /// Arg Constructor for single node route g(n) will be set 
        /// to zero
        /// </summary>
        /// <param name="n"> First node in route</param>
        public Route(Node n) {
            nodes = new Node[0];
            nodes = Utils.AppentToArray(nodes, n);
            this.totalGn = 0;
            calculateFn();
        }

        /// <summary>
        /// Arg Constructor for route with more than one node
        /// </summary>
        /// <param name="nodes">nodes in the route</param>
        /// <param name="totalGn">total g(n) for this route</param>

        public Route(Node[] nodes, double totalGn)
        {
            this.nodes = nodes;
            this.totalGn = this.totalGn + totalGn;
            calculateFn();
        }
        //caluculates fn of last node in the route
        private void calculateFn() {
            fn = totalGn + nodes[nodes.Length - 1].hn;
        }
    }
}
