using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelsInterfaces;

namespace ViewModels
{
    public partial class StempelEditierenViewModel : ObservableObject, IStempelEditierenViewModel
    {
        [ObservableProperty] IStempelViewModel stempelview;

        public StempelEditierenViewModel(IStempelViewModel vm)
        {
            stempelview = vm;
        }
    }
}
