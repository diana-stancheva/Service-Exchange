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
            SkillCategory category = new SkillCategory
            {
                Name = this.CategoryName.SelectionBoxItem.ToString()
            };

            Skill skill = new Skill();

            skill.Name = this.SkillName.Text;
            skill.Description = this.SkillDescription.Text;
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


            //UploadFile(file);

            DisplayImage(file);

        }

        private async void UploadFile(StorageFile file)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes("User Picture Upload");
            ParseUser currentUser = ParseUser.CurrentUser;
            currentUser["photo"] = new ParseFile(file.Path, data);
            await currentUser.SaveAsync();
        }

        private void DisplayImage(StorageFile file)
        {
            if (file == null)
            {
                return;
            }

            //NotifyUser(file.Path);
            this.ProfileImage = new ImageBrush();
            this.ProfileImage.ImageSource = new BitmapImage(
                    new Uri(file.Path)
                );
        }

        private static async Task NotifyUser(String message)
        {
            var dialog = new MessageDialog(message);
            await dialog.ShowAsync();
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
