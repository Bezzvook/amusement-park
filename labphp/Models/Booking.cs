using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmusementPark.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BookingDate { get; set; }
        public int AdultTickets { get; set; }
        public int ChildTickets { get; set; }
        public bool Checked { get; set; }
        public bool Accepted { get; set; }

        public Subscription Subscription { get; set; }
        public int SubscriptionId { get; set; }

        public Client Client { get; set; }
        public int ClientId { get; set; }
    }
}
