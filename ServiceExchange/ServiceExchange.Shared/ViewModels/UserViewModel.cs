using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ServiceExchange.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int Raiting { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
