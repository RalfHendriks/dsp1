using dsp.models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsp
{
    class CircuitSimulator
    {
        public INode[] Nodes { private get; set; }

        public CircuitSimulator()
        {
            Debug.WriteLine("CircuitSimulator: ready to simulate");
        }

        public void simulate()
        {
            if (Nodes == null)
            {
                throw new Exception("You have yet to provide a file to build the circuit from");
            }

            Debug.WriteLine("\n\n\n\n---------------Starting Simulation--------------");
            foreach (var node in Nodes)
            {
                Debug.WriteLine(String.Format("\nStarting simulation of {0}({1}), Value: {2}", node.Name, node.GetType().ToString(), node.Value));
                // Check if the Node has any nodes to spit out to.
                if (node.ConnectedOutputs != null)
                {
                    foreach (var nodeOutput in node.ConnectedOutputs)
                    {
                        nodeOutput.InputValues.Add(node.Value);

                        var temp = node.tryCalculate(node.Value);
                        if (temp == null)
                        {
                            Debug.WriteLine(String.Format("\tSetting {0}.Value to {1}", nodeOutput.Name, "null"));
                        }
                        else{
                            Debug.WriteLine(String.Format("\tSetting {0}.Value to {1}", nodeOutput.Name, temp));
                        }
                        
                        if (temp != null)
                        {
                            nodeOutput.Value = (int)temp;
                        }
                    }
                }                
            }
            Debug.WriteLine("\n---------------Ending Simulation--------------\n");
        }
    }
}