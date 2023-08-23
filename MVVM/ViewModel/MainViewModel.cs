using Stempeleditor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stempeleditor.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public RelayCommand UebersichtViewCommand { get; set; }
        public RelayCommand StempelEditierenViewCommand { get; set; }

        public UebersichtViewModel UebersichtVM { get; set; }
        public StempelEditierenViewModel StempelEditierenVM { get; set; }
        
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value;
                OnPorpertyChanged();
            }
        }
        public MainViewModel()
        {
            UebersichtVM = new UebersichtViewModel();
            StempelEditierenVM = new StempelEditierenViewModel();
            CurrentView = UebersichtVM;

            UebersichtViewCommand = new RelayCommand(o =>
            {
                CurrentView = UebersichtVM;
            });
            StempelEditierenViewCommand = new RelayCommand(o =>
            {
                CurrentView = StempelEditierenVM;
            });
        }
    }
}
