using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySubscriptions.Model;

namespace MySubscriptions.ViewModel.Helpers
{
    public interface IFirestore
    {
        Task<bool> InsertSubscription(Subscription subscription);
        Task<bool> DeleteSubscription(Subscription subscription);
        Task<bool> UpdateSubscription(Subscription subscription);
        Task<IList<Subscription>> ReadSubscriptions();
    }

    public class DatabaseHelper
    {
        private static IFirestore firestore;

        public Task<bool> DeleteSubscription(Subscription subscription)
        {
            return firestore.DeleteSubscription(subscription);
        }

        public Task<bool> InsertSubscription(Subscription subscription)
        {
            return firestore.InsertSubscription(subscription);
        }

        public Task<IList<Subscription>> ReadSubscriptions()
        {
            return firestore.ReadSubscriptions();
        }

        public Task<bool> UpdateSubscription(Subscription subscription)
        {
            return firestore.UpdateSubscription(subscription);
        }
    }
}
