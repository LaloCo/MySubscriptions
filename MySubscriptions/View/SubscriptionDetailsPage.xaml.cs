using System;
using System.Collections.Generic;
using MySubscriptions.Model;
using MySubscriptions.ViewModel;
using Xamarin.Forms;

namespace MySubscriptions.View
{
    public partial class SubscriptionDetailsPage : ContentPage
    {
        SubscriptionDetailsVM vm;

        public SubscriptionDetailsPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as SubscriptionDetailsVM;
        }

        public SubscriptionDetailsPage(Subscription selectedSubcription)
        {
            InitializeComponent();

            vm = Resources["vm"] as SubscriptionDetailsVM;
            vm.Subscription = selectedSubcription;
        }
    }
}
