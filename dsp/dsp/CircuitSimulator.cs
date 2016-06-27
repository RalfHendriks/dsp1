using dsp.models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dsp
{
    class CircuitSimulator
    {
        public INode[] Nodes { private get; set; }

        public CircuitSimulator()
        {
            Console.WriteLine("CircuitSimulator: ready to simulate");
        }

        private void resetCircuit()
        {
            foreach (var node in Nodes)
            {
                if (node.GetType() != typeof(Input))
                {
                    node.InputValues.Clear();
                    node.Value = 0;
                }
            }
        }


        private void loopThroughNodes(INode[] nodes, out List<INode> nodesOnHold)
        {
            nodesOnHold = new List<INode>();
            foreach (var node in nodes)
            {
                var temp = node.tryCalculate();

                if (temp == null)
                {
                    Console.WriteLine(String.Format("\nPutting {0} on hold.", node.Name));
                    // node has not yet recieved all its values
                    nodesOnHold.Add(node);
                }
                else
                {
                    Thread.Sleep(15);
                    Console.WriteLine(String.Format("\nStarting simulation of {0}({1}), Value: {2}", node.Name, node.GetType().ToString(), node.Value));
                    // Check if the Node has any nodes to spit out to.
                    if (node.ConnectedOutputs != null)
                    {
                        foreach (var outputNode in node.ConnectedOutputs)
                        {
                            Console.WriteLine(String.Format("\tAdding {0} to {1}.InputValues", temp, outputNode.Name));
                            outputNode.InputValues.Add((int)temp);
                        }
                    }
                }
            }
        }

        public void simulate()
        {
            if (Nodes == null)
            {
                return;
                //throw new Exception("You have yet to provide a file to build the circuit from");
            }
            List<INode> nodesOnHold = new List<INode>();           

            var watch = Stopwatch.StartNew();
            resetCircuit();

            Console.WriteLine("\n\n\n\n---------------Starting Simulation--------------");

            try
            {
                loopThroughNodes(Nodes, out nodesOnHold);
                while (nodesOnHold.Count > 0)
                {
                    List<INode> temp = new List<INode>();
                    loopThroughNodes(nodesOnHold.ToArray(), out temp);
                    nodesOnHold = temp;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
           

            Console.WriteLine("\n---------------Ending Simulation--------------\n");

            watch.Stop();
            Console.WriteLine("Operation took " + watch.ElapsedMilliseconds + "ms");
        }
    }
}