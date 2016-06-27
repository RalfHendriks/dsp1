using dsp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace dsp
{
    public class MainClass
    {
        private FileReader reader = new FileReader();
        private NodeFactory factory = new NodeFactory();
        private CircuitSimulator simulator = new CircuitSimulator();
        private CircuitBuilder builder;
        private Form1 _parent;

        public MainClass(Form1 parent)
        {
            init();
            this._parent = parent;
            builder = new CircuitBuilder(factory, _parent.panel1);
        }

        public void updateInput(string name)
        {
            if (builder.Nodes != null)
            {
                INode node = builder.Nodes.FirstOrDefault(x => x.Name == name);
                node.Value = node.Value == 0 ? 1 : 0;
            }
        }

        public void buildFromFile(FileDialog dialog)
        {
            var result = dialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                bool validCircuit  = reader.parseFile(dialog.FileName);
                if (validCircuit)
                {
                    builder.buildNodes(reader.nodeDefinitions, reader.nodeConnections);
                    // After the nodes have been built, pass the nodes to the simulator.
                    simulator.Nodes = builder.Nodes.ToArray();
                }
            }
        }

        public void simulate()
        {
            simulator.simulate();
        }

        

        private void init()
        {
            //Code for loading all classes based on abstract class
            //Assembly dll = Assembly.LoadFrom("Dsp.exe");
            //var types = dll.GetTypes().Where(x => x.IsSubclassOf(typeof(INode)));

            //Code for loading all classes based on interface class
            var type = typeof(INode);
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => type.IsAssignableFrom(p) && !p.IsInterface);
            foreach (var item in types)
            {
                item.GetMethod("register").Invoke(null, new NodeFactory[] {factory});
            }
        }
    }
}
