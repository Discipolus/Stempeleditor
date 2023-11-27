using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Elements.PlatzhalterTypen
{
    public class NumInterval : Platzhalter
    {
        public NumInterval() : base(0, "", "NumInterval", new Wertecontainer()) { }
        public NumInterval(int id, string name, Wertecontainer werte) : base(id, name, "NumInterval", werte) { }
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

            List<int> validValues = new List<int>();
            string[] parts = werte.Wert.Split('~');

            foreach (string part in parts)
            {
                try
                {
                    if (part.Contains('-'))
                    {
                        int[] rangeParts = part.Split('-').Select(int.Parse).ToArray();
                        validValues.AddRange(Enumerable.Range(rangeParts[0], rangeParts.Last() - rangeParts[0] + 1));
                    }
                    else
                    {
                        validValues.Add(int.Parse(part));
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException("Wert enthält unzulässige Zeichen. Nur Nummern und '~' sowie '-' sind erlaubt. Beispiel: '1-3~5-7' für die Nummern 1,2,3,5,6,7");                    
                }
            }

            return validValues.Contains(int.Parse(werte.Vorbelegung));
        }
    }
}
