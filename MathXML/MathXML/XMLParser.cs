using System;
using System.Collections.Generic;
using System.Xml;

namespace MathXML
{
    class XMLParser
    {
        /// <summary>
        /// Takes a XML file name and parses it into a List of Operation. If there are any syntax errors in the XML file, it will write the issue to the console.
        /// </summary>
        /// <param name="fileName">XML file name</param>
        /// <returns>List of Operation</returns>
        public static List<Operation> LoadXML(string fileName)
        {
            List<Operation> output = new List<Operation>();

            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return output;
            }

            string operationType = "";
            string username = "";
            string operationName = "";
            string miscellaneousInfo = "";
            float value1 = 0.0f;
            float value2 = 0.0f;

            foreach (XmlNode operations in doc.DocumentElement)
            {
                operationType = operations.Name;

                //Parse Description node
                if (operations["Description"] == null)
                {
                    Console.WriteLine($"Missing data for Description for Operation \"{operationType}\"");
                    continue;
                }

                string[] descriptionRawText = operations["Description"].InnerText.Split(';');

                if (descriptionRawText.Length < 2)
                {
                    Console.WriteLine($"Invalid formatting for Description for Operation \"{operationType}\"");
                    continue;
                }

                username = descriptionRawText[0];
                operationName = descriptionRawText[1];

                if (descriptionRawText.Length > 2) //misc info is optional
                {
                    miscellaneousInfo = descriptionRawText[2];
                }

                //Parse Values
                if (operations["Value1"] == null)
                {
                    Console.WriteLine($"Missing data for Value1 for Operation \"{operationType}\"");
                }
                else if (float.TryParse(operations["Value1"].InnerText, out value1) == false)
                {
                    Console.WriteLine($"Invalid formatting for Value1 \"{operations["Value1"].InnerText}\" for Operation \"{operationType}\"");
                    continue;
                }

                if (operations["Value2"] == null)
                {
                    Console.WriteLine($"Missing data for Value2 for Operation \"{operationType}\"");
                }
                else if (float.TryParse(operations["Value2"].InnerText, out value2) == false)
                {
                    Console.WriteLine($"Invalid formatting for Value2 \"{operations["Value2"].InnerText}\" for Operation \"{operationType}\"");
                    continue;
                }

                output.Add(new Operation(operationType, username, operationName, miscellaneousInfo, value1, value2));
            }

            return output;
        }
    }
}
