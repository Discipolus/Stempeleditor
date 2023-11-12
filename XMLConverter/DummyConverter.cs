using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLConverter
{
    public class DummyConverter : IXMLConverter.IXMLConverter
    {
        public Models.Elements.Stempelverfuegung convertToStempelverfuegung(string xml)
        {
            string dummybeschreibung = "<Beschreibung><PlatzhalterRef>1</PlatzhalterRef><br />Ab am <ZeitstempelRef/></Beschreibung>";
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(dummybeschreibung);
            
            return new Models.Elements.Stempelverfuegung(Guid.Parse("00000000-0000-0000-0000-000000000001"),"DummyStempel",true, System.Drawing.Color.Blue,true,doc);
        }

        public string convertToXml(Models.Elements.Stempelverfuegung stempel)
        {
            throw new NotImplementedException();
        }

        string IXMLConverter.IXMLConverter.convertToXml(string rtf)
        {
            throw new NotImplementedException();
        }
    }
}
