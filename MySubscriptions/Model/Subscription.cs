using System;
namespace MySubscriptions.Model
{
    public class Subscription
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime SubscribedDate { get; set; }
        public bool IsActive { get; set; }

        public Subscription()
        {
        }
    }
}
