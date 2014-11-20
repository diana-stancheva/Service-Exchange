using ServiceExchange.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ServiceExchange.ViewModels
{
    public class SkillViewModel
    {
        public static Expression<Func<Skill, SkillViewModel>> FromModel
        {
            get
            {
                return skill =>
                    new SkillViewModel()
                    {
                        Name = skill.Name,
                        Category = skill.SkillCategory.Name,
                        Description = skill.Description
                    };
            }
        }

        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}
