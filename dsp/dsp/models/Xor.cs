using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace dsp.models
{
    public class Xor : INode
    {
        public List<int> InputValues { get; set; }
        public int NumberOfRequiredInputs { get; set; }

        public static void register(NodeFactory factory)
        {
            factory.addNodeType(MethodBase.GetCurrentMethod().DeclaringType.Name.ToString(), new Xor());
        }

        public IPanel VisualObject { get; set; }

        public string Name { get; set; }

        public int Value { get; set; }

        public INode[] ConnectedOutputs { get; set; }

        public int? tryCalculate()
        {
            bool allFieldsHigh = true;
            bool allFieldsLow = true;

            if (InputValues.Count == NumberOfRequiredInputs)
            {
                if (NumberOfRequiredInputs < 2)
                {
                    throw new Exception("Not all pins have been connected, please check your file and try again");
                }
                // In a XOR, only one of the inputValues must be 1
                foreach (int value in InputValues)
                {
                    if (value == 1)
                    {
                        allFieldsLow = false;
                    }
                    if (value == 0)
                    {
                        allFieldsHigh = false;
                    }
                }                
                Value = (allFieldsHigh || allFieldsLow) ? 0 : 1;
                return Value;
            }
            return null;
        }

        public INode Clone()
        {
            return new Xor();
        }

        public void generateVisual()
        {
            VisualObject = new NodePanel(this.Name, MethodBase.GetCurrentMethod().DeclaringType.Name.ToString());
        }
    }
}
