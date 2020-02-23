using System;
using System.ComponentModel;
using System.Windows.Input;
using MySubscriptions.ViewModel.Helpers;
using Xamarin.Forms;

namespace MySubscriptions.ViewModel
{
    public class NewSubscriptionVM : INotifyPropertyChanged
    {
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
                OnPropertyChanged("Name");
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
                OnPropertyChanged("IsActive");
            }
        }

        public ICommand SaveSubscriptionCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public NewSubscriptionVM()
        {
            SaveSubscriptionCommand = new Command(SaveSubscription, SaveSubscriptionCanExecute);
        }

        private bool SaveSubscriptionCanExecute(object arg)
        {
            return !string.IsNullOrEmpty(Name);
        }

        private void SaveSubscription(object obj)
        {
            bool result = DatabaseHelper.InsertSubscription(new Model.Subscription
            {
                IsActive = IsActive,
                Name = Name,
                UserId = Auth.GetCurrentUserId(),
                SubscribedDate = DateTime.Now
            });
            if (result)
                App.Current.MainPage.Navigation.PopAsync();
            else
                App.Current.MainPage.DisplayAlert("Error", "Something went wrong, please try again", "Ok");
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
