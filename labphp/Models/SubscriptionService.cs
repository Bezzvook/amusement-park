using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmusementPark.Models
{
    public class SubscriptionService
    {
        public int Id { get; set; }

        public Subscription Subscription { get; set; }
        public int SubscriptionId { get; set; }

        public Service Service { get; set; }
        public int ServiceId { get; set; }
    }
}
