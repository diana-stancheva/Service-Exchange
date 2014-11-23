using Parse;

using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceExchange.Models
{
    public class User : ParseUser
    {
        [ParseFieldName("fullName")]
        public string FullName
        {
            get { return GetProperty<string>(); }
            set 
            {
                if (value == String.Empty)
                {
                    throw new ArgumentException();
                }

                SetProperty<string>(value); 
            }
        }

        [ParseFieldName("country")]
        public string Country
        {
            get { return GetProperty<string>(); }
            set 
            {
                if (value == String.Empty)
                {
                    throw new ArgumentException();
                }

                SetProperty<string>(value); 
            }
        }

        [ParseFieldName("town")]
        public string Town
        {
            get { return GetProperty<string>(); }
            set 
            {
                if (value == String.Empty)
                {
                    throw new ArgumentException();
                }

                SetProperty<string>(value); 
            }
        }

        [ParseFieldName("raiting")]
        public int Raiting
        {
            get { return GetProperty<int>(); }
            set { SetProperty<int>(value); }
        }

        [ParseFieldName("photo")]
        public ParseFile Photo
        {
            get { return GetProperty<ParseFile>(); }
            set { SetProperty<ParseFile>(value); }
        }

        public string PhotoString { get; set; }

        [ParseFieldName("mobilePhone")]
        public string MobilePhone
        {
            get { return GetProperty<string>(); }
            set 
            {
                if (value == String.Empty)
                {
                    throw new ArgumentException();
                }

                SetProperty<string>(value); 
            }
        }
    }
}
