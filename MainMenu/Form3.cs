using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AStarSearchForm;
using Charts;


namespace MainMenu
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void Efficiency_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            
        }

        private void GraphBtn_Click(object sender, EventArgs e)
        {
            AStarSearch form = new AStarSearch();
            form.Show(); 
        }
    }
}
