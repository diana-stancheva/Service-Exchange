using ServiceExchange.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using Parse;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ServiceExchange.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            this.InitializeComponent();
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage));
        }

        public async void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            var user = new User()
            {
                Username = this.username.Text,
                Password = this.password.Password,
                Email = this.email.Text,
                FullName = this.fullName.Text,
                Country = this.country.Text,
                Town = this.town.Text
            };

            try
            {
                await user.SignUpAsync();
                this.Frame.Navigate(typeof(SignUpSuccessPage));
            }
            catch (Exception ex)
            {
                var dialog = new MessageDialog(ex.Message);
                dialog.ShowAsync();
            }
        }
    }
}
