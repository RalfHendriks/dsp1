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
        private Label _lbName = new Label() { Location = new Point(55, 70), Height = 15 };
        private Label _lbType = new Label() { Location = new Point(55, 0) ,Height = 15};
        private Image _image;
        private string _nodeName;
        private string _nodeType;
        public NodeObject(string nodeName, string nodeType)
        {
            setName(nodeName);
            setType(nodeType);
            this.Width = 150;
            this.Height = 90;
            this.BackColor = Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lbName.Text = _nodeName;
            this._lbType.Text = _nodeType;
            this.Paint += new PaintEventHandler(object_Paint);
            _lbName.Parent = this;
            _lbType.Parent = this;
            _lbName.Show();
            _lbType.Show();
        }

        private void object_Paint(object sender, PaintEventArgs e)
        {
            _image = Image.FromFile("image/"+_nodeType+".png");
            e.Graphics.DrawImage(_image, new Point(10, 22)); 
        }

        private void setName(string name){
            _nodeName = name;
        }
        private void setType(string type)
        {
            _nodeType = type;
        }
    }
}
