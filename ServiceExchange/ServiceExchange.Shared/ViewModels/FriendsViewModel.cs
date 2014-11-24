using GalaSoft.MvvmLight;
using ServiceExchange.SQLModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ServiceExchange.ViewModels
{
    public class FriendsViewModel : ViewModelBase
    {
        private const string dbName = "Contacts.db";

        private ObservableCollection<Contact> friends;

        public FriendsViewModel()
        {

            IsDbExist();
            LoadContacts();
        }

        private async Task LoadContacts()
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            var allArticles = await conn.QueryAsync<Contact>("SELECT * FROM Contacts");
            this.Friends = allArticles;
        }

        private async void IsDbExist()
        {
            bool dbExists = await CheckDbAsync(dbName);

            if (!dbExists)
            {
                return;
            }
        }
        private async Task<bool> CheckDbAsync(string dbName)
        {
            bool dbExist = true;
            try
            {
                StorageFile sf = await ApplicationData.Current.LocalFolder.GetFileAsync(dbName);
            }
            catch (Exception)
            {
                dbExist = false;
            }
            return dbExist;
        }

        public IEnumerable<Contact> Friends
        {
            get
            {
                if (this.friends == null)
                {
                    this.Friends = new ObservableCollection<Contact>();
                }
                return this.friends;
            }
            set
            {
                if (this.friends == null)
                {
                    this.friends = new ObservableCollection<Contact>();
                }

                this.friends.Clear();
                foreach (var item in value)
                {
                    this.friends.Add(item);
                }

                this.RaisePropertyChanged(() => this.Friends);
            }
        }
    }
}
