using Parse;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceExchange.Models
{
    [ParseClassName("SkillCategory")]
    public class SkillCategory : ParseObject
    {
        [ParseFieldName("name")]
        public string Name
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }
    }
}
