using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace dsp.models
{
    public class Not : INode
    {
        public List<int> InputValues { get; set; }
        public int NumberOfRequiredInputs { get; set; }
        public static void register(NodeFactory factory)
        {
            factory.addNodeType(MethodBase.GetCurrentMethod().DeclaringType.Name.ToString(), new Not());
        }

        public IPanel VisualObject { get; set; }

        public string Name { get; set; }

        public int Value { get; set; }

        public INode[] ConnectedOutputs { get; set; }

        public int? tryCalculate()
        {
            // A not can only have one input value, so its safe to get only the first one
            if (InputValues.ElementAt(0) == 1)
            {
                Value = 0;
                return Value;
            }
            Value = 1;
            return Value;         
        }

        public INode Clone()
        {
            return new Not();
        }

        public void generateVisual()
        {
            VisualObject = new NodePanel(this.Name, MethodBase.GetCurrentMethod().DeclaringType.Name.ToString());
        }
    }
}
