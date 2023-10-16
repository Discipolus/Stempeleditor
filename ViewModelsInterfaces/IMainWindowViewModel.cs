using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelsInterfaces
{    
    public interface IMainWindowViewModel : INotifyPropertyChanged, INotifyPropertyChanging
    {
        [RelayCommand()]
        public abstract void UebersichtAufrufen();
        [RelayCommand()]
        public abstract void StempelEditierenAufrufen();
    }
}
