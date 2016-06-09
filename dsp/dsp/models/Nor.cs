﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace dsp.models
{
    public class Nor : INode
    {
        private List<int> inputValues = new List<int>();
        public static void register(NodeFactory factory)
        {
            factory.addNodeType(MethodBase.GetCurrentMethod().DeclaringType.Name.ToString(), new Nor());
        }

        public string Name { get; set; }

        public IPanel VisualObject { get; set; }

        public int Value { get; set; }

        public INode[] ConnectedNodes { get; set; }


        public int calculate(int input)
        {
            throw new NotImplementedException();
        }

        public INode Clone()
        {
            return new Nor();
        }

        public void generateVisual()
        {
            VisualObject = new NodePanel(this.Name, MethodBase.GetCurrentMethod().DeclaringType.Name.ToString());
        }
    }
}
