using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dsp.models
{
    public class NodeObject: Panel
    {
        private Label _lbName = new Label();
        private Image _image; 

        public NodeObject()
        {
            this.Width = 150;
            this.Height = 80;
            this.BackColor = Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Paint += new PaintEventHandler(object_Paint);
        }

        private void object_Paint(object sender, PaintEventArgs e)
        {
            _image = Image.FromFile("image/nand.png");
            e.Graphics.DrawImage(_image, new Point(10, 20)); 
        }

        public void setName(string name){
            _lbName.Text = name;
        }
    }
}
