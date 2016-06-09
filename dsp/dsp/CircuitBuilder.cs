using dsp.models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dsp
{
    class CircuitBuilder
    {
        private NodeFactory factory;
        private Panel parent;
        public List<INode> nodes { get; private set; }

        public int xOffset = 100;
        public int yOffset = 100;

        public CircuitBuilder(NodeFactory factory,Panel panel)
        {            
            this.factory = factory;
            this.parent = panel;
        }

        // Request the objects from the factory, based on the dictionary
        public void buildNodes(Dictionary<string, string> nodeTypes, Dictionary<string, string[]> nodeConnections)
        {
            nodes = new List<INode>();

            // First iteration: request the objects from the factory
            foreach (KeyValuePair<string, string> entry in nodeTypes)
            {
                /* Key is the Node name, value is the Node type */
                INode temp = factory.CreateNode(entry.Value);

                temp.Name = entry.Key;
                nodes.Add(temp);
            }

            // Second iteration: after all the Nodes have been built, fill their ConnectedNodes arrays.
            foreach (INode node in nodes)
            {
                // Get the nodes that are connected from the nodeConnections dictionary
                string[] connectedStrings;// <----------------------------------------┐
                nodeConnections.TryGetValue(node.Name, out connectedStrings); //------┘

                INode[] connectedNodes;
                if (connectedStrings != null)
                {
                    // Fetch the node objects from nodes
                    var b = connectedStrings.Contains(node.Name);
                    connectedNodes = nodes.Where(x => connectedStrings.Contains(x.Name)).ToArray();
                    
                    // Set the ConnectedNodes property
                    node.ConnectedNodes = connectedNodes;
                }
            }
        }
    }
}
