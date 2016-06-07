using dsp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsp
{
    class CircuitSimulator
    {
        public INode[] Nodes { private get; set; }

        public void simulate()
        {
            if (Nodes == null)
            {
                throw new Exception("You have yet to provide a file to build the circuit from");
            }

            foreach (var node in Nodes)
            {
                // Check if the Node has any nodes to spit out to.
                if (node.ConnectedOutputs != null)
                {
                    foreach (var nodeOutput in node.ConnectedOutputs)
                    {
                        var temp = node.calculate(node.Value);
                        if (temp != null)
                        {
                            nodeOutput.Value = (int)temp;
                        }
                    }
                }                
            }
        }
    }
}
