using ServiceExchange.Pages;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using System.Linq;

namespace ServiceExchange.Common
{
    public class NetworkChecker
    {
        public static void CheckForInternetConnection()
        {
            string isNetworkAvailable =
            NetworkInterface.GetIsNetworkAvailable() ? "Network Connection is ON" : "Network Connection is OFF";

            NotifyUser(isNetworkAvailable);
        }

        public static void CheckInternetConnection()
        {
            var profiles = NetworkInformation.GetConnectionProfiles();
            var internetProfile = NetworkInformation.GetInternetConnectionProfile();
            var isConnected = profiles.Any(s => s.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess)
                || (internetProfile != null && internetProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess);

            if (!isConnected)
            {
                NotifyUser("Network Connection Is Not Available");
            }
        }

        private static async Task NotifyUser(String message)
        {
            var dialog = new MessageDialog(message);
            await dialog.ShowAsync();
        }
    }
}
