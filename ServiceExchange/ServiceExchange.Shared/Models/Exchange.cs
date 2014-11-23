using Parse;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceExchange.Models
{
    [ParseClassName("Exchange")]
    public class Exchange : ParseObject
    {
        [ParseFieldName("providerUser")]
        public ParseUser ProviderUser
        {
            get { return GetProperty<ParseUser>(); }
            set { SetProperty<ParseUser>(value); }
        }

        [ParseFieldName("searcherUser")]
        public ParseUser SearcherUser
        {
            get { return GetProperty<ParseUser>(); }
            set { SetProperty<ParseUser>(value); }
        }

        [ParseFieldName("exchangeStatus")]
        public ExchangeStatus ExchangeStatus
        {
            get { return GetProperty<ExchangeStatus>(); }
            set { SetProperty<ExchangeStatus>(value); }
        }

        [ParseFieldName("searchedSkill")]
        public Skill SearchedSkill
        {
            get { return GetProperty<Skill>(); }
            set { SetProperty<Skill>(value); }
        }

        [ParseFieldName("aprovedSkill")]
        public Skill AprovedSkill
        {
            get { return GetProperty<Skill>(); }
            set { SetProperty<Skill>(value); }
        }
    }
}
