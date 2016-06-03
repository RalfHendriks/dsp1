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
        private Dictionary<string, INode> _nodes;

        public NodeFactory()
        {
            _nodes = new Dictionary<string, INode>();
        }

        public void addNodeType(string name, INode node)
        {
            // This is a possible anti-pattern hotfix
            name = name.ToUpper();

            _nodes[name] = node;
        }

        public INode CreateNode(string type)
        {
            INode t = _nodes[type];
            //INode node = (INode)Activator.CreateInstance(t);
            return t;
        }
    }
}
