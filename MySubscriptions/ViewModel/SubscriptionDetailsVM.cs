using System;
using System.ComponentModel;
using System.Windows.Input;
using MySubscriptions.Model;
using MySubscriptions.ViewModel.Helpers;
using Xamarin.Forms;

namespace MySubscriptions.ViewModel
{
    public class SubscriptionDetailsVM : INotifyPropertyChanged
    {
        private Subscription subscription;
        public Subscription Subscription
        {
            get
            {
                return subscription;
            }
            set
            {
                subscription = value;
                Name = subscription.Name;
                IsActive = subscription.IsActive;
                OnPropertyChanged("Subscription");
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                Subscription.Name = name;
                OnPropertyChanged("Name");
                OnPropertyChanged("Subscription");
            }
        }

        private bool isActive;
        public bool IsActive
        {
            get
            {
                return isActive;
            }
            set
            {
                isActive = value;
                Subscription.IsActive = isActive;
                OnPropertyChanged("IsActive");
                OnPropertyChanged("Subscription");
            }
        }

        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public SubscriptionDetailsVM()
        {
            UpdateCommand = new Command(Update, UpdateCanExecute);
            DeleteCommand = new Command(Delete);
        }

        private bool UpdateCanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(Name);
        }

        private void Update(object parameter)
        {
            DatabaseHelper.UpdateSubscription(Subscription);
        }

        private void Delete(object parameter)
        {
            DatabaseHelper.DeleteSubscription(Subscription);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
