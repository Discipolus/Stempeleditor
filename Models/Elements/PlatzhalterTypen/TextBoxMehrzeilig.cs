using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Elements.PlatzhalterTypen
{
    public class TextBoxMehrzeilig : Platzhalter
    {
        public TextBoxMehrzeilig() : base(0, "", "TextBoxMehrzeilig", new Wertecontainer()) { }
        public TextBoxMehrzeilig(int id, string name, Wertecontainer werte) : base(id, name, "TextBoxMehrzeilig", werte) { }
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
