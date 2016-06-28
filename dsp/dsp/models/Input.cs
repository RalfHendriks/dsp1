using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace dsp.models
{
    public class Input : INode
    {
        private int _value;
        public List<Observer> Observers = new List<Observer>();
        public List<int> InputValues { get; set; }
        public int NumberOfRequiredInputs { get; set; }
        public static void register(NodeFactory factory)
        {
            factory.addNodeType("INPUT_HIGH", new Input() { Value = 1 });
            factory.addNodeType("INPUT_LOW", new Input() { Value = 0 });
        }

        public INode Clone()
        {
            return new Input() { Value = this.Value };
        }
        public int? tryCalculate()
        {
            return Value;
        }

        public string Name { get; set; }

        public int Value
        {
            get{
                return _value;
            }
            set
            {
                _value = value;
                Notify();
            }
        }

        public INode[] ConnectedOutputs { get; set; }

        public void generateVisual()
        {
            VisualObject = new InputPanel(this.Name);
        }

        public IPanel VisualObject { get; set; }

        public void Attach(Observer observer)
        {
            this.Observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            this.Observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (Observer ob in this.Observers)
            {
                ob.Update();
            }
        }
    }
}