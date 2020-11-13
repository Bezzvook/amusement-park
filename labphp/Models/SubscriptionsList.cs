using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmusementPark.Models
{
    public class SubscriptionsList
    {
        public Subscription Subscription { get; set; }

        public List<Attraction> Attractions { get; set; }
        public List<Service> Services { get; set; }
    }
}