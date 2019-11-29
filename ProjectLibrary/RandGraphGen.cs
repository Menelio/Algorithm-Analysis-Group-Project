 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public class RandomGraph
    {
        /// <summary>
        /// Genrates a random graph based give param
        /// </summary>
        /// <param name="nodeTotal"> Total number of nodes</param>
        /// <param name="maxX">Max width of graph</param>
        /// <param name="maxY">Max hieght of graph</param>
        /// <returns></returns>
        public static Graph Generate(int nodeTotal,double maxX, double maxY) {
            //Node array 
            Node[] nodes = new Node[nodeTotal];
            //edge array
            double[,] edges = new double[nodeTotal, nodeTotal];
            //temp coordinates
            double x;
            double y;
            //randdom number gen
            Random ran = new Random();

            //generate nodes, names and coordinates
            for (int i = 0; i < nodes.Length; i++) {
                //generate random coordinates, with two decimal places
                x = Math.Round( (ran.NextDouble() * maxX) , 2);
                y = Math.Round((ran.NextDouble() * maxY), 2);

                //initializ node
                nodes[i] = new Node(0, x, y, "n" + i);
            }

            //generate edges
            edges = RandConnectedAdjMatrix(nodeTotal);

            return new Graph(edges,nodes);
        }
        //generats adjacency matrices for edges
        private static double[,] RandConnectedAdjMatrix(int size) {
            //Adjacency Matrix to return
            double[,] adjMatrix = new double[size, size];
            //array of int to exclude when they have already been used
            int[] excluded = {0};
            //index of current column to enter wieght in
            int colmIndex = 0;
            int rowIndex = 0;
            //to generate random ints for wieghts
            Random rand = new Random();
            
            //fill aray and pepper with endges
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    if (rand.NextDouble() > .00) { 
                        adjMatrix[i, j] = -1;
                    }else {
                        adjMatrix[i, j] = Math.Round(((rand.NextDouble() * 4) + 1), 2);
                    }
                }
            }
            //max sure there is a route to goal
            for (int i = 0; i < (size-1); i++) { 
                colmIndex = Utils.ExludedRandom(excluded, 0, size, rand);
                
                adjMatrix[rowIndex, colmIndex] = Math.Round( ((rand.NextDouble() * 4) + 1),2);

                excluded = Utils.AppentToArray(excluded, colmIndex);
                rowIndex = colmIndex;
            }
            return adjMatrix;
        }
    }
}
