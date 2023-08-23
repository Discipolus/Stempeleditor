using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Elements
{
    internal class Stempelverfügung
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool ErstellinformationenAnzeigen { get; set; }
        public Color Farbe { get; set; }
        public bool AufgabeErzeugen { get; set; }
        public string Beschreibung { get; set; }
        public List<Platzhalter> PlatzhalterListe { get; set; } 
        public List<Funktion> Funktionen { get; set; }
    }
}
