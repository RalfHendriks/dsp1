using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dsp.models
{
    public class NodePanel:  Panel, IPanel
    {
        private Label _lbName;
        private Label _lbType;
        private Image _image;
        private string _nodeName;
        private string _nodeType;

        static int WIDTH = 130;
        static int HEIGHT = 90;
        static Color BG = Color.White;
        static BorderStyle BSTYLE = BorderStyle.FixedSingle;

        public NodePanel(string nodeName, string nodeType)
        {
            NodeName = nodeName;
            NodeType = nodeType;

            this.Width = WIDTH;
            this.Height = HEIGHT;
            this.BackColor = BG;
            this.BorderStyle = BSTYLE;
            this.Paint += new PaintEventHandler(PaintEventHandler);

            lbName = new Label();
            lbName.Parent = this;
            lbName.Show();

            lbType = new Label();
            lbType.Parent = this;
            lbType.Show();
        }

        public Label lbName
        {
            get
            {
                return _lbName;
            }
            set
            {
                value.Location = new Point(55, 70);
                value.Height = 15;
                value.Text = NodeName;
                _lbName = value;
            }
        }

        public Label lbType
        {
            get
            {
                return _lbType;
            }
            set
            {
                value.Location = new Point(55, 0);
                value.Height = 15;
                value.Text = NodeType;
                _lbType = value;
            }
        }

        public void PaintEventHandler(object sender, PaintEventArgs e)
        {
            _image = Image.FromFile("image/" + NodeType + ".png");
            e.Graphics.DrawImage(_image, new Point(10, 22)); 
        }

        public string NodeName
        {
            get
            {
                return _nodeName;
            }
            set
            {
                _nodeName = value;
            }
        }

        public string NodeType
        {
            get
            {
                return _nodeType;
            }
            set
            {
                _nodeType = value; 
            }
        }
    }
}
