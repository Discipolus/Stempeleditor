using Models.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IXMLConverter
{
    public interface IXMLConverter
    {
        public string convertToXml(Stempelverfuegung stempel);
        public Stempelverfuegung convertToStempelverfuegung(string xml);

        public string convertToXml(string rtf);
    }
}
