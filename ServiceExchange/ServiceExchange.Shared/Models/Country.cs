using Parse;

using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceExchange.Models
{
    [ParseClassName("Country")]
    public class Country : ParseObject
    {
        private IEnumerable<string> towns;

        public Country(){
            this.towns = new List<string>();
        }

        [ParseFieldName("name")]
        public string Name 
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("towns")]
        public IEnumerable<string> Towns 
        {
            get { return GetProperty<IEnumerable<string>>(); }
            set { SetProperty<IEnumerable<string>>(value); }
        }
    }
}
