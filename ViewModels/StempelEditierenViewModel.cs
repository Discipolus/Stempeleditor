using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Models.Elements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ViewModelsInterfaces;

namespace ViewModels
{
    public partial class StempelEditierenViewModel : ObservableObject, IStempelEditierenViewModel
    {
        //[ObservableProperty] IStempelViewModel stempelView;
        [ObservableProperty] string? tb_guid;
        [ObservableProperty] string? tb_name;
        [ObservableProperty] bool erstellinformationen;
        [ObservableProperty] bool aufgabeErzeugen;
        [ObservableProperty] Color farbe;
        [ObservableProperty] XmlDocument? rtb_beschreibung;
        [ObservableProperty] Stempelverfuegung stempelverfuegung;

        //public StempelEditierenViewModel(IStempelViewModel vm)
        //{
        //    if (vm == null)
        //    {
        //        throw new ArgumentNullException("IStempelViewModel Interface null");
        //    }
        //    this.StempelView = vm;            
        //}
        [RelayCommand]
        public void Neu()
        {
            clear();
        }
        [RelayCommand]
        public void Abbrechen()
        {
            
        }

        [RelayCommand]
        public void Speichern()
        {
            
        }
        private void clear()
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
    }
}
