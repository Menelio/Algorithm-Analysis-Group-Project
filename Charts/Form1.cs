using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ProjectLibrary;
using System.Diagnostics;
using System.Threading;
namespace Charts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //warmup
            Graph g1 = RandomGraph.Generate(100, 1500, 1500);
            g1.setHnOfNodes(g1.nodes[g1.nodes.Length - 1]);
            Astar.Search(g1.nodes[0], g1.nodes[g1.nodes.Length - 1], g1);
            Exhaustive.Search(g1.nodes[0], g1.nodes[g1.nodes.Length - 1], g1);

            float[] AstarTime = new float[100];
            float[] ExhaustTime = new float[100];

            for (int i = 1; i < 50; i++)
            {
                int n = 10 * i;
                double x = 1000 * i;
                double y = 1000 * i;

                ///////////////////////////////////////////////////////////////////////////////////
                Graph g = RandomGraph.Generate(n, x, y);

                Stopwatch stopWatch1 = new Stopwatch();
                stopWatch1.Start();

                Route r1 = Astar.Search(g.nodes[0], g.nodes[g.nodes.Length - 1], g);


                stopWatch1.Stop();

                ////////////////////////////////////////////////////////////////////////////////////

                Stopwatch stopWatch2 = new Stopwatch();
                stopWatch2.Start();

                Route r2 = Exhaustive.Search(g.nodes[0], g.nodes[g.nodes.Length - 1], g);

                stopWatch2.Stop();

                ///////////////////////////////////////////////////////////////////////////////////

                AstarTime[i] = stopWatch1.ElapsedTicks;
                ExhaustTime[i] = stopWatch2.ElapsedTicks;
            }

            double[] t = { 5000, 7000 };

            var chart = chart1.ChartAreas[0];
            chart.AxisX.IntervalType = DateTimeIntervalType.Number;

            chart.AxisX.LabelStyle.Format = "";
            chart.AxisX.LabelStyle.Format = "";

            chart.AxisY.LabelStyle.IsEndLabelVisible = true;
            chart.AxisX.Minimum = 0;
            chart.AxisX.Maximum = 500;
            chart.AxisY.Minimum = 0;
            chart.AxisY.Maximum = 25000;
            chart.AxisX.Interval = 10;
            chart.AxisY.Interval = 1000;

            chart1.Series.Add("Astar");
            chart1.Series["Astar"].ChartType = SeriesChartType.Line;
            chart1.Series["Astar"].Color = Color.Red;  
            chart1.Series[0].IsVisibleInLegend = false;
            for (int i = 0; i < AstarTime.Length; i++){
                chart1.Series["Astar"].Points.AddXY((i * 10), AstarTime[i]);
            }

            chart1.Series.Add("Exhaustive");
            chart1.Series["Exhaustive"].ChartType = SeriesChartType.Line;
            
            chart1.Series["Exhaustive"].Color = Color.Blue;
            chart1.Series[0].IsVisibleInLegend = false;

            for(int i=0; i< ExhaustTime.Length; i++) {
                chart1.Series["Exhaustive"].Points.AddXY((i*10), ExhaustTime[i]);
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
