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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.buildFromFile(ofdFileFinder);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            main.simulate();
        }

        private void cbSin_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox selected = (CheckBox)sender;
            main.updateInput(selected.Tag.ToString(),selected.Checked != true ? 0 : 1);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            
        }

        public List<CheckBox> getInputValues()
        {
            List<CheckBox> checkBoxes = new List<CheckBox>(); 
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(CheckBox))
                {
                    CheckBox b = (CheckBox)control;
                    checkBoxes.Add(b);
                }
            }
            return checkBoxes;
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
