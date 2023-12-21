using Models.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class StempelEventArgs : EventArgs
    {
        public Stempelverfuegung? Stempelverfuegung { get; set; }
        public List<Stempelverfuegung>? Stempelverfuegungen { get; set; }
    }
}
