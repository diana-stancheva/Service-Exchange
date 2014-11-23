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
    public class ProfileHubPageViewModel : ViewModelBase
    {
        private ObservableCollection<SkillViewModel> skills;
        private bool loader;
        private User currentUser;

        public ProfileHubPageViewModel()
        {
            this.GetCurrentUser();
            this.LoadSkills();
        }

        public User CurrentUser
        {
            get
            {
                if (this.currentUser == null)
                {
                    this.currentUser = new User();
                }
                return this.currentUser;
            }
            set
            {
                if (this.currentUser == null)
                {
                    this.currentUser = new User();
                }

                this.currentUser = value;

                this.RaisePropertyChanged(() => this.CurrentUser);
            }
        }

        public bool Loader
        {
            get
            {
                return this.loader;
            }
            set
            {
                this.loader = value;
                this.RaisePropertyChanged(() => this.Loader);
            }
        }

        public IEnumerable<SkillViewModel> Skills
        {
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

                this.RaisePropertyChanged(() => this.Skills);
            }
        }

        private void GetCurrentUser()
        {
            string photoStr = null;

            try
            {
                photoStr = ParseUser.CurrentUser.Get<ParseFile>("photo").Url.ToString();
            }
            catch
            {
                if (photoStr == null)
                {
                    photoStr = "http://mingus02.ist.berkeley.edu/static/img/user_default.jpg";
                }
            }




            this.CurrentUser = new User
            {
                FullName = ParseUser.CurrentUser.Get<string>("fullName"),
                Username = ParseUser.CurrentUser.Username,
                Email = ParseUser.CurrentUser.Email,
                Country = ParseUser.CurrentUser.Get<string>("country"),
                Town = ParseUser.CurrentUser.Get<string>("town"),
                MobilePhone = ParseUser.CurrentUser.Get<string>("mobilePhone"),
                //Photo = ParseUser.CurrentUser.Get<ParseFile>("photo"),
                PhotoString = photoStr
            };


        }

        private async Task LoadSkills()
        {
            var skills = await new ParseQuery<Skill>().Where(skill => skill.User == ParseUser.CurrentUser).FindAsync();
            this.Skills = skills.AsQueryable().Select(SkillViewModel.FromModel);
        }
    }
}
