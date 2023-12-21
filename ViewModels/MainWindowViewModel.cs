using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows;
using ViewModelsInterfaces;
using IStorage;
using IXMLConverter;
using Models.Elements;

namespace ViewModels
{
    public partial class MainWindowViewModel : ObservableObject, IMainWindowViewModel 
    { 
        [ObservableProperty] object currentView;
        [ObservableProperty] IStempelEditierenViewModel stempelEditierenVm;
        [ObservableProperty] IUebersichtViewModel uebersichtVm;
        [ObservableProperty] private bool uebersichtGeoeffnet;
        [ObservableProperty] private bool stempelEditorGeoeffnet;
        private readonly IStorageService storage;
        private readonly IXMLConverter.IXMLConverter xmlConverter;
        private List<Stempelverfuegung> stempelverfuegungen;

        public event EventHandler CloseAppEvent;

        //public MainWindowViewModel() { }
        public MainWindowViewModel(IStempelEditierenViewModel stempelEditVm, IUebersichtViewModel uebersichtVm, IStorageService storage, IXMLConverter.IXMLConverter xmlConverter)
        {
            if (stempelEditVm == null || uebersichtVm == null)
            {
                throw new ArgumentNullException("Interfaces null");
            }
            this.StempelEditierenVm = stempelEditVm!;
            this.UebersichtVm = uebersichtVm!;
            this.storage = storage;
            this.xmlConverter = xmlConverter;
            getStempelverfuegungen();
            addEvents();
            UebersichtAufrufen();
        }
        private void getStempelverfuegungen()
        {
            stempelverfuegungen = new List<Stempelverfuegung>();
            foreach (string stempelXml in storage.ladeStempelListe())
            {
                stempelverfuegungen.Add(xmlConverter.convertToStempelverfuegung(stempelXml));
            }
        }
        private void addEvents()
        {
            StempelEditierenVm.StempelSpeichernEvent += speicherAnfrage;
            UebersichtVm.StempelEditierenEvent += editiereStempel;
        }
        [RelayCommand()]
        public void UebersichtAufrufen()
        {
            CurrentView = UebersichtVm!;
            UebersichtGeoeffnet = true;
            StempelEditorGeoeffnet = false;
            UebersichtVm.updateList(stempelverfuegungen);
        }

        [RelayCommand()]
        public void StempelEditierenAufrufen() 
        {
            CurrentView = StempelEditierenVm;
            UebersichtGeoeffnet = false;
            StempelEditorGeoeffnet = true;
        }

        [RelayCommand()]
        public void SchliesseProgramm()
        {            
            CloseAppEvent?.Invoke(this, EventArgs.Empty);
        }
        private void speicherAnfrage(object sender, EventArgs e)
        {            
            StempelEventArgs stempelEventArgs = (StempelEventArgs)e;            
            if (stempelEventArgs.Stempelverfuegung != null)
            {
                updateListe(stempelEventArgs.Stempelverfuegung);
                string stempelXml = xmlConverter.convertToXml(stempelEventArgs.Stempelverfuegung);
                storage.speicherStempel(stempelXml, stempelEventArgs.Stempelverfuegung.Id, stempelEventArgs.Stempelverfuegung.Name);
                UebersichtAufrufen();
            }            
        }
        private void updateListe(Stempelverfuegung stempel)
        {
            if (stempelverfuegungen != null && stempel != null)
            {
                stempelverfuegungen.Where(x => x.Id == stempel.Id).ToList().ForEach(x => stempelverfuegungen.Remove(x));
                stempelverfuegungen.Add(stempel);
            }
        }
        private void editiereStempel(object sender, EventArgs e)
        {
            StempelEventArgs stempelEventArgs = (StempelEventArgs)e;
            if (stempelEventArgs.Stempelverfuegung != null)
            {
                StempelEditierenVm.fillStempelverfuegung(stempelEventArgs.Stempelverfuegung);
                StempelEditierenAufrufen();
            }
        }
    }
}
