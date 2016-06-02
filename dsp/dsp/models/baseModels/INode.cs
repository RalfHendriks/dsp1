using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsp.models
{
    public interface INode
    {
        String Name { get; set; }
        int Value { get; set; }
        INode[] ConnectedNodes { get; set; }

        int calculate();

        int getValue();

        string getName();
    }
}
