using dsp.models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsp
{
    class CircuitBuilder
    {
        private NodeFactory factory;
        private List<INode> nodes = new List<INode>();

        public CircuitBuilder(NodeFactory factory)
        {
            this.factory = factory;
        }

        // Request the objects from the factory, based on the dictionary
        public void buildNodes(Dictionary<String, String> nodeTypes)
        {
            foreach (KeyValuePair<string, string> entry in nodeTypes)
            {
                /* Key is the Node name, value is the Node type */
                INode temp = factory.CreateNode(entry.Value);

                temp.Name = entry.Key;
                nodes.Add(temp);
            }
        }
    }
}
