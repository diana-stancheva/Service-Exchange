﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using ServiceExchange.Models;
using Parse;
using ServiceExchange.ViewModels;
using ServiceExchange.Common;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ServiceExchange.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
            NetworkChecker.CheckInternetConnection();
            //this.DataContext = Parse.ParseUser.CurrentUser;
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SignUpPage));
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await ParseUser.LogInAsync(this.username.Text, this.password.Password);
                // Login was successful.
                this.Frame.Navigate(typeof(MainPage));
            }
            catch (Exception ex)
            {
                // The login failed. Check the error to see why.
                UIHelpers.NotifyUser(ex.Message);
            }
        }
    }
}
