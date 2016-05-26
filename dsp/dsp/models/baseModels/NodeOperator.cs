using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsp.models
{
    public abstract class NodeOperator
    {
        protected string _name;
        protected int _value = 0;
        protected INode[] _connectedNodes;

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
