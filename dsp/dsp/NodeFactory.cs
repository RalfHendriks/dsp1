using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dsp.models;
using System.Reflection;

namespace dsp
{
    public class NodeFactory
    {
        private Dictionary<string, Type> _nodes;

        public NodeFactory()
        {
            _nodes = new Dictionary<string, Type>();
        }

        public void addNodeType(string name, Type node)
        {
            // This is a possible anti-pattern hotfix
            name = name.ToUpper();

            _nodes[name] = node;
        }

        public INode CreateNode(string type)
        {
            Type t = _nodes[type];
            INode node = (INode)Activator.CreateInstance(t);
            return node;
        }
    }
}
