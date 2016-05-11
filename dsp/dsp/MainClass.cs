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
        public MainClass()
        {
            loadConfig();
            Not t = new Not("please");
            MessageBox.Show(t.GetType().ToString());
        }

        private void loadConfig()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(@"config.xml");
            XmlNode xnodes = xdoc.SelectSingleNode("/config/nodeTypes");
            foreach (XmlNode xnn in xnodes.ChildNodes)
            {
                //Factory.addNodeType()
            }   
        }
    }
}
