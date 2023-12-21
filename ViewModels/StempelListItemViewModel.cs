using CommunityToolkit.Mvvm.ComponentModel;
using Models.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelsInterfaces;

namespace ViewModels
{
    public partial class StempelListItemViewModel : ObservableObject, IStempelListItemViewModel
    {
        [ObservableProperty] Stempelverfuegung stempel;
        public StempelListItemViewModel(Stempelverfuegung stempel) 
        {
            this.Stempel = stempel;
        }
    }
}
