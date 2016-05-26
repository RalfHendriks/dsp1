using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsp.models
{
    public class Or: NodeOperator
    {
        public Or(string name)
        {
            this.setName(name);
        }
        public override int calculate()
        {
            throw new NotImplementedException();
        }
    }
}
