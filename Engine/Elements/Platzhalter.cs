using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Elements
{
    internal class Platzhalter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Typ { get; set; }
        public string[] Werte { get; set; }
        
        public Platzhalter():this(0, "", "", new string[2]) { }
        public Platzhalter(int id) : this(id, "", "", new string[2]) { }
        public Platzhalter(int id, string name, string typ, string[] werte)
        {
            Id = id;
            Name = name;
            Typ = typ;
            Werte = werte;
        }
    }
}
