using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dsp.models;

namespace dsp
{
    public class NodeFactory
    {
        private Dictionary<string, Type> _types;

        public NodeFactory()
        {
            _types = new Dictionary<string, Type>();
        }

        public void addNodeType(string name, Type type)
        {
            _types[name] = type;
        }

        public INode CreateNode(string type)
        {
            Type t = _types[type];
            INode node = (INode)Activator.CreateInstance(t);
            return node;
        }
    }
}
