﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IStorage
{
    public interface IStorageService
    {
        public void speicherStempel(string stempel, Guid guid, string stempelName);
        public string? ladeStempel(Guid guid);
        public List<string> ladeStempelListe();
    }
}
