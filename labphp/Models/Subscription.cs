using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmusementPark.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal ChildPrice { get; set; }
        public decimal AdultPrice { get; set; }

        public List<SubscriptionAttraction> SubscriptionAttractions { get; set; }
        public List<SubscriptionService> SubscriptionServices { get; set; }
    }
}
