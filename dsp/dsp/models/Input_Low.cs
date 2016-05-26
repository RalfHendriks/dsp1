using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsp.models
{
    public class Input_Low: NodeOperator
    {
        
        public static void register(NodeFactory factory)
        {
        }

        public Input_Low(string name)
        {
            this.setName(name);
        }

        public override int calculate()
        {
            throw new NotImplementedException();
        }
    }
}
