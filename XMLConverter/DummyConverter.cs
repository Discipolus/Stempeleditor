using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLConverter
{
    public class DummyConverter : IXMLConverter.IXMLConverter
    {
        public Models.Elements.Stempelverfuegung convertToStempelverfuegung(string xml)
        {
            string dummybeschreibung = "<Beschreibung><PlatzhalterRef>1</PlatzhalterRef><br />Ab am <ZeitstempelRef/></Beschreibung>";
            XElement bschreibung = new XElement("Beschreibung");
            bschreibung.Add(XDocument.Parse(xml).Root);
            return new Models.Elements.Stempelverfuegung(Guid.Parse("00000000-0000-0000-0000-000000000001"),"DummyStempel",true, System.Drawing.Color.Blue,true,bschreibung);
        }

        public string convertToXml(Models.Elements.Stempelverfuegung stempel)
        {
            throw new NotImplementedException();
        }

        public XElement convertBeschreibungToXml(string rtf)
        {
            throw new NotImplementedException();
        }
        public string convertBeschreibungToXaml(XElement beschreibung)
        {
            throw new NotImplementedException();
        }
    }
}
