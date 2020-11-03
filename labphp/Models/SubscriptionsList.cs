using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmusementPark.Models
{
    public class SubscriptionsList
    {
        public Subscriptions Subscription { get; set; }
        public List<Attractions> attractions { get; set; }
        public List<Services> services { get; set; }
    }
}
