using dsp.models.baseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dsp.models
{
    public class ObservableCheckBox: CheckBox, ICheckBox
    {
        private List<Observer> _observers;

        public ObservableCheckBox()
        {
            this._observers = new List<Observer>();
        }
        public void Attach(Observer observer)
        {
            this._observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            this._observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (Observer ob in this._observers)
            {
                ob.Update();
            }
        }
    }
}
