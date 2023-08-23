using Engine.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class Stempel
    {
        private List<Stempelverfügung>? _stempelverfügungen;
        public List<Stempelverfügung>? Stempelverfügungen { get; set; }
        public Stempel() : this(new List<Stempelverfügung>()) { }
        public Stempel(List<Stempelverfügung> stempelverfügungen)
        {
            _stempelverfügungen = stempelverfügungen;
        }
    }
}
