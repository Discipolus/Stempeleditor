using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Models.Elements
{
    [Serializable]
    public abstract class Platzhalter : ISerializable
    {
        public struct Wertecontainer
        {
            public string Wert;
            public string Vorbelegung;
            public static bool operator ==(Wertecontainer a, Wertecontainer b)
            {
                return a.Wert == b.Wert && a.Vorbelegung == b.Vorbelegung;
            }
            public static bool operator !=(Wertecontainer a, Wertecontainer b)
            {
                return !(a == b);
            }
            public override bool Equals(object obj)
            {
                return obj is Wertecontainer container &&
                       Wert == container.Wert &&
                       Vorbelegung == container.Vorbelegung;
            }
            public override int GetHashCode()
            {
                return (Wert + Vorbelegung).GetHashCode();
            }
        }

        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Typ { get; set; }

        private Wertecontainer werte;
        public Wertecontainer Werte
        {
            get => werte;
            set
            {
                if (value != werte)
                {
                    if (validateWerte(value))
                    {
                        werte = value;
                    }
                    else
                    {
                        throw new ArgumentException("Werte sind nicht valide");
                    }
                }
            }
        }
        #endregion

        #region Constructors
        public Platzhalter() : this(0, "", "", new Wertecontainer()) { }

        public Platzhalter(int id, string name, string typ, Wertecontainer werte)
        {
            Id = id;
            Name = name;
            Typ = typ;
            Werte = werte;
        }
        #endregion
        protected abstract bool validateWerte(Wertecontainer werte);
        //public XElement toXML()
        //{
        //    XElement platzhalter = new XElement("Platzhalter");
        //    platzhalter.Add(new XElement("Id", Id));
        //    platzhalter.Add(new XElement("Name", Name));
        //    platzhalter.Add(new XElement("Typ", Typ));
        //    XElement werte = new XElement("Werte");
        //    werte.Add(new XElement("Wert", Werte.Wert));
        //    werte.Add(new XElement("Vorbelegung", Werte.Vorbelegung));
        //    platzhalter.Add(werte); //TODO: Werte in XML-Format bringen
            
        //    return platzhalter;
        //}

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            info.AddValue("Id", Id);
            info.AddValue("Name", Name);
            info.AddValue("Typ", Typ);
            info.AddValue("Werte", Werte);
        }
    }
}
