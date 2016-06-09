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
        private List<int> inputValues = new List<int>();
        public static void register(NodeFactory factory)
        {
            factory.addNodeType(MethodBase.GetCurrentMethod().DeclaringType.Name.ToString(), new Probe());
        }

        public IPanel VisualObject { get; set; }

        public string Name { get; set; }

        public int Value { get; set; }

        public INode[] ConnectedNodes { get; set; }


        public int calculate(int input)
        {
            throw new NotImplementedException();
        }

        public INode Clone()
        {
            return new Probe();
        }

        public void generateVisual()
        {
            VisualObject = new InputPanel(this.Name);
        }
    }
}
