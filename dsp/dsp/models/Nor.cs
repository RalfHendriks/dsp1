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

        public int Value { get; set; }

        public INode[] ConnectedOutputs { get; set; }


        public int? tryCalculate(int input)
        {
            if (InputValues.Count == NumberOfRequiredInputs)
            {
                // In a NOR, all inputs must be 0 in order to return 'true'
                foreach (int value in InputValues)
                {
                    if (value == 1)
                    {
                        return 0;
                    }
                }
                return 1;
            }
            return null;
        }

        public INode Clone()
        {
            return new Nor();
        }
    }
}
