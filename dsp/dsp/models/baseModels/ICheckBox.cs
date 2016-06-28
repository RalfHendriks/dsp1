using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsp.models.baseModels
{
    public interface ICheckBox
    {
        void Attach(Observer observer);
        void Detach(Observer observer);
        void Notify(); 
    }
}
