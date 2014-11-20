using Parse;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceExchange.Models
{
    [ParseClassName("Skill")]
    public class Skill : ParseObject
    {
        [ParseFieldName("name")]
        public string Name
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("description")]
        public string Description
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("skillCategory")]
        public SkillCategory SkillCategory
        {
            get { return GetProperty<SkillCategory>(); }
            set { SetProperty<SkillCategory>(value); }
        }

        [ParseFieldName("views")]
        public int Views
        {
            get { return GetProperty<int>(); }
            set { SetProperty<int>(value); }
        }

        [ParseFieldName("user")]
        public ParseUser User
        {
            get { return GetProperty<ParseUser>(); }
            set { SetProperty<ParseUser>(value); }
        }
    }
}
