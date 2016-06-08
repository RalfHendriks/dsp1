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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.buildFromFile(ofdFileFinder);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main.simulate();
        }
    }
}
