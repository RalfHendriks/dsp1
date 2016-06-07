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
        public string State { get; set; }
        static string[] inputTypes = { "_HIGH", "_LOW" };

        public static void register(NodeFactory factory)
        {
            factory.addNodeType("h", new Input() { State = "High" });
            factory.addNodeType("l", new Input() { State = "Low" });
        }                                                    

        public INode Clone()
        {
            return new Input() { State = this.State };
        }

        public int calculate()
        {
            throw new NotImplementedException();
        }

        public string Name { get; set; }

        public int Value { get; set; }

        public INode[] ConnectedNodes { get; set; }
    }
}
