using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Elements
{
    public class Platzhalter
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Typ { get; set; }
        public string[] Werte { get; set; }
        #endregion

        #region Konstruktoren
        public Platzhalter():this(0, "", "", new string[2]) { }
        public Platzhalter(int id) : this(id, "", "", new string[2]) { }
        public Platzhalter(int id, string name, string typ, string[] werte)
        {
            Id = id;
            Name = name;
            Typ = typ;
            Werte = werte;
        }
        #endregion
    }
}
