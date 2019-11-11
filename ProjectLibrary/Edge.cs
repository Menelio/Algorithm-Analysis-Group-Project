using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public class Edge
    {
        //global var
        public double gn { get; set; }
        /*edge only point to one node, they are one directional, to have two nodes
         *  point to eachother you need two edge. One in each node*/
        public Node node { get; set; }
        /// <summary>
        /// Argument constructor
        /// </summary>
        /// <param name="gn">Cost of crossing this edge</param>
        /// <param name="node">Node this edge points to</param>
        public Edge(double gn,Node node) {
            this.gn = gn;
            this.node = node;
        }

    }
}
