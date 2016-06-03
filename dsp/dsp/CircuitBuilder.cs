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

        public CircuitBuilder(NodeFactory factory)
        {
            this.factory = factory;
        }

        // Request the objects from the factory, based on the dictionary
        public void buildNodes(Dictionary<String, String> nodeTypes)
        {
            List<INode> nodes = new List<INode>();
            foreach (KeyValuePair<string, string> entry in nodeTypes)
            {
                Debug.WriteLine(entry.Value);
                INode temp = factory.CreateNode(entry.Value);
                temp.Name = entry.Key;
                nodes.Add(temp);
            }
        }
    }
}
