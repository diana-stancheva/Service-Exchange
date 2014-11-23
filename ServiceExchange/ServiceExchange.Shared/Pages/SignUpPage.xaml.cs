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
using ServiceExchange.Common;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;

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
            NetworkChecker.CheckInternetConnection();
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage));
        }

        public async void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            var user = new User();

            try
            {
                user.MobilePhone = this.mobilePhone.Text;
            }
            catch (ArgumentException ex)
            {
                UIHelpers.NotifyUser("Mobile Phone Is Required");
            }

            try
            {
                user.Email = this.email.Text;
            }
            catch (ArgumentException ex)
            {
                UIHelpers.NotifyUser("Email Is Required");
            }

            try
            {
                user.FullName = this.fullName.Text;
            }
            catch (ArgumentException ex)
            {
                UIHelpers.NotifyUser("Full Name Is Required");
            }

            try
            {
                user.Country = this.country.Text;
            }
            catch (ArgumentException ex)
            {
                UIHelpers.NotifyUser("Country  Is Required");
            }


            try
            {
                user.Town = this.town.Text;
            }
            catch (ArgumentException ex)
            {
                UIHelpers.NotifyUser("Town  Is Required");
            }
            try
            {
                user.Username = this.username.Text;
            }
            catch (ArgumentException ex)
            {
                UIHelpers.NotifyUser("Username Is Required");
            }

            try
            {
                user.Password = this.password.Password;
            }
            catch (ArgumentException ex)
            {
                UIHelpers.NotifyUser("Password Is Required");
            }

            user.Raiting = 0;

            try
            {
                await user.SignUpAsync();
                AddPictureToProfile();
                this.Frame.Navigate(typeof(SignUpSuccessPage));
            }
            catch (Exception ex)
            {
                UIHelpers.NotifyUser(ex.Message);
            }
        }

        private async void AddPictureToProfile()
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri(@"http://mingus02.ist.berkeley.edu/static/img/user_default.jpg", UriKind.RelativeOrAbsolute));
            RandomAccessStreamReference rasr = RandomAccessStreamReference.CreateFromUri(bitmapImage.UriSource);
            var streamWithContent = await rasr.OpenReadAsync();
            byte[] buffer = new byte[streamWithContent.Size];
            try
            {
                await streamWithContent.ReadAsync(buffer.AsBuffer(), (uint)streamWithContent.Size, InputStreamOptions.None);
                var data = buffer;
                if (data != null)
                {
                    var user = ParseUser.CurrentUser;
                    ParseFile img = new ParseFile("picture.png", data);
                    user["photo"] = img;
                    await user.SaveAsync();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
