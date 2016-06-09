using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dsp.models
{
    public class InputPanel: Panel, IPanel
    {
        private Label _lbName;
        private String _inputName;

        static int WIDTH = 150;
        static int HEIGHT = 90;
        static Color BG = Color.White;

        public InputPanel(string name)
        {
            NodeName = name;

            this.Width = WIDTH;
            this.Height = HEIGHT;
            this.BackColor = BG;
            this.Paint += new PaintEventHandler(PaintEventHandler);

            lbName = new Label();
            lbName.Parent = this;
            lbName.Show();
        }

        public void PaintEventHandler(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(0, 0, 40, 40);
            graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);
        }

        public string NodeName
        {
            get
            {
                return _inputName;
            }
            set
            {
                _inputName = value;
            }
        }

        public Label lbName
        {
            get
            {
                return _lbName;
            }
            set
            {
                value.Location = new Point(14, 45);
                value.Height = 15;
                value.Text = NodeName;
                _lbName = value;
            }
        }
    }
}
