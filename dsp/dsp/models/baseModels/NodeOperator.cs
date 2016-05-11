using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsp.models
{
    public abstract class NodeOperator: INode
    {
        private string _name = "";
        private int _value = 0;
        private INode[] _connectedNodes;

        public abstract int calculate();

        public int getValue()
        {
            return this._value;
        }

        public string getName()
        {
            return this._name;
        }

        public void setName(string name)
        {
            this._name = name;
        }

        public void setValue(int value)
        {
            this._value = value;
        }
    }
}
