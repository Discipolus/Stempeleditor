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
using ViewModelsInterfaces;

namespace ViewModels
{
 //   [INotifyPropertyChanged]
    public partial class MainWindowViewModel : ObservableObject, IMainWindowViewModel
    {
        //public RelayCommand UebersichtViewCommand { get; set; }
        //public RelayCommand StempelEditierenViewCommand { get; set; }

        //public UebersichtViewModel UebersichtVM { get; set; }
        //public StempelEditierenViewModel StempelEditierenVM { get; set; }

        [ObservableProperty] private object currentView;

        //private object _currentView;

        //public object CurrentView
        //{
        //    get { return _currentView; }
        //    set
        //    {
        //        _currentView = value;                
        //        OnPropertyChanged(new PropertyChangedEventArgs(nameof(CurrentView)));
        //    }
        //}

        private readonly IStempelEditierenViewModel stempelEditierenVm;
        private readonly IUebersichtViewModel uebersichtVm;

        public MainWindowViewModel(IStempelEditierenViewModel stempelEditVm, IUebersichtViewModel uebersichtVm)
        {
            this.stempelEditierenVm = stempelEditVm;
            this.uebersichtVm = uebersichtVm;
            //UebersichtVM = new UebersichtViewModel();
            //StempelEditierenVM = new StempelEditierenViewModel();
            //CurrentView = UebersichtVM;

            //UebersichtViewCommand = new RelayCommand(o =>
            //{
            //    CurrentView = UebersichtVM;
            //});
            //StempelEditierenViewCommand = new RelayCommand(o =>
            //{
            //    CurrentView = StempelEditierenVM;
            //});
        }
        //[RelayCommand()]
        public void UebersichtAufrufen()
        {
            currentView = uebersichtVm;
        }

        //[RelayCommand()]
        public void StempelEditierenAufrufen() 
        {
            currentView = stempelEditierenVm;
        }
    }
}
