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
            return new List<string> 
            {
                "<Stempelverfuegung><Id>00000000-0000-0000-0000-000000000001</Id><Name>teststempel1</Name><ErstellInformationenAnzeigen>False</ErstellInformationenAnzeigen><Farbe>#FF0000FF</Farbe><AufgabeErzeugen>False</AufgabeErzeugen><Beschreibung><PlatzhalterRef>1</PlatzhalterRef><br />Ab am <ZeitstempelRef /></Beschreibung><PlatzhalterListe><Platzhalter><Id>1</Id><Name>Texteingabe</Name><Typ>TextBoxEinzeilig</Typ><Werte><Wert /><Vorbelegung /></Werte></Platzhalter></PlatzhalterListe></Stempelverfuegung>",
                "<Stempelverfuegung><Id>00000000-0000-0000-0000-000000000002</Id><Name>teststempel2</Name><ErstellInformationenAnzeigen>False</ErstellInformationenAnzeigen><Farbe>#FF0000FF</Farbe><AufgabeErzeugen>False</AufgabeErzeugen><Beschreibung><PlatzhalterRef>1</PlatzhalterRef><br />Ab am <ZeitstempelRef /></Beschreibung><PlatzhalterListe><Platzhalter><Id>1</Id><Name>Texteingabe</Name><Typ>TextBoxEinzeilig</Typ><Werte><Wert /><Vorbelegung /></Werte></Platzhalter></PlatzhalterListe></Stempelverfuegung>",
                "<Stempelverfuegung><Id>00000000-0000-0000-0000-000000000003</Id><Name>teststempel3</Name><ErstellInformationenAnzeigen>False</ErstellInformationenAnzeigen><Farbe>#FF0000FF</Farbe><AufgabeErzeugen>False</AufgabeErzeugen><Beschreibung><PlatzhalterRef>1</PlatzhalterRef><br />Ab am <ZeitstempelRef /></Beschreibung><PlatzhalterListe><Platzhalter><Id>1</Id><Name>Texteingabe</Name><Typ>TextBoxEinzeilig</Typ><Werte><Wert /><Vorbelegung /></Werte></Platzhalter></PlatzhalterListe></Stempelverfuegung>",
                "<Stempelverfuegung><Id>ed484460-bff4-4cd9-9a48-ace9759e9c1e</Id><Name>teststempel4</Name><ErstellInformationenAnzeigen>false</ErstellInformationenAnzeigen><Farbe /><AufgabeErzeugen>true</AufgabeErzeugen><Beschreibung><Beschreibung>test</Beschreibung></Beschreibung><PlatzhalterListe /><Funktionen /></Stempelverfuegung>"
            };
        }

        public void speicherStempel(string stempel, Guid guid, string stempelName)
        {
            //throw new NotImplementedException();
        }

        public string? ladeStempel(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
