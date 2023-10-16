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
        public List<Stempelverfügung>? Stempelverfügungen { get; set; }
        #endregion

        #region Konstruktoren
        public Stempel() : this(new List<Stempelverfügung>()) { }
        public Stempel(List<Stempelverfügung> stempelverfügungen)
        {
            Stempelverfügungen = stempelverfügungen;
        }
        #endregion
    }
}
