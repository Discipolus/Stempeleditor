using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Elements.PlatzhalterTypen
{
    public class Kalenderdatum : Platzhalter
    {
        public Kalenderdatum() : base(0, "", "Kalenderdatum", new Wertecontainer()) { }
        public Kalenderdatum(int id, string name, Wertecontainer werte) : base(id, name, "Kalenderdatum", werte) { }
        protected override bool validateWerte(Wertecontainer werte)
        {
            if (string.IsNullOrEmpty(werte.Wert) && string.IsNullOrEmpty(werte.Vorbelegung))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
