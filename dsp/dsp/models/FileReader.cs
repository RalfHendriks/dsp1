using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsp.models
{
    class FileReader
    {
        private List<string> nodeDefinitions = new List<string>();
        private List<string> nodeConnections = new List<string>();

        public void readFile()
        {
            string line;

            List<string> allLines = new List<string>();

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader("..\\..\\models\\circuit.txt");
            while ((line = file.ReadLine()) != null)
            {
                // There is no need to parse a comment, so we filter those out.
                if (!line.StartsWith("#"))
                {
                   allLines.Add(line);
                }              
               
            }
            file.Close();

            fillNodeDefinitions(allLines.ToArray());

        }

        private void fillNodeDefinitions(string[] lines)
        {

        }
    }
}
