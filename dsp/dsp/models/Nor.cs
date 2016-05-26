using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsp.models
{
    public class Nor: NodeOperator
    {
        public Nor(string name)
        {
            this.setName(name);
        }

        public override int calculate()
        {
            throw new NotImplementedException();
        }
    }
}
