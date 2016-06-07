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

        public void addNodeType(string name, INode type)
        {
            // This is a possible anti-pattern hotfix. 
            // It makes sure the Class names are compatible with the input file.
            name = name.ToUpper();

            _nodes[name] = type;
        }

        public INode CreateNode(string type)
        {
            INode t = _nodes[type];
            INode node = Activator.CreateInstance(t);
            return node;

            //return _nodes[type].Clone();
        }
    }
}
