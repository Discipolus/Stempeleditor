using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Elements.PlatzhalterTypen
{
    public class Text : Platzhalter
    {
        public Text() : base(0, "", "Text", new Wertecontainer()) { }
        public Text(int id, string name, Wertecontainer werte) : base(id, name, "Text", werte) { }
        protected override bool validateWerte(Wertecontainer werte)
        {
            if (string.IsNullOrEmpty(werte.Wert) && string.IsNullOrEmpty(werte.Vorbelegung))
            {
                return true;
            }
            if (string.IsNullOrEmpty(werte.Wert) || string.IsNullOrEmpty(werte.Vorbelegung))
            {
                throw new ArgumentException("Wert und Vorbelegung müssen beide leer sein oder beide einen Wert enthalten");
            }

            List<string> validValues = new List<string>();
            string[] parts = werte.Wert.Split('~');

            foreach (string part in parts)
            {
                validValues.Add(part);
            }
            return validValues.Contains(werte.Vorbelegung);
        }
    }
}
