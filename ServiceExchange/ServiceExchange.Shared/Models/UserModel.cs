using Parse;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceExchange.Models
{
    [ParseClassName("_User")]
    public class UserModel : ParseUser
    {
        [ParseFieldName("FullName")]
        public string FullName { get; set; }

        [ParseFieldName("Country")]
        public string Country { get; set; }

        [ParseFieldName("Town")]
        public string Town { get; set; }
    }
}
