using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Java.Util;
using MySubscriptions.Model;
using MySubscriptions.ViewModel.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(MySubscriptions.Droid.Dependencies.Firestore))]
namespace MySubscriptions.Droid.Dependencies
{
    public class Firestore : IFirestore
    {
        public Firestore()
        {
        }

        public Task<bool> DeleteSubscription(Subscription subscription)
        {
            throw new NotImplementedException();
        }

        public bool InsertSubscription(Subscription subscription)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("subscriptions");
                var subcriptionDocument = new Dictionary<string, Java.Lang.Object>
                {
                    { "author", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid },
                    { "name", subscription.Name },
                    { "isActive", subscription.IsActive },
                    { "subscribedDate", DateTimeToNativeDate(subscription.SubscribedDate) }
                };
                collection.Add(subcriptionDocument);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Task<IList<Subscription>> ReadSubscriptions()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateSubscription(Subscription subscription)
        {
            throw new NotImplementedException();
        }

        private static Date DateTimeToNativeDate(DateTime date)
        {
            long dateTimeUtcAsMilliseconds = (long)date.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                ).TotalMilliseconds;
            return new Date(dateTimeUtcAsMilliseconds);
        }
    }
}
