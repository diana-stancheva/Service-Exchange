using Parse;

using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceExchange.Models
{
    [ParseClassName("Comment")]
    public class Comment : ParseObject
    {
        [ParseFieldName("toUser")]
        public User ToUser
        {
            get { return GetProperty<User>(); }
            set { SetProperty<User>(value); }
        }

        [ParseFieldName("fromUser")]
        public User FromUser
        {
            get { return GetProperty<User>(); }
            set { SetProperty<User>(value); }
        }

        [ParseFieldName("comment")]
        public string CommentText
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("exchange")]
        public Exchange Exchange
        {
            get { return GetProperty<Exchange>(); }
            set { SetProperty<Exchange>(value); }
        }
    }
}
