using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Elements
{
    internal class Stempel
    {
        #region Properties
        public List<Stempelverfuegung>? Stempelverfügungen { get; set; }
        #endregion

        #region Konstruktoren
        public Stempel() : this(new List<Stempelverfuegung>()) { }
        public Stempel(List<Stempelverfuegung> stempelverfügungen)
        {
            Stempelverfügungen = stempelverfügungen;
        }
        #endregion
    }
}
