using ServiceExchange.Common;
using ServiceExchange.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class OfferDetailsPage : Page
    {
        public OfferDetailsPage()
        {
            this.InitializeComponent();
            NetworkChecker.CheckInternetConnection();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(OffersHubPage));
        }

        private void ServiceRequest_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var exchange = new ExchangeViewModel
            {

            };
        }
    }
}
