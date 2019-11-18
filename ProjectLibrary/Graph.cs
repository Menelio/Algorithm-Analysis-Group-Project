using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectLibrary
{
    public class Graph
    {
        //Nodes in graph
        public Node[] nodes { get; set; }

        //Edges in this graph
        public Edge[] edges { get; set; }//may not need, do need to find good way to initialize
        


        /// <summary>
        /// Arguement constructor, create graph with given arguements 
        /// </summary>
        /// <param name="edgesArray">Must be Two diminsional square array with
        /// edge weights sorted by row and column by nodes they are. A -1 
        /// signifies no edge
        /// associated with</param>
        /// <param name="nodes">Node in this graph</param>
        public Graph(double[,] edgesArray, Node[] nodesArray) {

            //array of edges for node.setEdges
            Edge[] temp;

            //set edges of nodes in nodes Array
            for (int i = 0; i < edgesArray.GetLength(0); i++) {
                temp = new Edge[findNumOfEdges(Utils.GetRow(edgesArray, i))];
                for (int j = 0, k=0; j < Utils.GetRow(edgesArray, i).Length; j++) {
                    if (Utils.GetRow(edgesArray, i)[j] > 0) {
                        
                        temp[k] = new Edge(Utils.GetRow(edgesArray, i)[j], nodesArray[j]);
                        k++;
                    }
                }
                nodesArray[i].edges = temp; 
            }
            //set nodes to nodesArray
            this.nodes = nodesArray;
        }
        /// <summary>
        /// find the number of edges in a row of edgesArray
        /// </summary>
        /// <param name="row">A row of edgesArray</param>
        /// <returns></returns>
        private static  int findNumOfEdges(double[] row) {
            int count = 0;

            for (int i=0; i<row.Length;i++) {
                if (row[i] >= 0) {
                    count++;
                }
            }

            return count;
        }
        /// <summary>
        /// Set the h(n) of all nodes in the graph
        /// </summary>
        /// <param name="goal">goal node to find the distance from of every node</param>
        public void setHnOfNodes(Node goal) {
            for (int i = 0; i < nodes.Length; i++) {
                nodes[i].hn = 
                Math.Round(
                    Math.Sqrt(
                        Math.Pow( (nodes[i].x -goal.x) , 2) + Math.Pow( (nodes[i].y - goal.y), 2) 
                 ),2);
            }
        }

    }
}
