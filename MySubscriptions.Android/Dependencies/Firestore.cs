using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Gms.Tasks;
using Firebase.Firestore;
using Java.Util;
using MySubscriptions.Model;
using MySubscriptions.ViewModel.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(MySubscriptions.Droid.Dependencies.Firestore))]
namespace MySubscriptions.Droid.Dependencies
{
    public class Firestore : Java.Lang.Object, IFirestore, IOnCompleteListener
    {
        List<Subscription> subscriptions;
        bool hasReadSubcriptions = false;

        public Firestore()
        {
            subscriptions = new List<Subscription>();
        }

        public async Task<bool> DeleteSubscription(Subscription subscription)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("subscriptions");
                collection.Document(subscription.Id).Delete();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
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

        public async Task<IList<Subscription>> ReadSubscriptions()
        {
            hasReadSubcriptions = false;
            var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("subscriptions");
            var query = collection.WhereEqualTo("author", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid);
            query.Get().AddOnCompleteListener(this);

            for(int i = 0; i < 25; i++)
            {
                await System.Threading.Tasks.Task.Delay(100);
                if (hasReadSubcriptions)
                    break;
            }

            return subscriptions;
        }

        public async Task<bool> UpdateSubscription(Subscription subscription)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("subscriptions");
                collection.Document(subscription.Id).Update("name", subscription.Name, "isActive", subscription.IsActive);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        private static Date DateTimeToNativeDate(DateTime date)
        {
            long dateTimeUtcAsMilliseconds = (long)date.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                ).TotalMilliseconds;
            return new Date(dateTimeUtcAsMilliseconds);
        }

        private static DateTime NativeDateToDateTime(Date date)
        {
            DateTime reference = System.TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0));
            return reference.AddMilliseconds(date.Time);
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if(task.IsSuccessful)
            {
                var documents = (QuerySnapshot)task.Result;

                subscriptions.Clear();
                foreach(var doc in documents.Documents)
                {
                    Subscription subscription = new Subscription
                    {
                        IsActive = (bool)doc.Get("isActive"),
                        Name = doc.Get("name").ToString(),
                        UserId = doc.Get("author").ToString(),
                        SubscribedDate = NativeDateToDateTime(doc.Get("subscribedDate") as Date),
                        Id = doc.Id
                    };

                    subscriptions.Add(subscription);
                }
            }
            else
            {
                subscriptions.Clear();
            }
            hasReadSubcriptions = true;
        }
    }
}
