using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Elements;

namespace ViewModelsInterfaces
{
    public interface IStempelViewModel : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public abstract void clear();   
        public abstract Stempelverfuegung GetStempelverfuegung();
    }
}
