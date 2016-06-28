using dsp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dsp
{
    public class NodeInputObserver : Observer
    {
        private CheckBox _target;
        private string _observerState;
        private INode _inputNode;

        public NodeInputObserver(INode node, CheckBox target)
        {
            this._inputNode = node;
            this._target = target;
        }

        public override void Update()
        {
            _target.Checked = InputNode.Value == 1 ? true : false;
        }

        public INode InputNode
        {
            get { return _inputNode; }
            set { _inputNode = value; }
        }
    }
}
