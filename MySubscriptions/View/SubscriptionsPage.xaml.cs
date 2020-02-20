using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySubscriptions.ViewModel.Helpers;
using Xamarin.Forms;

namespace MySubscriptions.View
{
    public partial class SubscriptionsPage : ContentPage
    {
        public SubscriptionsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!Auth.IsAuthenticated())
            {
                await Task.Delay(300);
                await Navigation.PushAsync(new LoginPage());
            }
        }

        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NewSubscriptionPage());
        }
    }
}
