using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IXMLConverter;
using Models.Elements;

namespace XMLConverter
{
    public class XMLConverter : IXMLConverter.IXMLConverter
    {
        public Stempelverfuegung convertToStempelverfuegung(string xml)
        {
            throw new NotImplementedException();
        }

        public string convertToXml(Stempelverfuegung stempel)
        {
            throw new NotImplementedException();
        }

        public string convertToXml(string rtf)
        {
            //Convert rtf Beschreibung to xml
            string xmlString = "<Beschreibung>";
            string[] lines = rtf.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                if (line.Contains("\\timestamp"))
                {
                    xmlString += "<ZeitstempelRef/>";
                }
                else if (line.Contains("<PlatzhalterRef>"))
                {
                    xmlString += "<PlatzhalterRef>" + line.Split('<', '>')[2] + "</PlatzhalterRef>";
                }
                else
                {
                    xmlString += line;
                }
            }
            xmlString += "</Beschreibung>";
            return xmlString;
        }
    }
}
