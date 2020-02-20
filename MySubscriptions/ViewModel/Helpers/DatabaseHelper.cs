using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySubscriptions.Model;
using Xamarin.Forms;

namespace MySubscriptions.ViewModel.Helpers
{
    public interface IFirestore
    {
        bool InsertSubscription(Subscription subscription);
        Task<bool> DeleteSubscription(Subscription subscription);
        Task<bool> UpdateSubscription(Subscription subscription);
        Task<IList<Subscription>> ReadSubscriptions();
    }

    public class DatabaseHelper
    {
        private static IFirestore firestore = DependencyService.Get<IFirestore>();

        public static Task<bool> DeleteSubscription(Subscription subscription)
        {
            return firestore.DeleteSubscription(subscription);
        }

        public static bool InsertSubscription(Subscription subscription)
        {
            return firestore.InsertSubscription(subscription);
        }

        public static Task<IList<Subscription>> ReadSubscriptions()
        {
            return firestore.ReadSubscriptions();
        }

        public static Task<bool> UpdateSubscription(Subscription subscription)
        {
            return firestore.UpdateSubscription(subscription);
        }
    }
}
