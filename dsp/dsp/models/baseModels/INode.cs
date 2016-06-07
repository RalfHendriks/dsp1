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
        INode[] ConnectedOutputs { get; set; }
        INode Clone();
        int? tryCalculate(int input);
        List<int> InputValues { get; set; }
        int NumberOfRequiredInputs { get; set; }
    }
}
