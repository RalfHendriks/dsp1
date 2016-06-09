using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace dsp.models
{
    public class Nand : INode
    {
        public List<int> InputValues { get; set; }
        public int NumberOfRequiredInputs { get; set; }
        public static void register(NodeFactory factory)
        {
            factory.addNodeType(MethodBase.GetCurrentMethod().DeclaringType.Name.ToString(), new Nand());
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
                bool allValuesHigh = true;
                foreach (int value in InputValues)
                {
                    if (value != 1)
                    {
                        allValuesHigh = false;
                        break;
                    }
                }
                Value = allValuesHigh ? 0 : 1;
                return Value;
            }
            return null;
        }

        public INode Clone()
        {
            return new Nand();
        }

        public void generateVisual()
        {
            VisualObject = new NodePanel(this.Name, MethodBase.GetCurrentMethod().DeclaringType.Name.ToString());
        }
    }
}
