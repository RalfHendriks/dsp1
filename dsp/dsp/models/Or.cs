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
        public List<int> InputValues { get; set; }
        public int NumberOfRequiredInputs { get; set; }
        public static void register(NodeFactory factory)
        {
            factory.addNodeType(MethodBase.GetCurrentMethod().DeclaringType.Name.ToString(), new Or());
        }

        public IPanel VisualObject { get; set; }

        public string Name { get; set; }

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
                foreach (int value in InputValues)
                {
                    if (value == 1)
                    {
                        Value = 1;
                        return Value;
                    }
                }
                Value = 0;
                return Value;

            }
            return null;
        }

        public INode Clone()
        {
            return new Or();
        }

        public void generateVisual()
        {
            VisualObject = new NodePanel(this.Name, MethodBase.GetCurrentMethod().DeclaringType.Name.ToString());
        }


        public void Attach(Observer observer)
        {
            throw new NotImplementedException();
        }

        public void Detach(Observer observer)
        {
            throw new NotImplementedException();
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }
    }
}
