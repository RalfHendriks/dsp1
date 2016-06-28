using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace dsp.models
{
    public class Probe : INode
    {
        public List<int> InputValues { get; set; }
        public int NumberOfRequiredInputs { get; set; }
        public static void register(NodeFactory factory)
        {
            factory.addNodeType(MethodBase.GetCurrentMethod().DeclaringType.Name.ToString(), new Probe());
        }

        public IPanel VisualObject { get; set; }

        public string Name { get; set; }

        public int Value { get; set; }

        public INode[] ConnectedOutputs { get; set; }


        public int? tryCalculate()
        {
            // Probe can only have one input value, and doesn't need to calculate anything.
            if (InputValues.Count > 0)
            {
                Value = InputValues.ElementAt(0);
                return Value;
            }
            return null;
        }

        public INode Clone()
        {
            return new Probe();
        }

        public void generateVisual()
        {
            VisualObject = new InputPanel(this.Name);
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
