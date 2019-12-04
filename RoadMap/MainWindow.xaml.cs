using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjectLibrary;
namespace RoadMap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Global variables
        Graph graph; //graph
        Node[] nodes; //nodes
        double[,] edges;//edges
        Node goal;//goal node
        Node start;//start node
        Route route;//route found be A*
        Boolean startSelected = false;//bool to tell if start is selected
        Boolean goalSelected = false;//bool to tell if goal is selected
        Boolean routeHighlighted = false;//bool to tell if route is highlighted
        public MainWindow()
        {
            InitializeComponent();
            this.setEdges();
            this.setNodes();
            this.graph = new Graph(edges, nodes);

        }

        //reset button
        private void ResetBtn(object sender, RoutedEventArgs e)
        {
            resetNodes();
        }

        //Search Button
        private void aStarBtn(object sender, RoutedEventArgs e)
        {
            if (startSelected && goalSelected)
            {
                
                this.setEdges();

                this.graph = new Graph(edges, nodes);

            
                route = Astar.Search(start, goal, graph);
                resetNodes();
                highlightRoute();
                routeHighlighted = true;
            }
        }

        //Helper methods
        /// <summary>
        /// sets edge values from text boxes on road map
        /// </summary>
        public void setEdges()
        {
            //I have tried to make this as readable as possible
            //this is an adjacency matrix that is fill from the text box near the edges on the map, or -1 if there is no edge
            //I've mark each colum above each row
            //initialize edges            A                                      B  C  D                                      E                                      F  G  H  I  J  K  L  M  N  O  P  Q  R  S
            edges = new double[19, 19]{ {-1, Convert.ToDouble(this.textBoxAB.Text),-1,-1, Convert.ToDouble(this.textBoxAE.Text), Convert.ToDouble(this.textBoxAF.Text),-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},//A
                                      //                                   A   B                                      C  D  E                                      F  G  H  I  J  K  L  M  N  O  P  Q  R  S
                                      { Convert.ToDouble(this.textBoxAB.Text),-1, Convert.ToDouble(this.textBoxBC.Text),-1,-1, Convert.ToDouble(this.textBoxBC.Text),-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},//B
                                      //A  B                                      C                                      D  E  F  G  H  I  J  K                                      L  M  N  O  P  Q  R  S
                                      {-1,-1, Convert.ToDouble(this.textBoxBC.Text), Convert.ToDouble(this.textBoxCD.Text),-1,-1,-1,-1,-1,-1,-1, Convert.ToDouble(this.textBoxCL.Text),-1,-1,-1,-1,-1,-1,-1},//C
                                      //A  B                                      C  D  E  F  G  H  I  J  K  L  M  N  O  P                                      Q  R  S
                                      {-1,-1, Convert.ToDouble(this.textBoxCD.Text),-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, Convert.ToDouble(this.textBoxDQ.Text),-1,-1},//D
                                      //                                    A  B  C  D  E                                      F                                      G                                      H  I  J  K  L  M  N  O  P  Q  R  S
                                      { Convert.ToDouble(this.textBoxAE.Text),-1,-1,-1,-1, Convert.ToDouble(this.textBoxEF.Text), Convert.ToDouble(this.textBoxEG.Text), Convert.ToDouble(this.textBoxEH.Text),-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},//E
                                      //A                                                                          B  C  D                                      E  F  G                                      H  I  J  K  L  M  N  O  P  Q  R  S
                                      { Convert.ToDouble(this.textBoxAF.Text), Convert.ToDouble(this.textBoxBF.Text),-1,-1, Convert.ToDouble(this.textBoxEF.Text),-1,-1, Convert.ToDouble(this.textBoxFH.Text),-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},//F
                                      //A  B  C  D                                      E  F  G                                      H  I                                      J  K  L  M  N  O  P  Q  R  S
                                      {-1,-1,-1,-1, Convert.ToDouble(this.textBoxEG.Text),-1,-1, Convert.ToDouble(this.textBoxGH.Text),-1, Convert.ToDouble(this.textBoxGJ.Text),-1,-1,-1,-1,-1,-1,-1,-1,-1},//G
                                      //A  B  C  D                                      E                                      F                                      G  H  I  J                                      K  L  M  N  O  P  Q  R  S
                                      {-1,-1,-1,-1, Convert.ToDouble(this.textBoxEH.Text), Convert.ToDouble(this.textBoxFH.Text), Convert.ToDouble(this.textBoxGH.Text),-1,-1,-1, Convert.ToDouble(this.textBoxHK.Text),-1,-1,-1,-1,-1,-1,-1,-1},//H
                                      //A  B  C  D  E  F  G                                      H  I  J  K                                      L  M  N  O  P  Q  R  S
                                      {-1,-1,-1,-1,-1,-1,-1, Convert.ToDouble(this.textBoxHI.Text),-1,-1,-1, Convert.ToDouble(this.textBoxIL.Text),-1,-1,-1,-1,-1,-1,-1},//I
                                      //A  B  C  D  E  F                                      G  H  I  J  K  L                                      M  N  O  P  Q  R  S
                                      {-1,-1,-1,-1,-1,-1, Convert.ToDouble(this.textBoxGJ.Text),-1,-1,-1,-1,-1, Convert.ToDouble(this.textBoxJM.Text),-1,-1,-1,-1,-1,-1},//J
                                      //A  B  C  D  E  F  G                                      H  I  J  K  L                                      M  N  O  P  Q  R  S
                                      {-1,-1,-1,-1,-1,-1,-1, Convert.ToDouble(this.textBoxHK.Text),-1,-1,-1,-1, Convert.ToDouble(this.textBoxKM.Text),-1,-1,-1,-1,-1,-1},//K
                                      //A  B  C  D  E  F  G  H                                      I  J  K  L  M  N                                      O                                      P  Q  R  S
                                      {-1,-1,-1,-1,-1,-1,-1,-1, Convert.ToDouble(this.textBoxIL.Text),-1,-1,-1,-1,-1, Convert.ToDouble(this.textBoxLO.Text), Convert.ToDouble(this.textBoxLP.Text),-1,-1,-1},//L
                                      //A  B  C  D  E  F  G  H  I                                      J                                      K  L  M  N  O  P  Q  R                                      S
                                      {-1,-1,-1,-1,-1,-1,-1,-1,-1, Convert.ToDouble(this.textBoxJM.Text), Convert.ToDouble(this.textBoxKM.Text),-1,-1,-1,-1,-1,-1,-1, Convert.ToDouble(this.textBoxMS.Text)},//M
                                      //A  B  C  D  E  F  G  H  I                                      J  K  L  M  N  O  P  Q                                      R  S
                                      {-1,-1,-1,-1,-1,-1,-1,-1,-1, Convert.ToDouble(this.textBoxJN.Text),-1,-1,-1,-1,-1,-1,-1, Convert.ToDouble(this.textBoxNR.Text),-1},//N
                                      //A  B  C  D  E  F  G  H  I  J  K                                      L  M  N  O                                      P  Q                                     R                                      S
                                      {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, Convert.ToDouble(this.textBoxLO.Text),-1,-1,-1, Convert.ToDouble(this.textBoxOP.Text),-1, Convert.ToDouble(this.textBoxOR.Text), Convert.ToDouble(this.textBoxSO.Text)},//O
                                      //A  B  C  D  E  F  G  H  I  J  K                                       L  M  N                                       O  P                                       Q  R  S
                                      {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,  Convert.ToDouble(this.textBoxLP.Text),-1,-1,  Convert.ToDouble(this.textBoxOP.Text),-1,  Convert.ToDouble(this.textBoxPQ.Text),-1,-1},//P
                                      //A  B  C                                      D  E  F  G  H  I  J  K  L  M  N  O                                      P  Q                                      R  S
                                      {-1,-1,-1, Convert.ToDouble(this.textBoxDQ.Text),-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, Convert.ToDouble(this.textBoxPQ.Text),-1, Convert.ToDouble(this.textBoxRQ.Text),-1},//Q
                                      //A  B  C  D  E  F  G  H  I  J  K  L  M                                      N                                      O  P                                      Q  R  S
                                      {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, Convert.ToDouble(this.textBoxNR.Text), Convert.ToDouble(this.textBoxOR.Text),-1, Convert.ToDouble(this.textBoxRQ.Text),-1,-1},//R
                                      //A  B  C  D  E  F  G  H  I  J  K  L                                      M  N                                      O  P  Q  R  S
                                      {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, Convert.ToDouble(this.textBoxMS.Text),-1, Convert.ToDouble(this.textBoxSO.Text),-1,-1,-1,-1},//S
            };

        }

        /// <summary>
        /// set nodes base on there postion in graph
        /// </summary>
        public void setNodes()
        {
            nodes = new Node[19] {
            new Node(0, 7,26,"A"),
            new Node(0,11,26,"B"),
            new Node(0,19,27,"C"),
            new Node(0,22,27,"D"),
            new Node(0, 8,18,"E"),
            new Node(0,12,21,"F"),
            new Node(0,11,10,"G"),
            new Node(0,16,15,"H"),
            new Node(0,20,17,"I"),
            new Node(0,15, 9,"J"),
            new Node(0,18,13,"K"),
            new Node(0,22,16,"L"),
            new Node(0,18,11,"M"),
            new Node(0,19, 4,"N"),
            new Node(0,25,11,"O"),
            new Node(0,27,12,"P"),
            new Node(0,32,13,"Q"),
            new Node(0,29, 2,"R"),
            new Node(0,23,11,"S")
            };
        }

        public void resetNodes() {
            if (routeHighlighted) {
                for (int i = 0; i < route.nodes.Length; i++)
                {
                    if (route.nodes[i].name.Equals("A"))
                    {
                        this.A.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else if (route.nodes[i].name.Equals("B"))
                    {
                        this.B.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else if (route.nodes[i].name.Equals("C"))
                    {
                        this.C.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else if (route.nodes[i].name.Equals("D"))
                    {
                        this.D.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else if (route.nodes[i].name.Equals("E"))
                    {
                        this.E.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else if (route.nodes[i].name.Equals("F"))
                    {
                        this.F.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else if (route.nodes[i].name.Equals("G"))
                    {
                        this.G.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else if (route.nodes[i].name.Equals("H"))
                    {
                        this.H.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else if (route.nodes[i].name.Equals("I"))
                    {
                        this.I.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else if (route.nodes[i].name.Equals("J"))
                    {
                        this.J.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else if (route.nodes[i].name.Equals("K"))
                    {
                        this.K.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else if (route.nodes[i].name.Equals("L"))
                    {
                        this.L.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else if (route.nodes[i].name.Equals("M"))
                    {
                        this.M.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else if (route.nodes[i].name.Equals("N"))
                    {
                        this.N.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else if (route.nodes[i].name.Equals("O"))
                    {
                        this.O.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else if (route.nodes[i].name.Equals("P"))
                    {
                        this.P.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else if (route.nodes[i].name.Equals("Q"))
                    {
                        this.Q.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else if (route.nodes[i].name.Equals("R"))
                    {
                        this.R.Fill = new SolidColorBrush(Colors.Red);
                    }
                    else if (route.nodes[i].name.Equals("S"))
                    {
                        this.S.Fill = new SolidColorBrush(Colors.Red);
                    }
                }
                routeHighlighted = false;
                route = null;
            }
            if (startSelected)
            {
                if (start.name.Equals("A"))
                {
                    this.A.Fill = new SolidColorBrush(Colors.Red);
                    start = null;
                    startSelected = false;
                }
                else if (start.name.Equals("B"))
                {
                    this.B.Fill = new SolidColorBrush(Colors.Red);
                    start = null;
                    startSelected = false;
                }
                else if (start.name.Equals("C"))
                {
                    this.C.Fill = new SolidColorBrush(Colors.Red);
                    start = null;
                    startSelected = false;
                }
                else if (start.name.Equals("D"))
                {
                    this.D.Fill = new SolidColorBrush(Colors.Red);
                    start = null;
                    startSelected = false;
                }
                else if (start.name.Equals("E"))
                {
                    this.E.Fill = new SolidColorBrush(Colors.Red);
                    start = null;
                    startSelected = false;
                }
                else if (start.name.Equals("F"))
                {
                    this.F.Fill = new SolidColorBrush(Colors.Red);
                    start = null;
                    startSelected = false;
                }
                else if (start.name.Equals("G"))
                {
                    this.G.Fill = new SolidColorBrush(Colors.Red);
                    start = null;
                    startSelected = false;
                }
                else if (start.name.Equals("H"))
                {
                    this.H.Fill = new SolidColorBrush(Colors.Red);
                    start = null;
                    startSelected = false;
                }
                else if (start.name.Equals("I"))
                {
                    this.I.Fill = new SolidColorBrush(Colors.Red);
                    start = null;
                    startSelected = false;
                }
                else if (start.name.Equals("J"))
                {
                    this.J.Fill = new SolidColorBrush(Colors.Red);
                    start = null;
                    startSelected = false;
                }
                else if (start.name.Equals("K"))
                {
                    this.K.Fill = new SolidColorBrush(Colors.Red);
                    start = null;
                    startSelected = false;
                }
                else if (start.name.Equals("L"))
                {
                    this.L.Fill = new SolidColorBrush(Colors.Red);
                    start = null;
                    startSelected = false;
                }
                else if (start.name.Equals("M"))
                {
                    this.M.Fill = new SolidColorBrush(Colors.Red);
                    start = null;
                    startSelected = false;
                }
                else if (start.name.Equals("N"))
                {
                    this.N.Fill = new SolidColorBrush(Colors.Red);
                    start = null;
                    startSelected = false;
                }
                else if (start.name.Equals("O"))
                {
                    this.O.Fill = new SolidColorBrush(Colors.Red);
                    start = null;
                    startSelected = false;
                }
                else if (start.name.Equals("P"))
                {
                    this.P.Fill = new SolidColorBrush(Colors.Red);
                    start = null;
                    startSelected = false;
                }
                else if (start.name.Equals("Q"))
                {
                    this.Q.Fill = new SolidColorBrush(Colors.Red);
                    start = null;
                    startSelected = false;
                }
                else if (start.name.Equals("R"))
                {
                    this.R.Fill = new SolidColorBrush(Colors.Red);
                    start = null;
                    startSelected = false;
                }
                else if (start.name.Equals("S"))
                {
                    this.S.Fill = new SolidColorBrush(Colors.Red);
                    start = null;
                    startSelected = false;
                }
            }
            if (goalSelected)
            {
                if (goal.name.Equals("A"))
                {
                    this.A.Fill = new SolidColorBrush(Colors.Red);
                    goal = null;
                    goalSelected = false;
                }
                else if (goal.name.Equals("B"))
                {
                    this.B.Fill = new SolidColorBrush(Colors.Red);
                    goal = null;
                    goalSelected = false;
                }
                else if (goal.name.Equals("C"))
                {
                    this.C.Fill = new SolidColorBrush(Colors.Red);
                    goal = null;
                    goalSelected = false;
                }
                else if (goal.name.Equals("D"))
                {
                    this.D.Fill = new SolidColorBrush(Colors.Red);
                    goal = null;
                    goalSelected = false;
                }
                else if (goal.name.Equals("E"))
                {
                    this.E.Fill = new SolidColorBrush(Colors.Red);
                    goal = null;
                    goalSelected = false;
                }
                else if (goal.name.Equals("F"))
                {
                    this.F.Fill = new SolidColorBrush(Colors.Red);
                    goal = null;
                    goalSelected = false;
                }
                else if (goal.name.Equals("G"))
                {
                    this.G.Fill = new SolidColorBrush(Colors.Red);
                    goal = null;
                    goalSelected = false;
                }
                else if (goal.name.Equals("H"))
                {
                    this.H.Fill = new SolidColorBrush(Colors.Red);
                    goal = null;
                    goalSelected = false;
                }
                else if (goal.name.Equals("I"))
                {
                    this.I.Fill = new SolidColorBrush(Colors.Red);
                    goal = null;
                    goalSelected = false;
                }
                else if (goal.name.Equals("J"))
                {
                    this.J.Fill = new SolidColorBrush(Colors.Red);
                    goal = null;
                    goalSelected = false;
                }
                else if (goal.name.Equals("K"))
                {
                    this.K.Fill = new SolidColorBrush(Colors.Red);
                    goal = null;
                    goalSelected = false;
                }
                else if (goal.name.Equals("L"))
                {
                    this.L.Fill = new SolidColorBrush(Colors.Red);
                    goal = null;
                    goalSelected = false;
                }
                else if (goal.name.Equals("M"))
                {
                    this.M.Fill = new SolidColorBrush(Colors.Red);
                    goal = null;
                    goalSelected = false;
                }
                else if (goal.name.Equals("N"))
                {
                    this.N.Fill = new SolidColorBrush(Colors.Red);
                    goal = null;
                    goalSelected = false;
                }
                else if (goal.name.Equals("O"))
                {
                    this.O.Fill = new SolidColorBrush(Colors.Red);
                    goal = null;
                    goalSelected = false;
                }
                else if (goal.name.Equals("P"))
                {
                    this.P.Fill = new SolidColorBrush(Colors.Red);
                    goal = null;
                    goalSelected = false;
                }
                else if (goal.name.Equals("Q"))
                {
                    this.Q.Fill = new SolidColorBrush(Colors.Red);
                    goal = null;
                    goalSelected = false;
                }
                else if (goal.name.Equals("R"))
                {
                    this.R.Fill = new SolidColorBrush(Colors.Red);
                    goal = null;
                    goalSelected = false;
                }
                else if (goal.name.Equals("S"))
                {
                    this.S.Fill = new SolidColorBrush(Colors.Red);
                    goal = null;
                    goalSelected = false;
                }
            }
        }

        public void highlightRoute() {
            for (int i = 0; i < route.nodes.Length; i++) {
                if (route.nodes[i].name.Equals("A"))
                {
                    this.A.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (route.nodes[i].name.Equals("B"))
                {
                    this.B.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (route.nodes[i].name.Equals("C"))
                {
                    this.C.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (route.nodes[i].name.Equals("D"))
                {
                    this.D.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (route.nodes[i].name.Equals("E"))
                {
                    this.E.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (route.nodes[i].name.Equals("F"))
                {
                    this.F.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (route.nodes[i].name.Equals("G"))
                {
                    this.G.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (route.nodes[i].name.Equals("H"))
                {
                    this.H.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (route.nodes[i].name.Equals("I"))
                {
                    this.I.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (route.nodes[i].name.Equals("J"))
                {
                    this.J.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (route.nodes[i].name.Equals("K"))
                {
                    this.K.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (route.nodes[i].name.Equals("L"))
                {
                    this.L.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (route.nodes[i].name.Equals("M"))
                {
                    this.M.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (route.nodes[i].name.Equals("N"))
                {
                    this.N.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (route.nodes[i].name.Equals("O"))
                {
                    this.O.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (route.nodes[i].name.Equals("P"))
                {
                    this.P.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (route.nodes[i].name.Equals("Q"))
                {
                    this.Q.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (route.nodes[i].name.Equals("R"))
                {
                    this.R.Fill = new SolidColorBrush(Colors.Green);
                }
                else if (route.nodes[i].name.Equals("S"))
                {
                    this.S.Fill = new SolidColorBrush(Colors.Green);
                }
            }
        }

        //Node button events
        private void AClick(object sender, RoutedEventArgs e)
        {
            //select start
            if (!startSelected && !goalSelected )
            {
                this.A.Fill = new SolidColorBrush(Colors.Cyan);
                this.startSelected = true;
                this.start = graph.nodes[0];
            }
            //select goal
            else if (startSelected && !goalSelected ) {
                this.A.Fill = new SolidColorBrush(Colors.Gold);
                this.goalSelected = true;
                this.goal = graph.nodes[0];
            }
        }

        private void BClick(object sender, RoutedEventArgs e)
        {   
            //select start
            if (!startSelected && !goalSelected)
            {
                this.B.Fill = new SolidColorBrush(Colors.Cyan);
                this.startSelected = true;
                this.start = graph.nodes[1];
            }
            //select goal
            else if (startSelected && !goalSelected)
            {
                this.B.Fill = new SolidColorBrush(Colors.Gold);
                this.goalSelected = true;
                this.goal = graph.nodes[1];
            }
        }

        private void CClick(object sender, RoutedEventArgs e)
        {
            //select start
            if (!startSelected && !goalSelected)
            {
                this.C.Fill = new SolidColorBrush(Colors.Cyan);
                this.startSelected = true;
                this.start = graph.nodes[2];
            }
            //select goal
            else if (startSelected && !goalSelected)
            {
                this.C.Fill = new SolidColorBrush(Colors.Gold);
                this.goalSelected = true;
                this.goal = graph.nodes[2];
            }
        }

        private void DClick(object sender, RoutedEventArgs e)
        {
            //select start
            if (!startSelected && !goalSelected)
            {
                this.D.Fill = new SolidColorBrush(Colors.Cyan);
                this.startSelected = true;
                this.start = graph.nodes[3];
            }
            //select goal
            else if (startSelected && !goalSelected)
            {
                this.D.Fill = new SolidColorBrush(Colors.Gold);
                this.goalSelected = true;
                this.goal = graph.nodes[3];
            }
        }

        private void EClick(object sender, RoutedEventArgs e)
        {
            //select start
            if (!startSelected && !goalSelected)
            {
                this.E.Fill = new SolidColorBrush(Colors.Cyan);
                this.startSelected = true;
                this.start = graph.nodes[4];
            }
            //select goal
            else if (startSelected && !goalSelected)
            {
                this.E.Fill = new SolidColorBrush(Colors.Gold);
                this.goalSelected = true;
                this.goal = graph.nodes[4];
            }
        }

        private void FClick(object sender, RoutedEventArgs e)
        {
            //select start
            if (!startSelected && !goalSelected)
            {
                this.F.Fill = new SolidColorBrush(Colors.Cyan);
                this.startSelected = true;
                this.start = graph.nodes[5];
            }
            //select goal
            else if (startSelected && !goalSelected)
            {
                this.F.Fill = new SolidColorBrush(Colors.Gold);
                this.goalSelected = true;
                this.goal = graph.nodes[5];
            }
        }

        private void GClick(object sender, RoutedEventArgs e)
        {
            //select start
            if (!startSelected && !goalSelected)
            {
                this.G.Fill = new SolidColorBrush(Colors.Cyan);
                this.startSelected = true;
                this.start = graph.nodes[6];
            }
            //select goal
            else if (startSelected && !goalSelected)
            {
                this.G.Fill = new SolidColorBrush(Colors.Gold);
                this.goalSelected = true;
                this.goal = graph.nodes[6];
            }
        }

        private void HClick(object sender, RoutedEventArgs e)
        {
            //select start
            if (!startSelected && !goalSelected)
            {
                this.H.Fill = new SolidColorBrush(Colors.Cyan);
                this.startSelected = true;
                this.start = graph.nodes[7];
            }
            //select goal
            else if (startSelected && !goalSelected)
            {
                this.H.Fill = new SolidColorBrush(Colors.Gold);
                this.goalSelected = true;
                this.goal = graph.nodes[7];
            }
        }

        private void IClick(object sender, RoutedEventArgs e)
        {
            //select start
            if (!startSelected && !goalSelected)
            {
                this.I.Fill = new SolidColorBrush(Colors.Cyan);
                this.startSelected = true;
                this.start = graph.nodes[8];
            }
            //select goal
            else if (startSelected && !goalSelected)
            {
                this.I.Fill = new SolidColorBrush(Colors.Gold);
                this.goalSelected = true;
                this.goal = graph.nodes[8];
            }
        }

        private void JClick(object sender, RoutedEventArgs e)
        {
            //select start
            if (!startSelected && !goalSelected)
            {
                this.J.Fill = new SolidColorBrush(Colors.Cyan);
                this.startSelected = true;
                this.start = graph.nodes[9];
            }
            //select goal
            else if (startSelected && !goalSelected)
            {
                this.J.Fill = new SolidColorBrush(Colors.Gold);
                this.goalSelected = true;
                this.goal = graph.nodes[9];
            }
        }

        private void KClick(object sender, RoutedEventArgs e)
        {
            //select start
            if (!startSelected && !goalSelected)
            {
                this.K.Fill = new SolidColorBrush(Colors.Cyan);
                this.startSelected = true;
                this.start = graph.nodes[10];
            }
            //select goal
            else if (startSelected && !goalSelected)
            {
                this.K.Fill = new SolidColorBrush(Colors.Gold);
                this.goalSelected = true;
                this.goal = graph.nodes[10];
            }
        }

        private void LClick(object sender, RoutedEventArgs e)
        {
            //select start
            if (!startSelected && !goalSelected)
            {
                this.L.Fill = new SolidColorBrush(Colors.Cyan);
                this.startSelected = true;
                this.start = graph.nodes[11];
            }
            //select goal
            else if (startSelected && !goalSelected)
            {
                this.L.Fill = new SolidColorBrush(Colors.Gold);
                this.goalSelected = true;
                this.goal = graph.nodes[11];
            }
        }

        private void MClick(object sender, RoutedEventArgs e)
        {
            //select start
            if (!startSelected && !goalSelected)
            {
                this.M.Fill = new SolidColorBrush(Colors.Cyan);
                this.startSelected = true;
                this.start = graph.nodes[12];
            }
            //select goal
            else if (startSelected && !goalSelected)
            {
                this.M.Fill = new SolidColorBrush(Colors.Gold);
                this.goalSelected = true;
                this.goal = graph.nodes[12];
            }
        }
        private void NClick(object sender, RoutedEventArgs e)
        {
            //select start
            if (!startSelected && !goalSelected)
            {
                this.N.Fill = new SolidColorBrush(Colors.Cyan);
                this.startSelected = true;
                this.start = graph.nodes[13];
            }
            //select goal
            else if (startSelected && !goalSelected)
            {
                this.N.Fill = new SolidColorBrush(Colors.Gold);
                this.goalSelected = true;
                this.goal = graph.nodes[13];
            }
        }
        private void OClick(object sender, RoutedEventArgs e)
        {
            //select start
            if (!startSelected && !goalSelected)
            {
                this.O.Fill = new SolidColorBrush(Colors.Cyan);
                this.startSelected = true;
                this.start = graph.nodes[14];
            }
            //select goal
            else if (startSelected && !goalSelected)
            {
                this.O.Fill = new SolidColorBrush(Colors.Gold);
                this.goalSelected = true;
                this.goal = graph.nodes[14];
            }
        }
        private void PClick(object sender, RoutedEventArgs e)
        {
            //select start
            if (!startSelected && !goalSelected)
            {
                this.P.Fill = new SolidColorBrush(Colors.Cyan);
                this.startSelected = true;
                this.start = graph.nodes[15];
            }
            //select goal
            else if (startSelected && !goalSelected)
            {
                this.P.Fill = new SolidColorBrush(Colors.Gold);
                this.goalSelected = true;
                this.goal = graph.nodes[15];
            }
        }
        private void QClick(object sender, RoutedEventArgs e)
        {
            //select start
            if (!startSelected && !goalSelected)
            {
                this.Q.Fill = new SolidColorBrush(Colors.Cyan);
                this.startSelected = true;
                this.start = graph.nodes[16];
            }
            //select goal
            else if (startSelected && !goalSelected)
            {
                this.Q.Fill = new SolidColorBrush(Colors.Gold);
                this.goalSelected = true;
                this.goal = graph.nodes[16];
            }
        }

        private void RClick(object sender, RoutedEventArgs e)
        {
            //select start
            if (!startSelected && !goalSelected)
            {
                this.R.Fill = new SolidColorBrush(Colors.Cyan);
                this.startSelected = true;
                this.start = graph.nodes[17];
            }
            //select goal
            else if (startSelected && !goalSelected)
            {
                this.R.Fill = new SolidColorBrush(Colors.Gold);
                this.goalSelected = true;
                this.goal = graph.nodes[17];
            }
        }
        private void SClick(object sender, RoutedEventArgs e)
        {
            //select start
            if (!startSelected && !goalSelected)
            {
                this.S.Fill = new SolidColorBrush(Colors.Cyan);
                this.startSelected = true;
                this.start = graph.nodes[18];
            }
            //select goal
            else if (startSelected && !goalSelected)
            {
                this.S.Fill = new SolidColorBrush(Colors.Gold);
                this.goalSelected = true;
                this.goal = graph.nodes[18];
            }
        }
    }
}
