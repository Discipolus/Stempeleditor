using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Elements.PlatzhalterTypen
{
    public class TextBoxEinzeilig : Platzhalter
    {
        public TextBoxEinzeilig() : base(0, "", "TextBoxEinzeilig", new Wertecontainer()) { }
        public TextBoxEinzeilig(int id, string name, Wertecontainer werte) : base(id, name, "TextBoxEinzeilig", werte) { }
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
