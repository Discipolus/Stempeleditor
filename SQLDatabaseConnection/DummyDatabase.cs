using IStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDatabaseConnection
{
    public class DummyDatabase : IStorageService
    {
        public List<string> ladeStempelListe()
        {
            string stempel = "<?xml version=\"1.0\" encoding=\"utf-8\"?><Stempelverfuegung><Id>f32de6ee-65cd-4197-bf6b-ad1e7a443dde</Id><Name>Beispielstempel</Name><ErstellInformationenAnzeigen>False</ErstellInformationenAnzeigen><Farbe>#FF0000FF</Farbe><AufgabeErzeugen>False</AufgabeErzeugen><Beschreibung><PlatzhalterRef>1</PlatzhalterRef><br />Ab am <ZeitstempelRef/></Beschreibung><PlatzhalterListe><Platzhalter><Id>1</Id><Name>Texteingabe</Name><Typ>TextBoxEinzeilig</Typ><Werte><Wert></Wert><Vorbelegung></Vorbelegung></Werte></Platzhalter></PlatzhalterListe></Stempelverfuegung>";
            return new List<string> { stempel };            
        }

        public void speicherStempel(string stempel, Guid guid, string stempelName)
        {
            throw new NotImplementedException();
        }

        public string? ladeStempel(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
