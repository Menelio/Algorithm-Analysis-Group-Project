using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public class NodeProirityQue
    {
        //Nodes in Que to be kept in heap
        private Node[] nodes{ get; set; }

        /// <summary>
        /// No Arg Constructor
        /// </summary>
        public NodeProirityQue() {

        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="que">NodeProirityQue to be copied</param>
        public NodeProirityQue(NodeProirityQue que)
        {
            this.nodes = que.nodes;
        }

        /// <summary>
        /// Arg Constructor
        /// </summary>
        /// <param name="nodes">nodes to be stored in NodeProirityQue</param>
        public NodeProirityQue(Node nodes)
        {
            //TODO
        }

        private void sort() {
            
        }
    }
}
