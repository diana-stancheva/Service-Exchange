using GalaSoft.MvvmLight;
using ServiceExchange.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ServiceExchange.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        public ObservableCollection<Country> Countries { get; set; }
    }
}
