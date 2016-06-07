using dsp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsp
{
    class CircuitBuilder
    {
        public INode[] Nodes { get; private set; }

        private NodeFactory factory;   

        public CircuitBuilder(NodeFactory factory)
        {            
            this.factory = factory;
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

                temp.Name = entry.Key;
                nodes.Add(temp);
            }

            // Second iteration: after all the Nodes have been built, fill their ConnectedNodes arrays.
            foreach (INode node in nodes)
            {
                // Get the nodes that are connected from the nodeConnections dictionary
                string[] connectedStrings;// <----------------------------------------┐
                                                             //                       |
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
            }
            // Expose the local List of INodes as a safe, unsettable Array of INodes.
            Nodes = nodes.ToArray();
        }
    }
}
