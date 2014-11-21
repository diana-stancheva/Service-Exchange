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
    public class OffersHubPageViewModel : ViewModelBase
    {
        private ObservableCollection<SkillViewModel> skillsHome;
        private ObservableCollection<SkillViewModel> skillsLifestyle;
        private ObservableCollection<SkillViewModel> skillsAnimals;
        private ObservableCollection<SkillViewModel> skills;
        private bool loader;

        public OffersHubPageViewModel()
        {
            this.LoadSkills();
        }

        private async Task LoadSkills()
        {
            this.Loader = true;

            var skills = await new ParseQuery<Skill>().FindAsync();
            this.Skills = skills.AsQueryable().Select(SkillViewModel.FromModel);

            this.Loader = false;
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

        public IEnumerable<SkillViewModel> SkillsHome
        {
            get
            {
                if (this.skillsHome == null)
                {
                    this.SkillsHome = new ObservableCollection<SkillViewModel>();
                }
                return this.skillsHome;
            }
            set
            {
                if (this.skillsHome == null)
                {
                    this.skillsHome = new ObservableCollection<SkillViewModel>();
                }

                this.skillsHome.Clear();
                foreach (var item in value)
                {
                    this.skillsHome.Add(item);
                }

                this.RaisePropertyChanged(() => this.SkillsHome);
            }
        }

        public IEnumerable<SkillViewModel> SkillsLifestyle
        {
            get
            {
                if (this.skillsLifestyle == null)
                {
                    this.SkillsLifestyle = new ObservableCollection<SkillViewModel>();
                }
                return this.skillsLifestyle;
            }
            set
            {
                if (this.skillsLifestyle == null)
                {
                    this.skillsLifestyle = new ObservableCollection<SkillViewModel>();
                }

                this.skillsLifestyle.Clear();
                foreach (var item in value)
                {
                    this.skillsLifestyle.Add(item);
                }

                this.RaisePropertyChanged(() => this.SkillsLifestyle);
            }
        }

        public IEnumerable<SkillViewModel> SkillsAnimals
        {
            get
            {
                if (this.skillsAnimals == null)
                {
                    this.SkillsAnimals = new ObservableCollection<SkillViewModel>();
                }
                return this.skillsAnimals;
            }
            set
            {
                if (this.skillsAnimals == null)
                {
                    this.skillsAnimals = new ObservableCollection<SkillViewModel>();
                }

                this.skillsAnimals.Clear();
                foreach (var item in value)
                {
                    this.skillsAnimals.Add(item);
                }

                this.RaisePropertyChanged(() => this.SkillsAnimals);
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

    }
}
