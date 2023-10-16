using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Elements
{
    internal class Stempelverfügung
    {
        #region Properties
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool ErstellinformationenAnzeigen { get; set; }
        public Color Farbe { get; set; }
        public bool AufgabeErzeugen { get; set; }
        public string Beschreibung { get; set; }
        public List<Platzhalter> PlatzhalterListe { get; set; } 
        public List<Funktion> Funktionen { get; set; }
        #endregion

        #region Konstruktoren
        public Stempelverfügung() : this(Guid.Empty, "", false, Color.Empty, false, "", new List<Platzhalter>(), new List<Funktion>()) { }
        public Stempelverfügung(Guid id, string name, bool erstellinformationenAnzeigen, Color farbe, bool aufgabeErzeugen, string beschreibung, List<Platzhalter> platzhalterliste, List<Funktion> funktionen)
        {
            Id = id;
            Name = name;
            ErstellinformationenAnzeigen = erstellinformationenAnzeigen;
            Farbe = farbe;
            AufgabeErzeugen = aufgabeErzeugen;
            Beschreibung = beschreibung;
            PlatzhalterListe = platzhalterliste;
            Funktionen = funktionen;
        }
        #endregion
    }
}
