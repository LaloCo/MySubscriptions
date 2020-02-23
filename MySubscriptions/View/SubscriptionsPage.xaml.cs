using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySubscriptions.ViewModel;
using MySubscriptions.ViewModel.Helpers;
using Xamarin.Forms;

namespace MySubscriptions.View
{
    public partial class SubscriptionsPage : ContentPage
    {
        SubscriptionsVM vm;
        public SubscriptionsPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as SubscriptionsVM;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!Auth.IsAuthenticated())
            {
                await Task.Delay(300);
                await Navigation.PushAsync(new LoginPage());
            }
            else
            {
                vm.ReadSubscriptions();
            }
        }

        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NewSubscriptionPage());
        }
    }
}
