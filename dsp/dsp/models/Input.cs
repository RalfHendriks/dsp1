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
        static string[] inputTypes = { "_HIGH", "_LOW" };

        public static void register(NodeFactory factory)
        {
            foreach (string type in inputTypes)
            {
                factory.addNodeType(MethodBase.GetCurrentMethod().DeclaringType.Name.ToString() + type, MethodBase.GetCurrentMethod().DeclaringType);
            }
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
