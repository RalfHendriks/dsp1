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
using System.IO;

namespace dsp
{
    public partial class Form1 : Form
    {
        MainClass main;
        public Form1()
        {
            InitializeComponent();
            Console.SetOut(new TextBoxWriter(textBox1));
            main = new MainClass(this);
            /*
            NodeObject p = new NodeObject("Node1","Nand");
            NodeObject n = new NodeObject("Node2","Xor");
            NodeInput i = new NodeInput("A");
            i.Location = new Point(360, 140);
            p.Location = new Point(this.panel1.Location.X / 2, this.panel1.Location.Y / 2);
            n.Location = new Point(120, 140);
            n.Parent = this.panel1;
            p.Parent = this.panel1;
            i.Parent = this.panel1;
            i.Show();
            p.Show();
            n.Show();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.buildFromFile(ofdFileFinder);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main.simulate();
        }

        private void cbSin_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox selected = (CheckBox)sender;
            main.updateInput(selected.Tag.ToString());
        }

        private void Form_Load(object sender, EventArgs e)
        {
            
        }
    }

    public class TextBoxWriter : TextWriter
    {
        TextBox _output = null;

        public TextBoxWriter(TextBox output)
        {
            _output = output;
        }

        public override void Write(char[] buffer, int index, int count)
        {
            base.Write(buffer, index, count);
            _output.AppendText(new string(buffer));
        }

        //public override void Write(char value)
        //{
        //    base.Write(value);
        //    _output.AppendText(value.ToString());
        //}

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}
