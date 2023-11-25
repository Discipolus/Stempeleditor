using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using IXMLConverter;
using Models.Elements;

namespace XMLConverter
{
    public class XMLConverter : IXMLConverter.IXMLConverter
    {
        private static readonly XAttribute bold = new XAttribute("FontWeight", "Bold");
        private static readonly XAttribute italic = new XAttribute("FontStyle", "Italic");
        private static readonly XAttribute underline = new XAttribute("TextDecorations", "Underline");
        private static readonly XAttribute fontSize16 = new XAttribute("FontSize", "16");
        private static readonly XAttribute fontSize14 = new XAttribute("FontSize", "14");

        public Stempelverfuegung convertToStempelverfuegung(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Stempelverfuegung));
            StringReader stringReader = new StringReader(xml);
            try
            {
                return (Stempelverfuegung)serializer.Deserialize(stringReader);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Stempelverfuegung();
            }
        }

        public XDocument convertToXml(Stempelverfuegung stempel)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Stempelverfuegung));
            StringWriter stringWriter = new StringWriter();
            serializer.Serialize(stringWriter, stempel);
            XDocument xDocument = XDocument.Parse(stringWriter.ToString());
            return xDocument;
        }

        public XElement convertBeschreibungToXml(string xamlString)
        {
            //Convert xaml Beschreibung to xml
            XDocument xDocument = XDocument.Parse(xamlString);
            XElement beschreibung = new XElement("Beschreibung");
            for (int i = 0; i < xDocument.Root!.Elements().Count(); i++)
            {
                XElement paragraph = xDocument.Root.Elements().ElementAt(i);

                foreach (XElement run in paragraph.Elements()) //run
                {
                    //set new xElement for beschreibung and check if it still works beschreibung => new XElement("currentElement")
                    XElement? currentElement = new XElement(replaceReferences(run.Value, new XElement("currentElement"))); //replace references "/datum", "/autor" and "/{#} with the respective xml elements
                    bool bold = run.Attributes().Where(x => compareXAttributes(x, XMLConverter.bold)).Count() > 0;
                    bool italic = run.Attributes().Where(x => compareXAttributes(x, XMLConverter.italic)).Count() > 0;
                    bool underline = run.Attributes().Where(x => compareXAttributes(x, XMLConverter.underline)).Count() > 0;
                    bool fontSize16 = run.Attributes().Where(x => compareXAttributes(x, XMLConverter.fontSize16)).Count() > 0;
                    bool fontSize14 = run.Attributes().Where(x => compareXAttributes(x, XMLConverter.fontSize14)).Count() > 0;
                    //headline 1
                    if (bold && fontSize16)
                    {
                        beschreibung.Add(new XElement("h1", currentElement.Nodes()));
                    }
                    //headline 2
                    else if (bold && fontSize14)
                    {
                        beschreibung.Add(new XElement("h2", currentElement.Nodes()));
                    }
                    else
                    {
                        if (bold)
                        {
                            currentElement = new XElement("b", currentElement.Nodes());
                        }
                        if (italic)
                        {
                            if (bold)
                            {
                                currentElement = new XElement("i", currentElement);
                            }
                            else
                            {
                                currentElement = new XElement("i", currentElement.Nodes());
                            }
                        }
                        if (underline)
                        {
                            if (bold || italic)
                            {
                                currentElement = new XElement("u", currentElement);
                            }
                            else
                            {
                                currentElement = new XElement("u", currentElement.Nodes());
                            }
                        }
                        if (bold || italic || underline)
                        {
                            beschreibung.Add(currentElement);
                        }
                        else
                        {
                            beschreibung.Add(currentElement.Nodes());
                        }
                    }
                }
                if (i < xDocument.Root.Elements().Count() - 1)
                {
                    beschreibung.Add(new XElement("br"));
                }
            }
            return beschreibung;
        }
        private static bool compareXAttributes(XAttribute a, XAttribute b)
        {
            return a.Name.Equals(b.Name) && a.Value.Equals(b.Value);
        }

        private static XElement replaceReferences(string run, XElement parent)
        {
            string noReference = "";
            string currentRun = new String(run);
            XElement returnElement = new XElement(parent);

            for (int i = 0; i < currentRun.Length; i++)
            {
                if (currentRun[i] == '/')
                {
                    switch (currentRun[i + 1])
                    {                         
                        case '{':
                            returnElement.Add(noReference);
                            noReference = "";

                            int indexClosingBracket = currentRun.IndexOf('}', i); //get index of closing bracket
                            try
                            {
                                int placeholderIndex = Convert.ToInt32(currentRun.Substring(i + 2, indexClosingBracket - i - 2)); //get index of placeholder
                                returnElement.Add(new XElement("PlatzhalterRef", placeholderIndex));
                            }
                            catch (Exception e)
                            {
                                string errorMessage = "Error in trying to extract placeholder at position: " + i.ToString() + e.Message;
                                Console.WriteLine(errorMessage);
                            }
                            currentRun = currentRun.Remove(0, indexClosingBracket + 1);
                            break;
                        case 'a' or 'd':
                            returnElement.Add(noReference);
                            noReference = "";

                            string reference = currentRun.Substring(i + 1, 5);
                            if (reference.Contains("autor"))
                            {                                
                                returnElement.Add(new XElement("BenutzernameRef"));
                            }
                            if (reference.Contains("datum"))
                            {
                                returnElement.Add(new XElement("ZeitstempelRef"));
                            }
                            currentRun = currentRun.Remove(0, i + 6);
                            break;
                        default:
                            noReference += currentRun[i];
                            continue;
                    }
                    i = -1;
                }
                else
                {
                    noReference += currentRun[i];
                }
            }
            returnElement.Add(noReference);
            return returnElement;
        }
    }
}
