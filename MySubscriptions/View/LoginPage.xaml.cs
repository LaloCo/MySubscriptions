using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MySubscriptions.View
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        void RegisterLabel_Tapped(object sender, EventArgs args)
        {
            registerStackLayout.IsVisible = true;
            loginStackLayout.IsVisible = false;
        }

        void LoginLabel_Tapped(object sender, EventArgs args)
        {
            registerStackLayout.IsVisible = false;
            loginStackLayout.IsVisible = true;
        }
    }
}
