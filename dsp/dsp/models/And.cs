using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace dsp.models
{
    public class And: INode
    {
        private List<int> inputValues = new List<int>();

        public int NumberOfRequiredInputs { get; set; }

        public string Name { get; set; }

        public int Value { get; set; }

        public INode[] ConnectedOutputs { get; set; }

        public int? calculate(int input)
        {            
            inputValues.Add(input);            

            if (inputValues.Count == NumberOfRequiredInputs)
            {
                bool allValuesHigh = true;
                foreach (int value in inputValues)
                {
                    if (value != 1)
                    {
                        allValuesHigh = false;
                        break;
                    }
                }
                return allValuesHigh ? 1 : 0;
            }
            return 0;
        }

        public static void register(NodeFactory factory)
        {
            factory.addNodeType(MethodBase.GetCurrentMethod().DeclaringType.Name.ToString(),new And());
        }

        public INode Clone()
        {
            return new And();
        }      
    }
}
