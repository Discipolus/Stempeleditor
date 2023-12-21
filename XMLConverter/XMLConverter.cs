using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
//using System.Xaml;
using IXMLConverter;
using Models.Elements;
using Models.Elements.PlatzhalterTypen;

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
            if (xml.Contains("False"))
            {
                xml = xml.Replace("False", "false");
            }
            if (xml.Contains("True"))
            {
                xml = xml.Replace("True", "true");
            }
            XDocument stempelxml = XDocument.Parse(xml);
            Guid id = Guid.Parse(stempelxml.Root!.Element("Id")!.Value);
            string name = stempelxml.Root.Element("Name")!.Value;
            bool erstellInformationenAnzeigen = Convert.ToBoolean(stempelxml.Root.Element("ErstellInformationenAnzeigen")!.Value);
            System.Drawing.Color farbe = System.Drawing.ColorTranslator.FromHtml(stempelxml.Root.Element("Farbe")!.Value);
            bool aufgabeErzeugen = Convert.ToBoolean(stempelxml.Root.Element("AufgabeErzeugen")!.Value);
            XElement beschreibung = stempelxml.Root.Element("Beschreibung")!;
            List<Platzhalter> platzhalterListe = new List<Platzhalter>();

            XElement platzhalterListeXml = stempelxml.Root.Element("PlatzhalterListe")!;
            foreach (XElement platzhalter in platzhalterListeXml.Elements())
            {
                Platzhalter currentPh;
                switch (platzhalter.Element("Typ")!.Value)
                {
                    case "NumInterval":
                        currentPh = new NumInterval();
                        break;
                    case "Text":
                        currentPh = new Text();
                        break;
                    case "TextBoxEinzeilig":
                        currentPh = new TextBoxEinzeilig();
                        break;
                    case "TextBoxMehrzeilig":
                        currentPh = new TextBoxMehrzeilig();
                        break;
                    case "Kalenderdatum":
                        currentPh = new Kalenderdatum();
                        break;
                    default:
                        continue;
                }
                currentPh.Id = int.Parse(platzhalter.Element("Id")!.Value);
                currentPh.Name = platzhalter.Element("Name")!.Value;
                Platzhalter.Wertecontainer wertecontainer = new Platzhalter.Wertecontainer();
                wertecontainer.Wert = platzhalter.Element("Werte")!.Element("Wert")!.Value;
                wertecontainer.Vorbelegung = platzhalter.Element("Werte")!.Element("Vorbelegung")!.Value;
                currentPh.Werte = wertecontainer;
                platzhalterListe.Add(currentPh);
            }
            return new Stempelverfuegung(id, name, erstellInformationenAnzeigen, farbe, aufgabeErzeugen, beschreibung, platzhalterListe);
        }

        public string convertToXml(Stempelverfuegung stempel)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Stempelverfuegung));
            StringWriter stringWriter = new StringWriter();
            XmlWriterSettings settings = new XmlWriterSettings 
            { Indent = true,
            OmitXmlDeclaration = true};
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty});
            XmlWriter writer = XmlWriter.Create(stringWriter, settings);            
            serializer.Serialize(writer, stempel,ns);
            return stringWriter.ToString();
            //XDocument xDocument = XDocument.Parse(stringWriter.ToString());
            //return xDocument;
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
        public string convertBeschreibungToXaml(XElement beschreibung)
        {
            
            //Convert xml Beschreibung to xaml
            string xamlString = "";
            foreach (XElement element in beschreibung.Elements())
            {
                switch (element.Name.ToString())
                {
                    case "h1":
                        xamlString += "<Paragraph><Run FontWeight=\"Bold\" FontSize=\"16\">" + element.Value + "</Run></Paragraph>";
                        break;
                    case "h2":
                        xamlString += "<Paragraph><Run FontWeight=\"Bold\" FontSize=\"14\">" + element.Value + "</Run></Paragraph>";
                        break;
                    case "b":
                        xamlString += "<Paragraph><Run FontWeight=\"Bold\">" + element.Value + "</Run></Paragraph>";
                        break;
                    case "i":
                        xamlString += "<Paragraph><Run FontStyle=\"Italic\">" + element.Value + "</Run></Paragraph>";
                        break;
                    case "u":
                        xamlString += "<Paragraph><Run TextDecorations=\"Underline\">" + element.Value + "</Run></Paragraph>";
                        break;
                    case "br":
                        xamlString += "<Paragraph><LineBreak/></Paragraph>";
                        break;
                        case "PlatzhalterRef":
                            xamlString += "<Paragraph><Run>/{" + element.Value + "}</Run></Paragraph>";
                        break;
                        case "ZeitstempelRef":
                            xamlString += "<Paragraph><Run>/datum</Run></Paragraph>";
                        break;
                        case "BenutzernameRef":
                            xamlString += "<Paragraph><Run>/autor</Run></Paragraph>";
                        break;
                    default:
                        xamlString += "<Paragraph><Run>" + element.Value + "</Run></Paragraph>";
                        break;
                }
            }
            return xamlString;
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
