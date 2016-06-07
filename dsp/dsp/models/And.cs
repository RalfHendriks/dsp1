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
        public string[] _keywords = { "And" };

        private string[] kaas = {"kaas", "baab" } ;

        public string Name { get; set; }

        public int Value { get; set; }

        public INode[] ConnectedNodes { get; set; }

        public int calculate()
        {
            throw new NotImplementedException();
        }

        public static void register(NodeFactory factory)
        {
            factory.addNodeType(MethodBase.GetCurrentMethod().DeclaringType.Name.ToString(), MethodBase.GetCurrentMethod().DeclaringType);
        }
    }
}
