using Models.Elements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelsInterfaces
{
    public interface IUebersichtViewModel : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event EventHandler StempelEditierenEvent;
        public void updateList(List<Stempelverfuegung> stempelverfuegungen);
    }
}
