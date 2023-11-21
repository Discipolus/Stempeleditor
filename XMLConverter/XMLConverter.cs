using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public XDocument convertBeschreibungToXml(string xamlString)
        {
            //Convert xaml Beschreibung to xml
            XDocument xDocument = XDocument.Parse(xamlString);
            XDocument returnDocument = new XDocument();
            XElement beschreibung = new XElement("Beschreibung");
            //foreach (XElement paragraph in xDocument.Root.Elements()) //paragraph
            for (int i = 0; i < xDocument.Root.Elements().Count(); i++)
            { 
                XElement paragraph = xDocument.Root.Elements().ElementAt(i);
                
                foreach (XElement run in paragraph.Elements()) //run
                {
                    string newValue = run.Value;

                    newValue = newValue.Replace("/{", "<PlatzhalterRef>");
                    newValue = newValue.Replace("}", "</PlatzhalterRef>");
                    newValue = newValue.Replace("/autor", "<BenutzernameRef/>");
                    newValue = newValue.Replace("/datum", "<ZeitstempelRef/>");

                    XNode? currentElement = null;
                    //headline 1
                    if (run.Attributes().Where(x => compareXAttributes(x, bold)).Count() > 0
                        && run.Attributes().Where(x => compareXAttributes(x,fontSize16)).Count() > 0)
                    {
                        currentElement = new XElement("h1", newValue);
                    }
                    //headline 2
                    else if (run.Attributes().Where(x => compareXAttributes(x, italic)).Count() > 0
                            && run.Attributes().Where(x => compareXAttributes(x, fontSize14)).Count() > 0)
                    {
                        currentElement = new XElement("h2", newValue);
                    }
                    else
                    {
                        
                        if(run.Attributes().Where(x => compareXAttributes(x, bold)).Count() > 0)
                        {
                            currentElement = new XElement("b", newValue);
                        }
                        if(run.Attributes().Where(x => compareXAttributes(x, italic)).Count() > 0) 
                        {
                            if (currentElement != null)
                            {
                                currentElement = new XElement("i", currentElement);
                            }
                            else
                            {
                                currentElement = new XElement("i", newValue);
                            }
                        }
                        if (run.Attributes().Where(x => compareXAttributes(x, underline)).Count() > 0)
                        {
                            if (currentElement != null)
                            {
                                currentElement = new XElement("u", currentElement);
                            }
                            else
                            {
                                currentElement = new XElement("u", newValue); 
                            }                            
                        }
                    }
                    if (currentElement == null)
                    {
                        currentElement = new XText(newValue);
                    }
                    beschreibung.Add(currentElement);
                }
                if (i < xDocument.Root.Elements().Count() - 1)
                {
                    beschreibung.Add(new XElement("br"));
                }
            }
            returnDocument.Add(beschreibung);

            return returnDocument;
        }
        private static bool compareXAttributes(XAttribute a, XAttribute b)
        {
            return a.Name.Equals(b.Name) && a.Value.Equals(b.Value);
        }
    }
}
