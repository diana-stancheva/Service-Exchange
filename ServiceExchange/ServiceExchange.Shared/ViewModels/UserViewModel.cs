using GalaSoft.MvvmLight;
using ServiceExchange.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Text;

namespace ServiceExchange.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        public static Expression<Func<User, UserViewModel>> FromUser
        {
            get
            {
                return user => 
                    new UserViewModel()
                    {
                        Username = user.Username,
                        FullName = user.FullName,
                        Email = user.Email,
                        Raiting = user.Raiting,
                        Country = user.Country,
                        Town = user.Town,
                        //Photo = user.Photo
                    };
            }
        }

        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Raiting { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }


    }
}
