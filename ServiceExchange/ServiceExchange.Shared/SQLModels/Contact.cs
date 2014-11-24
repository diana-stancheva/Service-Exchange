using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceExchange.SQLModels
{
    [Table("Contacts")]
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

       //[Unique, MaxLength(150)]
        public string Title { get; set; }
        
        //[Unique, MaxLength(150)]
        public string PhoneNumber { get; set; }

        //[Unique, MaxLength(150)]
        public string Email { get; set; }

        public string Town { get; set; }

        public string Country { get; set; }

    }
}
