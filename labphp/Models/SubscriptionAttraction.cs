using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmusementPark.Models
{
    public class SubscriptionAttraction
    {
        public Subscription Subscription { get; set; }
        public int SubscriptionId { get; set; }

        public Attraction Attraction { get; set; }
        public int AttractionId { get; set; }
    }
}
