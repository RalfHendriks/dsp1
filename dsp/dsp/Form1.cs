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
        public Form1()
        {
            FileReader reader = new FileReader();
            reader.parseFile();
            InitializeComponent();
            MainClass main = new MainClass();
        }
    }
}
