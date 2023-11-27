using CommunityToolkit.Mvvm.ComponentModel;
using IXMLConverter;
using IStorage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelsInterfaces;
using Models.Elements;
using CommunityToolkit.Mvvm.Input;

namespace ViewModels
{
    public partial class UebersichtViewModel : ObservableObject, IUebersichtViewModel
    {
        [ObservableProperty] ObservableCollection<Stempelverfuegung> list = new ObservableCollection<Stempelverfuegung>();
        public Stempelverfuegung SelectedStempel { get; set; }
        private IXMLConverter.IXMLConverter iXMLConverter;
        private IStorageService iStorageService;

        public UebersichtViewModel(IXMLConverter.IXMLConverter xMLConverter, IStorageService storageService)
        {            
            iXMLConverter = xMLConverter;
            iStorageService = storageService;
            foreach (string stempelxml in iStorageService.ladeStempelListe())
            {
                list.Add(iXMLConverter.convertToStempelverfuegung(stempelxml));
            }
        }
        [RelayCommand()]
        public void StempelEditierenAufrufen()
        {
            if (SelectedStempel != null)
            {
                //StempelEditierenViewModel stempelEditierenViewModel = new StempelEditierenViewModel(iXMLConverter, iStorageService, SelectedStempel);
                //StempelEditierenView stempelEditierenView = new StempelEditierenView(stempelEditierenViewModel);
                //stempelEditierenView.Show();
            }
        }
    }
}
