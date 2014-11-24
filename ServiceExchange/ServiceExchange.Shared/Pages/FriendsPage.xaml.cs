using ServiceExchange.SQLModels;
using ServiceExchange.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ServiceExchange.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FriendsPage : Page
    {
        private const string dbName = "Contacts.db";

        public FriendsPage()
        {
            this.InitializeComponent();
            this.DataContext = new FriendsViewModel();
        }

        private void RemoveContactButton_Click(object sender, RoutedEventArgs e)
        {
            Contact selectedItem = (Contact)this.ContactsList.SelectedItem;
            int id = selectedItem.ID;
            DeleteArticleAsync(id);
        }

        private async Task DeleteArticleAsync(int id)
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            // Retrieve Article
            var contact = await conn.Table<Contact>().Where(x => x.ID == id).FirstOrDefaultAsync();
            if (contact != null)
            {
                // Delete record
                await conn.DeleteAsync(contact);
            }

            RefreshFrame();
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void RefreshFrame()
        {
            var Frame = Window.Current.Content as Frame;
            Frame.Navigate(Frame.Content.GetType());
            Frame.GoBack();
        }

        private void ContactsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.BottomAppBar != null)
            {
                if (this.BottomAppBar.IsOpen == true)
                {
                    this.BottomAppBar.IsOpen = false;
                }
                else
                {
                    this.BottomAppBar.IsOpen = true;
                }


            }
        }

        private void ContactsList_Holding(object sender, HoldingRoutedEventArgs e)
        {
            var test = sender;
        }
    }
}
