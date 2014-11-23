using Parse;
using ServiceExchange.Common;
using ServiceExchange.Models;
using ServiceExchange.ViewModels;
using ServiceExchange.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ServiceExchange.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProfileHubPage : Page
    {
        public Popup AddSkillPopup { get; set; }
        public TextBox SkillName { get; set; }
        public TextBox SkillDescription { get; set; }
        public ComboBox CategoryName { get; set; }
        public Ellipse ImageContainer { get; set; }
        public ImageBrush ProfileImage { get; set; }

        public ProfileHubPage()
        {
            this.InitializeComponent();
            NetworkChecker.CheckInternetConnection();
            this.DataContext = new ProfileHubPageViewModel();
        }

        private void OnSavePopup(object sender, RoutedEventArgs e)
        {
            SkillCategory category = new SkillCategory();
            try
            {
                category.Name = this.CategoryName.SelectionBoxItem.ToString();
            }
            catch (NullReferenceException ex)
            {
                UIHelpers.NotifyUser("Select Category Please!");
            }

            Skill skill = new Skill();

            try
            {
                skill.Name = this.SkillName.Text;
            }
            catch (ArgumentException ex)
            {
                UIHelpers.NotifyUser("Skill Is Required!");
            }

            try
            {
                skill.Description = this.SkillDescription.Text;
            }
            catch (ArgumentException ex)
            {
                UIHelpers.NotifyUser("Description Is Required!");
            }

            skill.Views = 0;
            skill.SkillCategory = category;
            skill.User = Parse.ParseUser.CurrentUser;

            skill.SaveAsync();

            if (this.AddSkillPopup.IsOpen) this.AddSkillPopup.IsOpen = false;

            ErasePopupSelectedValues();
        }

        private void OnClosePopup(object sender, RoutedEventArgs e)
        {
            if (this.AddSkillPopup.IsOpen) this.AddSkillPopup.IsOpen = false;

            ErasePopupSelectedValues();
        }

        private void OnShowPopup(object sender, RoutedEventArgs e)
        {
            if (!this.AddSkillPopup.IsOpen) this.AddSkillPopup.IsOpen = true;
        }

        private void ErasePopupSelectedValues()
        {
            this.SkillName.Text = "";
            this.SkillDescription.Text = "";
            this.CategoryName.SelectedIndex = 0;
        }

        private void AddSkillPopup_Loaded(object sender, RoutedEventArgs e)
        {
            this.AddSkillPopup = (Popup)sender;
        }

        private void SkillName_Loaded(object sender, RoutedEventArgs e)
        {
            this.SkillName = (TextBox)sender;
        }

        private void SkillDescription_Loaded(object sender, RoutedEventArgs e)
        {
            this.SkillDescription = (TextBox)sender;
        }

        private void CategoryNameComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            this.CategoryName = (ComboBox)sender;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = sender as ListView;

            if (listView == null)
            {
                return;
            }

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

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void Ellipse_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var picker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                CommitButtonText = "All done",
                SuggestedStartLocation = PickerLocationId.PicturesLibrary,
                FileTypeFilter = { ".jpg", ".jpeg", ".png", ".bmp" }
            };
            StorageFile file = await picker.PickSingleFileAsync();


            UploadFile(file);
        }

        private async void UploadFile(StorageFile file)
        {
            //RandomAccessStreamReference rasr = RandomAccessStreamReference.CreateFromUri(bitmapImage.UriSource);
            RandomAccessStreamReference rasr = RandomAccessStreamReference.CreateFromFile(file);
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
            catch (Exception ex)
            {

                UIHelpers.NotifyUser("Picture upload error");
            }

            DisplayImage();
        }

        private void DisplayImage()
        {
            ParseFile userPhoto = ParseUser.CurrentUser.Get<ParseFile>("photo");
            string photoString = ParseUser.CurrentUser.Get<ParseFile>("photo").Url.ToString();

            if (photoString == null)
            {
                return;
            }

            BitmapImage bitmapPhoto = new BitmapImage(new Uri(userPhoto.Url.ToString(), UriKind.RelativeOrAbsolute));
            this.ProfileImage.ImageSource = bitmapPhoto;
        }

        private void RefreshFrame()
        {
            var Frame = Window.Current.Content as Frame;
            Frame.Navigate(Frame.Content.GetType());
            Frame.GoBack();
        }

        private void ProfileImage_ImageOpened(object sender, RoutedEventArgs e)
        {
            this.ProfileImage = (ImageBrush)sender;
        }
    }
}
