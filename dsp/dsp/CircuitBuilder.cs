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
        public List<INode> Nodes { get; private set; }

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
                node.generateVisual();
                if(typeof(Input) == node.GetType()){
                    INode[] VisualCreatedNodes = nodes.Where(y => y.VisualObject != null).ToArray();
                    int count = VisualCreatedNodes.Where(x => x.VisualObject.Location != new Point() & x.VisualObject.Location.X >= 0).Count();
                    node.VisualObject.Location = new Point(10,(30 + count * 140));
                    node.VisualObject.Parent = parent;
                    node.VisualObject.Show();
                }
            }
            
            foreach (INode selectedNode in nodes.Where(x => x.VisualObject.Location != new Point()))
            {
                INode lastNode = selectedNode;
                while (true)
                {
                    if (lastNode.ConnectedOutputs == null)
                        break;
                    if (lastNode.ConnectedOutputs.First().VisualObject.Location != new Point() && lastNode.ConnectedOutputs.Last().VisualObject.Location != new Point())
                        break;
                    INode nextNode = lastNode.ConnectedOutputs.First().VisualObject.Location == new Point() ?lastNode.ConnectedOutputs.First() : lastNode.ConnectedOutputs.Last();
                    nextNode.VisualObject.Location = nextNode.VisualObject.Location != new Point() ? nextNode.VisualObject.Location : new Point(lastNode.VisualObject.Location.X + 200, lastNode.VisualObject.Location.Y);
                    nextNode.VisualObject.Parent = parent;
                    nextNode.VisualObject.Show();
                    lastNode = nextNode;
                }
            }

            /*foreach (INode selectedNode in nodes.Where(x => x.VisualObject.Location == new Point()))
            {
                INode[] confirmedOutputs = nodes.Where(y => y.ConnectedOutputs != null).ToArray();
                INode node = selectedNode;
                int xCount = 0;
                while (true)
                {
                    var previousNodes = confirmedOutputs.Where(c => c.ConnectedOutputs.Contains(node));
                    if (previousNodes.Count() == 0)
                        break;
                    else
                    {
                        node = previousNodes.Last().VisualObject.Location != new Point() ? previousNodes.First() : previousNodes.Last();
                        xCount++;
                    }
                }
                var dd = node.VisualObject.Location.Y;
                selectedNode.VisualObject.Location = new Point((xCount * 200), node.VisualObject.Location.Y - 20);
                selectedNode.VisualObject.Parent = parent;
                selectedNode.VisualObject.Show();
                //int y = nodes.Where(x => x.VisualObject.Location.X != -1 && x.VisualObject.Location.Y != -1 & x.VisualObject.Location.X =)
                //var b = selectedNode.VisualObject;
            }*/
          

            /*node.generateVisual();
            node.VisualObject.Location = new Point(rowCountX * 100, rowCountY * 100);
            node.VisualObject.Parent = parent;
            node.VisualObject.Show();*/
            // Expose the local List of INodes as a safe, unsettable Array of INodes.
            Nodes = nodes;
        }
    }
}
