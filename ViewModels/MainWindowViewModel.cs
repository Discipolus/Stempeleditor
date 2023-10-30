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

namespace ViewModels
{
    public partial class MainWindowViewModel : ObservableObject, IMainWindowViewModel 
    { 
        [ObservableProperty] object currentView;
        [ObservableProperty] IStempelEditierenViewModel stempelEditierenVm;
        [ObservableProperty] IUebersichtViewModel uebersichtVm;

        

        public event EventHandler CloseAppEvent;

        //public MainWindowViewModel() { }
        public MainWindowViewModel(IStempelEditierenViewModel stempelEditVm, IUebersichtViewModel uebersichtVm)
        {
            if (stempelEditVm == null || uebersichtVm == null)
            {
                throw new ArgumentNullException("Interfaces null");
            }
            this.StempelEditierenVm = stempelEditVm!;
            this.UebersichtVm = uebersichtVm!;
            UebersichtAufrufen();
        }
        [RelayCommand()]
        public void UebersichtAufrufen()
        {
            CurrentView = UebersichtVm!;
        }

        [RelayCommand()]
        public void StempelEditierenAufrufen() 
        {
            CurrentView = StempelEditierenVm;
        }

        [RelayCommand()]
        public void SchliesseProgramm()
        {            
            CloseAppEvent?.Invoke(this, EventArgs.Empty);
        }

    }
}
