using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dsp.models.baseModels
{
    public class NodeInput: Panel
    {
        private Image _image;
        public NodeInput()
        {
            this.Width = 150;
            this.Height = 90;
            this.BackColor = Color.White;
            this.Paint += new PaintEventHandler(object_Paint);
        }

        private void object_Paint(object sender, PaintEventArgs e)
        {
            _image = Image.FromFile("image/circle.png");
            e.Graphics.DrawImage(_image, new Point(10, 22));
        }
    }
}
