using GalaSoft.MvvmLight;
using Parse;
using ServiceExchange.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ServiceExchange.ViewModels
{
    public class AppViewModel : ViewModelBase
    {
        private ObservableCollection<SkillViewModel> skills;


        public AppViewModel()
        {
            this.GetCurrentUser();
            this.LoadSkills();
        }

        public User CurrentUser { get; set; }

        public IEnumerable<SkillViewModel> Skills { 
            get
            {
                if (this.skills == null)
                {
                    this.Skills = new ObservableCollection<SkillViewModel>();
                }
                return this.skills;
            } 
            set 
            {
                if (this.skills == null)
                {
                    this.skills = new ObservableCollection<SkillViewModel>();
                }
                this.skills.Clear();
                foreach (var item in value)
                {
                    this.skills.Add(item);
                }
            } 
        }

        private void GetCurrentUser()
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
        }

        private async Task LoadSkills()
        {
            //var skills = await new ParseQuery<Skill>().FindAsync();
            //this.Skills = skills.AsQueryable().Select(SkillViewModel.FromModel);

            var skills = await new ParseQuery<Skill>().FindAsync();
            this.Skills = skills.AsQueryable().Select(SkillViewModel.FromModel);
        }
    }
}
