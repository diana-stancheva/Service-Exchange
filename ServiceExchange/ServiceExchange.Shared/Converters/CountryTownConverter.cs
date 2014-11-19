using ServiceExchange.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace ServiceExchange.Converters
{
    public class CountryTownConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (!(value is User)) throw new NotSupportedException();
            User u = value as User;
            return u.Country + ", " + u.Town;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
