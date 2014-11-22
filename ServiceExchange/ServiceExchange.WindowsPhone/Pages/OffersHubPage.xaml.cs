using ServiceExchange.Common;
using ServiceExchange.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
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
    public sealed partial class OffersHubPage : Page
    {
        public OffersHubPage()
        {
            this.InitializeComponent();
            NetworkChecker.CheckInternetConnection();

            HardwareButtons.BackPressed += HardwareButtons_BackPressed;

            this.DataContext = new OffersHubPageViewModel();
        }

        private void OffersControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = (sender as ListView);
            var selectedItem = listView.SelectedItem;

            
        }

        void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {

            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                //Indicate the back button press is handled so the app does not exit
                e.Handled = true;
            }
        }
    }
}
