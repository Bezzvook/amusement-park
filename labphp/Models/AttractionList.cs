using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmusementPark.Models
{
    public class AttractionList
    {
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public int AttractionId { get; set; }
    }
}
