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
        public User ProviderUser
        {
            get { return GetProperty<User>(); }
            set { SetProperty<User>(value); }
        }

        [ParseFieldName("searcherUser")]
        public User SearcherUser
        {
            get { return GetProperty<User>(); }
            set { SetProperty<User>(value); }
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
