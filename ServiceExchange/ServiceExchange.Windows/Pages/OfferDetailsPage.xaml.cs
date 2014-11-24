using ServiceExchange.Common;
using ServiceExchange.ViewModels;
using ServiceExchange.Models;

using System;
using System.Linq;
using System.Threading.Tasks;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

using Parse;
using SQLite;
using System.Collections.Generic;
using Windows.Storage;
using ServiceExchange.SQLModels;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ServiceExchange.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OfferDetailsPage : Page
    {
        private const string dbName = "Contacts.db";

        public OfferDetailsPage()
        {
            this.InitializeComponent();
            NetworkChecker.CheckInternetConnection();
            this.DataContext = new OfferDetailsPageViewModel();

            //CreateDbIfNotExist();
        }

        public void AddContactToSqlButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Implement this method
            //throw new NotImplementedException();
            AddContact();
        }

        private async Task AddContact()
        {
            Contact contact = new Contact
            {
                Title = "Ivan Ivanov",
                Email = "ivan@ivan.com",
                PhoneNumber = "0888123456",
                Country = "Bulgaria",
                Town = "Sofia"
            };

            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            await conn.InsertAsync(contact);

            UIHelpers.NotifyUser("Successfuly saved contact!");
        }

        private async void ServiceRequest_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ParseUser providerUser = new ParseUser();
            providerUser = await GetUser();
            Skill searchedSkill = new Skill();
            searchedSkill = await GetSkill();

            var exchange = new Exchange
            {
                ProviderUser = providerUser,
                SearcherUser = ParseUser.CurrentUser,
                ExchangeStatus = new ExchangeStatus
                {
                    Name = "WaitingResponse"
                },

                SearchedSkill = searchedSkill

            };

            SendExchangeRequest(exchange);

            UIHelpers.NotifyUser("Successfuly sent ServiseExchange Request!");
        }

        private void SendExchangeRequest(Exchange exchange)
        {
            exchange.SaveAsync();
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

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(OffersHubPage));
        }


    }
}
