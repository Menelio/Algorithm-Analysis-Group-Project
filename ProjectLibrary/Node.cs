using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public class Node
    {
        //Global vars
        public double hn { get; set; }
        public Edge[] edges { get; set; }


        //x and y coordinates
        public double x { get; set; }
        public double y { get; set; }

        /// <summary>
        /// Argument constructor
        /// </summary>
        /// <param name="hn">distance to goal</param>
        /// <param name="x">x coorrdinates</param>
        /// <param name="y">y coorrdinates</param>
        public Node(double hn, double x, double y )
        {
            this.hn = hn;
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Set edges leading away from this node
        /// </summary>
        /// <param name="edges"></param>
        public void setEdges(Edge[] edges) {
            this.edges = edges;
        }
    }


}
