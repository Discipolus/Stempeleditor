using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelsInterfaces;

namespace ViewModels
{
    public partial class StempelViewModel : ObservableObject, IStempelViewModel
    {
        [ObservableProperty] string tb_guid;
        [ObservableProperty] string tb_name;
        [ObservableProperty] bool erstellinformationen;
        [ObservableProperty] bool aufgabeErzeugen;
        [ObservableProperty] Color farbe;
        [ObservableProperty] string rtb_beschreibung;
        //[ObservableProperty] string tb_platzhalter;
        //[ObservableProperty] string tb_funktionen;

        public StempelViewModel() { }

    }
}
