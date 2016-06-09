using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dsp.models
{
    public interface IPanel
    {
        Label lbName { get; set; }
        void PaintEventHandler(object sender, PaintEventArgs e);
        String NodeName { get; set; }
        Control Parent { get; set; }
        Point Location { get; set; }
        void Show();
    }
}
