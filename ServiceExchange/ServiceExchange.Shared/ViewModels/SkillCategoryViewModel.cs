using ServiceExchange.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ServiceExchange.ViewModels
{
    public class SkillCategoryViewModel
    {
        public static Expression<Func<SkillCategory, SkillCategoryViewModel>> FromModel
        {
            get
            {
                return skill =>
                    new SkillCategoryViewModel()
                    {
                        Name = skill.Name
                    };
            }
        }

        public string Name { get; set; }
    }
}
