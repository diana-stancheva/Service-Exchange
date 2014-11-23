using GalaSoft.MvvmLight;
using Parse;
using ServiceExchange.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceExchange.ViewModels
{
    public class OfferDetailsPageViewModel : ViewModelBase
    {
        public ParseUser ProviderUser { get; set; }
        public Skill Skill { get; set; }

        public OfferDetailsPageViewModel()
        {
            GetUserDetails();
        }

        private async void GetUserDetails(){
            //ParseUser providerUser = new ParseUser();
            this.ProviderUser = await GetUser();

            //Skill searchedSkill = new Skill();
            this.Skill = await GetSkill();

            var exchange = new Exchange
            {
                ProviderUser = this.ProviderUser,
                SearcherUser = ParseUser.CurrentUser,
                ExchangeStatus = new ExchangeStatus
                {
                    Name = "WaitingResponse"
                },

                SearchedSkill = this.Skill

            };
        }

        private async Task<ParseUser> GetUser()
        {
            ParseUser user = await new ParseQuery<ParseUser>().Where(u => u.Username.Equals("ivan")).FirstOrDefaultAsync();
            return user;
        }

        private async Task<Skill> GetSkill()
        {
            var skill = await new ParseQuery<Skill>().Where(s => s.Name.Equals("Drive To Work")).FirstOrDefaultAsync();
            return skill;
        }

    }
}
