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
        public double hn { get; set; }//distance from goal
        public Edge[] edges { get; set; }
        public String name { get; set; }


        //x and y coordinates
        public double x { get; set; }
        public double y { get; set; }

        /// <summary>
        /// Argument constructor
        /// </summary>
        /// <param name="hn">distance to goal</param>
        /// <param name="x">x coorrdinates</param>
        /// <param name="y">y coorrdinates</param>
        /// <param name="name">Name of node for identification</param>
        public Node(double hn, double x, double y, string name )
        {
            this.hn = hn;
            this.x = x;
            this.y = y;
            this.name = name;
        }

    }


}
