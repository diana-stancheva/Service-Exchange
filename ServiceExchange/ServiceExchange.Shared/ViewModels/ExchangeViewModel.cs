using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceExchange.ViewModels
{
    public class ExchangeViewModel
    {
        public SkillViewModel MySkill { get; set; }
        public SkillViewModel OtherSkill { get; set; }
        public UserViewModel User { get; set; }
        public string ExchangeStatus { get; set; }
        //todo comment for exchange
    }
}
