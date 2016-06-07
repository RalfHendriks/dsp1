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
        private List<int> inputValues = new List<int>();
        public int NumberOfRequiredInputs { get; set; }

        public static void register(NodeFactory factory)
        {
            factory.addNodeType(MethodBase.GetCurrentMethod().DeclaringType.Name.ToString(), new Xor());
        }

        public string Name { get; set; }

        public int Value { get; set; }

        public INode[] ConnectedOutputs { get; set; }

        public int? calculate(int input)
        {
            inputValues.Add(input);

            bool allFieldsHigh = true;
            bool allFieldsLow = true;

            if (inputValues.Count == NumberOfRequiredInputs)
            {
                // In a XOR, only one of 
                foreach (int value in inputValues)
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
                return (allFieldsHigh || allFieldsLow) ? 0 : 1;
            }
            return null;
        }

        public INode Clone()
        {
            return new Xor();
        }


       
    }
}
