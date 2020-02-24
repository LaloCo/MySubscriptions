using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MySubscriptions.Model;
using MySubscriptions.View;
using MySubscriptions.ViewModel.Helpers;

namespace MySubscriptions.ViewModel
{
    public class SubscriptionsVM : INotifyPropertyChanged
    {
        private Subscription selectedSubscription;
        public Subscription SelectedSubscription
        {
            get
            {
                return selectedSubscription;
            }
            set
            {
                selectedSubscription = value;
                OnPropertyChanged("SelectedSubscription");
                if (selectedSubscription != null)
                    App.Current.MainPage.Navigation.PushAsync(new SubscriptionDetailsPage(selectedSubscription));
            }
        }

        public ObservableCollection<Subscription> Subscriptions { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

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

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
