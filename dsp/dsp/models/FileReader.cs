﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace dsp.models
{
    class FileReader
    {
        private Dictionary<string, string> nodeDefinitions = new Dictionary<string, string>();
        private Dictionary<string, string[]> nodeConnections = new Dictionary<string, string[]>();


        public void parseFile(string fileName)
        {
            string[] parsedFile = validate(fileName);
            fillDefinitionsAndConnections(parsedFile);
        }


        // Same method, but witha file as input
        private string[] validate(string fileName)
        {
            string line;

            List<string> allLines = new List<string>();

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                // There is no need to parse a comment, so we filter those out.
                if (!line.StartsWith("#"))
                {
                    if (!String.IsNullOrWhiteSpace(line) && !line.EndsWith(";"))
                    {
                        throw new Exception("The document is not well-formed, please fix the errors and try again");
                    }
                    allLines.Add(line);
                }
               

            }
            file.Close();

            return allLines.ToArray();
        }

        private void fillDefinitionsAndConnections(string[] lines)
        {
            bool shouldFillConnections = true;
            foreach (String line in lines)
            {
                // Line break specifies the end of the node definitions.
                if (String.IsNullOrWhiteSpace(line))
                {
                    shouldFillConnections = false;
                    continue; // No need to parse the empty line.
                }

                if (shouldFillConnections)
                {

                    string[] splitLine = line.Split(':');

                    // Trim the strings to remove excess whitespaces and tabs.
                    string name = splitLine[0].Trim();
                    string nodeType = splitLine[1].Trim();

                    // Remove the ';' at the end
                    nodeType = nodeType.Substring(0, nodeType.Length - 1);

                    nodeDefinitions.Add(name, nodeType);
                }
                else
                {
                    string[] splitLine = line.Split(':');

                    // Trim the strings to remove excess whitespaces and tabs.
                    string name = splitLine[0].Trim();
                    string rawString = splitLine[1].Trim();

                    // Remove the ';' at the end
                    rawString = rawString.Substring(0, rawString.Length - 1);

                    string[] connectedNodes = rawString.Split(',');

                    nodeConnections.Add(name, connectedNodes);
                }
            }
        }
    }
}
