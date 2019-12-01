using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public class GraphHandler
    {
        /// <summary>
        /// Property for nodes in graph
        /// </summary>
        public Node[] nodes
        {
            get;
            set;
        }

        /// <summary>
        /// Properties for the graph
        /// </summary>
        public Graph graph
        {
            get;
            set;
        }

        /// <summary>
        /// Properties for the edges of the graph
        /// </summary>
        public double[,] edges
        {
            get;
            set;
        }

        /// <summary>
        /// Instantiating the nodes and edges within the graph
        /// </summary>
        public GraphHandler()
        {
            nodes = new Node[10];
            nodes[0] = new Node(0, 155, 31, "Node 1");
            nodes[1] = new Node(0, 116, 81, "Node 2");
            nodes[2] = new Node(0, 55, 139, "Node 3");
            nodes[3] = new Node(0, 296, 268, "Node 4");
            nodes[4] = new Node(0, 453, 9, "Node 5");
            nodes[5] = new Node(0, 531, 156, "Node 6");
            nodes[6] = new Node(0, 326, 94, "Node 7");
            nodes[7] = new Node(0, 713, 26, "Node 8");
            nodes[8] = new Node(0, 477, 313, "Node 9");
            nodes[9] = new Node(0, 703, 251, "Node 10");


            edges = new double[10, 10]
            {
                /*Node 1 edges*/{-1,-1,1,7,-1,-1,3,-1,-1,-1},
                /*Node 2 edges*/{-1,-1,3,-1,-1,-1,-1,-1,-1,-1},
                /*Node 3 edges*/{1,3,-1,-1,-1,-1,-1,-1,-1,-1},
                /*Node 4 edges*/{7,-1,-1,-1,-1,-1,4,-1,2,-1},
                /*Node 5 edges*/{-1,-1,-1,-1,-1,-1,1,6,-1,-1},
                /*Node 6 edges*/{-1,-1,-1,-1,-1,-1,5,5,-1,3},
                /*Node 7 edges*/{3,-1,-1,4,1,5,-1,-1,-1,-1},
                /*Node 8 edges*/{-1,-1,-1,-1,6,5,-1,-1,-1,6},
                /*Node 9 edges*/{-1,-1,-1,2,-1,-1,-1,-1,-1,4},
                /*Node 10 edges*/{-1,-1,-1,-1,-1,3,-1,6,4,-1},
            };

            //Instatiating new graph object
            graph = new Graph(edges, nodes);
            
        }
    }
}
