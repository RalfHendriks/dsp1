using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace dsp.models
{
    public class Or : INode
    {
        private List<int> inputValues = new List<int>();
        public int NumberOfRequiredInputs { get; set; }
        public static void register(NodeFactory factory)
        {
            factory.addNodeType(MethodBase.GetCurrentMethod().DeclaringType.Name.ToString(), new Or());
        }

        public string Name { get; set; }

        public int Value { get; set; }

        public INode[] ConnectedOutputs { get; set; }

        public int? calculate(int input)
        {
            inputValues.Add(input);

            if (inputValues.Count == NumberOfRequiredInputs)
            {
                foreach (int value in inputValues)
                {
                    if (input == 1)
                    {
                        return 1;
                    }
                }
                return 0;

            }
            return null;
        }

        public INode Clone()
        {
            return new Or();
        }
    }
}
