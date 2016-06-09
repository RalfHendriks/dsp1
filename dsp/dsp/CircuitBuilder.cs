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
        public INode[] Nodes { get; private set; }

        public CircuitBuilder(NodeFactory factory,Panel panel)
        {            
            this.factory = factory;
            this.parent = panel;
        }

        // Request the objects from the factory, based on the dictionary
        public void buildNodes(Dictionary<string, string> nodeTypes, Dictionary<string, string[]> nodeConnections)
        {
            List<INode> nodes = new List<INode>();

            // First iteration: request the objects from the factory
            foreach (KeyValuePair<string, string> entry in nodeTypes)
            {
                /* Key is the Node name, value is the Node type */
                INode temp = factory.CreateNode(entry.Value);

                // Set the name and initialize the InputValues property
                temp.Name = entry.Key;
                temp.InputValues = new List<int>();
                nodes.Add(temp);
            }

            // Second iteration: after all the Nodes have been built, fill their ConnectedNodes arrays.
            int rowCountX = 0;
            int rowCountY = 0;
            foreach (INode node in nodes)
            {
                // Get the nodes that are connected from the nodeConnections dictionary
                string[] connectedStrings;// <----------------------------------------┐
                nodeConnections.TryGetValue(node.Name, out connectedStrings); //------┘

                INode[] connectedOutputs;
                if (connectedStrings != null)
                {
                    // Fetch the node objects from nodes
                    var b = connectedStrings.Contains(node.Name);
                    connectedOutputs = nodes.Where(x => connectedStrings.Contains(x.Name)).ToArray();

                    foreach (var output in connectedOutputs)
                    {
                        output.NumberOfRequiredInputs++;
                    }
                    // Set the ConnectedNodes property
                   node.ConnectedOutputs = connectedOutputs;
                }

                INode[] confirmedOutputs = nodes.Where(y => y.ConnectedOutputs != null).ToArray();
                var previousNodes = confirmedOutputs.Where(c => c.ConnectedOutputs.Contains(node));

                node.generateVisual();
                node.VisualObject.Location = new Point(rowCountX * 100, rowCountY * 100);
                node.VisualObject.Parent = parent;
                node.VisualObject.Show();
                rowCountY++;
            }
            // Expose the local List of INodes as a safe, unsettable Array of INodes.
            Nodes = nodes.ToArray();
        }
    }
}
