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

        public string Name { get; set; }

        public int Value { get; set; }

        public INode[] ConnectedNodes { get; set; }

        public int calculate(int input)
        {
            bool allValuesHigh = true;
            inputValues.Add(input);

            if (inputValues.Count == ConnectedNodes.Length)
            {
                foreach (INode node in this.ConnectedNodes)
                {
                    if (node.Value == 0)
                    {
                        allValuesHigh = false;
                        break;
                    }
                }               
            }


            return allValuesHigh ? 1 : 0;
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
