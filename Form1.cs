using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikacja
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            viewer.ToolBarIsVisible = false;
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Controls.Add(viewer);
            //create a graph object 
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            graph = new Microsoft.Msagl.Drawing.Graph("graph");

            graph.AddEdge("A", "B");
            graph.AddEdge("A", "D");
            graph.AddEdge("B", "A");
            graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Green;
            graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Green;
            graph.FindNode("D").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Green;
            Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.Green;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;

            viewer.Graph = graph;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
            viewer.Refresh();
        }
       
    }
}
