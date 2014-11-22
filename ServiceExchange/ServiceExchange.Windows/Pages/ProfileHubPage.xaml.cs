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
using Windows.UI.Popups;
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
    public sealed partial class ProfileHubPage : Page
    {
        public Popup AddSkillPopup { get; set; }
        public TextBox SkillName { get; set; }
        public TextBox SkillDescription { get; set; }
        public ComboBox CategoryName { get; set; }

        public ProfileHubPage()
        {
            this.InitializeComponent();
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
    }
}
