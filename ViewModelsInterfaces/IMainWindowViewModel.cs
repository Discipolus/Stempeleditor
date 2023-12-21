using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ViewModelsInterfaces
{    
    public partial interface IMainWindowViewModel : INotifyPropertyChanged, INotifyPropertyChanging
    {
        //readonly IStempelEditierenViewModel stempelEditierenVm;
        //readonly IUebersichtViewModel uebersichtVm;
        [RelayCommand()]
        public abstract void UebersichtAufrufen();
        [RelayCommand()]
        public abstract void StempelEditierenAufrufen();
        [RelayCommand()]
        public abstract void SchliesseProgramm();
    }
}
