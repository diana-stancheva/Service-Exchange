using GalaSoft.MvvmLight;
using Parse;
using ServiceExchange.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceExchange.ViewModels
{
    public class AppViewModel : ViewModelBase
    {
        public User CurrentUser { get; set; }
        public IEnumerable<SkillCategoryViewModel> SkillCategory { get; set; }

        public AppViewModel()
        {
            this.CurrentUser = new User
            {
                FullName = ParseUser.CurrentUser.Get<string>("fullName"),
                Username = ParseUser.CurrentUser.Username,
                Email = ParseUser.CurrentUser.Email,
                Country = ParseUser.CurrentUser.Get<string>("country"),
                Town = ParseUser.CurrentUser.Get<string>("town"),
                MobilePhone = ParseUser.CurrentUser.Get<string>("mobilePhone")
            };
            
            //LoadSkillCategories();

            
        }

        public async Task LoadSkillCategories()
        {
            var categories = await new ParseQuery<SkillCategory>().FindAsync();
            this.SkillCategory = categories.AsQueryable().Select(SkillCategoryViewModel.FromModel);
        }


    }
}
