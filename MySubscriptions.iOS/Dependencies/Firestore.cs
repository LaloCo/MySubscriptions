using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foundation;
using MySubscriptions.Model;
using MySubscriptions.ViewModel.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(MySubscriptions.iOS.Dependencies.Firestore))]
namespace MySubscriptions.iOS.Dependencies
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
                var keys = new[]
                {
                new NSString("author"),
                new NSString("name"),
                new NSString("isActive"),
                new NSString("subscribedDate"),
            };

                var values = new NSObject[]
                {
                new NSString(Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid),
                new NSString(subscription.Name),
                new NSNumber(subscription.IsActive),
                DateTimeToNSDate(subscription.SubscribedDate)
                };

                var subscriptionDocument = new NSDictionary<NSString, NSObject>(keys, values);
                Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("subscriptions").AddDocument(subscriptionDocument);
                return true;
            }
            catch(Exception ex)
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

        private static NSDate DateTimeToNSDate(DateTime date)
        {
            if (date.Kind == DateTimeKind.Unspecified)
                date = DateTime.SpecifyKind(date, DateTimeKind.Local);
            return (NSDate)date;
        }
    }
}
