using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Models.Elements
{
    public class Stempelverfuegung
    {
        private static readonly Color defaultColorKeineAufgabe = ColorTranslator.FromHtml("#FF247835");
        private static readonly Color defaultColorAufgabe = ColorTranslator.FromHtml("#FF0000FF");
        #region Properties
        public Guid Id { get; set; }
        private string name;
        public string Name 
        {
            get => name; 
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name darf nicht leer sein");
                }
                else
                {
                    name = value;
                }
            } 
        }
        public bool ErstellinformationenAnzeigen { get; set; }
        private Color farbe;
        public Color Farbe 
        {
            get => farbe;
            set
            {
                if (value != farbe)
                {
                    farbe = value;
                }

            }
        }
        private bool aufgabeErzeugen = false;
        public bool AufgabeErzeugen 
        {
            get => aufgabeErzeugen;
            set
            {
                if (value != aufgabeErzeugen)
                {
                    aufgabeErzeugen = value;
                    if (Farbe == defaultColorAufgabe || Farbe == defaultColorKeineAufgabe)
                    {
                        Farbe = getDefaultColor();
                    }                    
                }
            }  
        }
        //public string Beschreibung { get; set; }
        public XDocument Beschreibung { get; set; }
        public List<Platzhalter> PlatzhalterListe { get; set; } 
        public List<Funktion> Funktionen { get; set; }
        #endregion

        #region Konstruktoren
        public Stempelverfuegung() : this(Guid.Empty, "", false, Color.Empty, false, new XDocument(), new List<Platzhalter>(), new List<Funktion>()) { }
        public Stempelverfuegung(Guid id, string name, bool erstellinformationenAnzeigen, Color farbe, bool aufgabeErzeugen, XDocument beschreibung) : this(id, name, erstellinformationenAnzeigen, farbe, aufgabeErzeugen, beschreibung, new List<Platzhalter>(), new List<Funktion>()) { }
        public Stempelverfuegung(Guid id, string name, bool erstellinformationenAnzeigen, Color farbe, bool aufgabeErzeugen, XDocument beschreibung, List<Platzhalter> platzhalterliste, List<Funktion> funktionen)
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
        private Color getDefaultColor()
        {
            if (AufgabeErzeugen)
            {
                return defaultColorAufgabe;
            }
            else
            {
                return defaultColorKeineAufgabe;
            }
        }
    }
}
