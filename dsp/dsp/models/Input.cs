using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace dsp.models
{
    public class Input : INode
    {
        public int NumberOfRequiredInputs { get; set; }
        public static void register(NodeFactory factory)
        {
            factory.addNodeType("INPUT_HIGH", new Input() { Value = 1 });
            factory.addNodeType("INPUT_LOW", new Input() { Value = 0 });
        }

        public INode Clone()
        {
            return new Input() { Value = this.Value };
        }
        public int? calculate(int _)
        {
            return Value;
        }

        public string Name { get; set; }

        public int Value { get; set; }

        public INode[] ConnectedOutputs { get; set; }

    }
}