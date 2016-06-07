﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace dsp.models
{
    public class Xor : INode
    {
        private List<int> inputValues = new List<int>();

        public static void register(NodeFactory factory)
        {
            factory.addNodeType(MethodBase.GetCurrentMethod().DeclaringType.Name.ToString(), new Xor());
        }

        public string Name { get; set; }

        public int Value { get; set; }

        public INode[] ConnectedNodes { get; set; }

        public int calculate(int input)
        {
            throw new NotImplementedException();
        }

        public INode Clone()
        {
            return new Xor();
        }
    }
}
