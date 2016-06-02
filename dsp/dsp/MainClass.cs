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
        NodeFactory Factory = new NodeFactory();
        FileReader reader = new FileReader();
        public MainClass()
        {
            init();

            
        }

        public void openFile(FileDialog dialog)
        {
            var result = dialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                reader.parseFile(dialog.FileName);
            }
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
                item.GetMethod("register").Invoke(null, new NodeFactory[] {Factory});
            }
        }
    }
}
