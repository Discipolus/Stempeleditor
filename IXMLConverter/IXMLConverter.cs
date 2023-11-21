using Models.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IXMLConverter
{
    public interface IXMLConverter
    {
        public XDocument convertToXml(Stempelverfuegung stempel);
        public Stempelverfuegung convertToStempelverfuegung(string xml);

        public XDocument convertBeschreibungToXml(string xaml);
    }
}
