﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelsInterfaces;

namespace ViewModels
{
    public partial class StempelViewModel : ObservableObject, IStempelViewModel
    {
        //[ObservableProperty] Guid 

        public StempelViewModel() { }

    }
}