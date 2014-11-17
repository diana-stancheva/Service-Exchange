using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceExchange.ViewModels
{
    public class OfferViewModel
    {
        public UserViewModel Provider { get; set; }
        public SkillViewModel Skill { get; set; }
    }
}
