﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsp.models
{
    public class Not : NodeOperator
    {
        public static void register(NodeFactory factory)
        {
        }

        public Not(string name)
        {
            this.setName(name);
        }

        public override int calculate()
        {
            throw new NotImplementedException();
        }
    }
}
