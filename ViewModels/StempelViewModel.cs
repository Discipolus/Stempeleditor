using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelsInterfaces;
using ViewModels;
using Models.Elements;
using System.Xml;

namespace ViewModels
{
    public partial class StempelViewModel : ObservableObject, IStempelViewModel
    {
        [ObservableProperty] string? tb_guid;
        [ObservableProperty] string? tb_name;
        [ObservableProperty] bool erstellinformationen;
        [ObservableProperty] bool aufgabeErzeugen;
        [ObservableProperty] Color farbe;
        [ObservableProperty] XmlDocument? rtb_beschreibung;
        [ObservableProperty] Stempelverfuegung stempelverfuegung;
        //[ObservableProperty] string tb_platzhalter;
        //[ObservableProperty] string tb_funktionen;
        public void clear()
        {
            Tb_guid = "";
            Tb_name = "";
            Erstellinformationen = false;
            AufgabeErzeugen = false;
            Farbe = ColorTranslator.FromHtml("#FF247835");
            Rtb_beschreibung = new XmlDocument();
        }
        public Stempelverfuegung GetStempelverfuegung()
        {
            Guid guid = Guid.Parse(Tb_guid);
            return new Stempelverfuegung(guid, Tb_name, Erstellinformationen, Farbe, AufgabeErzeugen, Rtb_beschreibung);
        }
        private void check()
        {

        }


    }
}
