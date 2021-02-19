using System;
using System.Collections.Generic;
using System.Xml;

namespace MathXML
{
    class XMLParser
    {
        public static List<Operation> LoadXML(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            List<Operation> output = new List<Operation>();

            string operationType = "";
            string username = "";
            string operationName = "";
            string miscellaneousInfo = "";
            float Value1 = 0;
            float Value2 = 0;

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
                else if (float.TryParse(operations["Value1"].InnerText, out Value1) == false)
                {
                    Console.WriteLine($"Invalid formatting for Value1 \"{operations["Value1"].InnerText}\" for Operation \"{operationType}\"");
                    continue;
                }

                if (operations["Value2"] == null)
                {
                    Console.WriteLine($"Missing data for Value2 for Operation \"{operationType}\"");
                }
                else if (float.TryParse(operations["Value2"].InnerText, out Value2) == false)
                {
                    Console.WriteLine($"Invalid formatting for Value2 \"{operations["Value2"].InnerText}\" for Operation \"{operationType}\"");
                    continue;
                }

                output.Add(new Operation(operationType, username, operationName, miscellaneousInfo, Value1, Value2));
            }

            return output;
        }
    }
}
