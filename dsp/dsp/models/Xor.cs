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
        public static void register(NodeFactory factory)
        {
            factory.addNodeType(MethodBase.GetCurrentMethod().DeclaringType.Name.ToString(), (INode)Activator.CreateInstance(MethodBase.GetCurrentMethod().DeclaringType));
        }

        public string Name { get; set; }

        public int Value { get; set; }

        public INode[] ConnectedNodes
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int calculate()
        {
            throw new NotImplementedException();
        }

        public int getValue()
        {
            throw new NotImplementedException();
        }

        public string getName()
        {
            throw new NotImplementedException();
        }
    }
}
