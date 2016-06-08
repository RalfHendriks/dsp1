using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dsp.models;

namespace dsp
{
    public partial class Form1 : Form
    {
        MainClass main;
        public Form1()
        {
            InitializeComponent();
            main = new MainClass();
            NodeObject p = new NodeObject("Node1","Nand");
            NodeObject n = new NodeObject("Node2","Xor");
            p.Location = new Point(this.panel1.Location.X / 2, this.panel1.Location.Y / 2);
            n.Location = new Point(120, 140);
            n.Parent = this.panel1;
            p.Parent = this.panel1;
            p.Show();
            n.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.buildFromFile(ofdFileFinder);
        }
    }
}
