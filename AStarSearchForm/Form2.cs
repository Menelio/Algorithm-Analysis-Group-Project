using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectLibrary;

namespace AStarSearchForm
{
    public partial class AStarSearch : Form
    {

        /// <summary>
        /// Instantiating the graph, the start node, the goal node, and the route
        /// </summary>
        GraphHandler gh = new GraphHandler();
        Node start;
        Node goal;
        Route route;
        
        public AStarSearch()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Setting the start or goal node when each respective button is pressed and changing the color of the node accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (start == null)
            {
                panel1.BackColor = Color.Green;
                start = gh.graph.nodes[0];
            }
            else if (start != null)
            {
                panel1.BackColor = Color.Maroon;
                goal = gh.graph.nodes[0];
            }
            else
            {
                MessageBox.Show("Goal and start have been selected. " +
                    "Press Run to run a* search or press Reset to reset the start and goal nodes.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (start == null)
            {
                panel2.BackColor = Color.Green;
                start = gh.graph.nodes[1];
            }
            else if (start != null)
            {
                panel2.BackColor = Color.Maroon;
                goal = gh.graph.nodes[1];
            }
            else
            {
                MessageBox.Show("Goal and start have been selected. " +
                    "Press Run to run a* search or press Reset to reset the start and goal nodes.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (start == null)
            {
                panel3.BackColor = Color.Green;
                start = gh.graph.nodes[2];
            }
            else if (start != null)
            {
                panel3.BackColor = Color.Maroon;
                goal = gh.graph.nodes[2];
            }
            else
            {
                MessageBox.Show("Goal and start have been selected. " +
                    "Press Run to run a* search or press Reset to reset the start and goal nodes.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (start == null)
            {
                panel4.BackColor = Color.Green;
                start = gh.graph.nodes[3];
            }
            else if (start != null)
            {
                panel4.BackColor = Color.Maroon;
                goal = gh.graph.nodes[3];
            }
            else
            {
                MessageBox.Show("Goal and start have been selected. " +
                    "Press Run to run a* search or press Reset to reset the start and goal nodes.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (start == null)
            {
                panel5.BackColor = Color.Green;
                start = gh.graph.nodes[4];
            }
            else if (start != null)
            {
                panel5.BackColor = Color.Maroon;
                goal = gh.graph.nodes[4];
            }
            else
            {
                MessageBox.Show("Goal and start have been selected. " +
                    "Press Run to run a* search or press Reset to reset the start and goal nodes.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (start == null)
            {
                panel6.BackColor = Color.Green;
                start = gh.graph.nodes[5];
            }
            else if (start != null)
            {
                panel6.BackColor = Color.Maroon;
                goal = gh.graph.nodes[5];
            }
            else
            {
                MessageBox.Show("Goal and start have been selected. " +
                    "Press Run to run a* search or press Reset to reset the start and goal nodes.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (start == null)
            {
                panel7.BackColor = Color.Green;
                start = gh.graph.nodes[6];
            }
            else if (start != null)
            {
                panel7.BackColor = Color.Maroon;
                goal = gh.graph.nodes[6];
            }
            else
            {
                MessageBox.Show("Goal and start have been selected. " +
                    "Press Run to run a* search or press Reset to reset the start and goal nodes.");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (start == null)
            {
                panel8.BackColor = Color.Green;
                start = gh.graph.nodes[7];
            }
            else if (start != null)
            {
                panel8.BackColor = Color.Maroon;
                goal = gh.graph.nodes[7];
            }
            else
            {
                MessageBox.Show("Goal and start have been selected. " +
                    "Press Run to run a* search or press Reset to reset the start and goal nodes.");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (start == null)
            {
                panel9.BackColor = Color.Green;
                start = gh.graph.nodes[8];
            }
            else if (start != null)
            {
                panel9.BackColor = Color.Maroon;
                goal = gh.graph.nodes[8];
            }
            else
            {
                MessageBox.Show("Goal and start have been selected. " +
                    "Press Run to run a* search or press Reset to reset the start and goal nodes.");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (start == null)
            {
                panel10.BackColor = Color.Green;
                start = gh.graph.nodes[9];
            }
            else if (start != null)
            {
                panel10.BackColor = Color.Maroon;
                goal = gh.graph.nodes[9];
            }
            else
            {
                MessageBox.Show("Goal and start have been selected. " +
                    "Press Run to run a* search or press Reset to reset the start and goal nodes.");
            }
        }

        /// <summary>
        /// Reset the start node, the goal node, and the colors within the graph when the reset button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            start = null;
            goal = null;

            panel1.BackColor = Color.Gray;
            panel2.BackColor = Color.Gray;
            panel3.BackColor = Color.Gray;
            panel4.BackColor = Color.Gray;
            panel5.BackColor = Color.Gray;
            panel6.BackColor = Color.Gray;
            panel7.BackColor = Color.Gray;
            panel8.BackColor = Color.Gray;
            panel9.BackColor = Color.Gray;
            panel10.BackColor = Color.Gray;
        }

        /// <summary>
        /// If the start and goal node are assigned, run an a* search and denote the nodes that were chosen by coloring them
        /// If the start or goal nodes are not assigned, prompt the user to input a proper start and goal node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aStarSearchButton_Click(object sender, EventArgs e)
        {
            if (start != null && goal != null)
            {
                gh.graph.setHnOfNodes(goal);
                route = Astar.Search(start, goal, gh.graph);
                for (int i = 0; i < route.nodes.Length; i++)
                {
                    if (route.nodes[i].name.Equals("Node 1"))
                    {
                        panel1.BackColor = Color.DodgerBlue;
                    }

                    if (route.nodes[i].name.Equals("Node 2"))
                    {
                        panel2.BackColor = Color.DodgerBlue;
                    }

                    if (route.nodes[i].name.Equals("Node 3"))
                    {
                        panel3.BackColor = Color.DodgerBlue;
                    }

                    if (route.nodes[i].name.Equals("Node 4"))
                    {
                        panel4.BackColor = Color.DodgerBlue;
                    }

                    if (route.nodes[i].name.Equals("Node 5"))
                    {
                        panel5.BackColor = Color.DodgerBlue;
                    }

                    if (route.nodes[i].name.Equals("Node 6"))
                    {
                        panel6.BackColor = Color.DodgerBlue;
                    }

                    if (route.nodes[i].name.Equals("Node 7"))
                    {
                        panel7.BackColor = Color.DodgerBlue;
                    }

                    if (route.nodes[i].name.Equals("Node 8"))
                    {
                        panel8.BackColor = Color.DodgerBlue;
                    }

                    if (route.nodes[i].name.Equals("Node 9"))
                    {
                        panel9.BackColor = Color.DodgerBlue;
                    }

                    if (route.nodes[i].name.Equals("Node 10"))
                    {
                        panel10.BackColor = Color.DodgerBlue;
                    }
                }
            }

            else 
            {
                MessageBox.Show("You must select both a start and goal node before searching.");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void AStarSearch_Load(object sender, EventArgs e)
        {

        }
    }
}
