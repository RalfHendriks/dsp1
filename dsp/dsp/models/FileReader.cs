using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsp.models
{
    class FileReader
    {
        public void readFile()
        {
            int counter = 0;
            string line;
            List<string> allLines = new List<string>();

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader("..\\..\\models\\circuit.txt");
            while ((line = file.ReadLine()) != null)
            {

                // There is no need to parse a comment, so we filter those out.
                if (!line.StartsWith("#"))
                {
                    Console.WriteLine(line);
                    allLines.Add(line);
                }
                
               
            }

            file.Close();

            // Suspend the screen.
            Console.ReadLine();
        }
    }
}
