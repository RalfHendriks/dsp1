using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace dsp.models
{
    public class Nor : INode
    {
        public List<int> InputValues { get; set; }
        public int NumberOfRequiredInputs { get; set; }
        public static void register(NodeFactory factory)
        {
            factory.addNodeType(MethodBase.GetCurrentMethod().DeclaringType.Name.ToString(), new Nor());
        }

        public string Name { get; set; }

        public IPanel VisualObject { get; set; }

        public int Value { get; set; }

        public INode[] ConnectedOutputs { get; set; }


        public int? tryCalculate()
        {
            if (NumberOfRequiredInputs < 2)
            {
                throw new Exception("Not all pins have been connected, please check your file and try again");
            }
            if (InputValues.Count == NumberOfRequiredInputs)
            {
                // In a NOR, all inputs must be 0 in order to return 'true'
                foreach (int value in InputValues)
                {
                    if (value == 1)
                    {
                        Value = 0;
                        return Value;
                    }
                }
                Value = 1;
                return Value;
            }
            return null;
        }

        public INode Clone()
        {
            return new Nor();
        }

        public void generateVisual()
        {
            VisualObject = new NodePanel(this.Name, MethodBase.GetCurrentMethod().DeclaringType.Name.ToString());
        }
    }
}
