using System;
using System.Collections.ObjectModel;
using MySubscriptions.Model;
using MySubscriptions.ViewModel.Helpers;

namespace MySubscriptions.ViewModel
{
    public class SubscriptionsVM
    {
        public ObservableCollection<Subscription> Subscriptions { get; set; }

        public SubscriptionsVM()
        {
            Subscriptions = new ObservableCollection<Subscription>();
        }

        public async void ReadSubscriptions()
        {
            var subcriptions = await DatabaseHelper.ReadSubscriptions();

            Subscriptions.Clear();
            foreach(var s in subcriptions)
            {
                Subscriptions.Add(s);
            }
        }
    }
}
