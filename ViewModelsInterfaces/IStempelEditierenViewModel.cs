using Models.Elements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelsInterfaces
{
    public interface IStempelEditierenViewModel : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event EventHandler StempelSpeichernEvent;
        public void fillStempelverfuegung(Stempelverfuegung stempelverfuegung);
    }
}
