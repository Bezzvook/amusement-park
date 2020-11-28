using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmusementPark.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BookingDate { get; set; }
        public int AdultTickets { get; set; }
        public int ChildTickets { get; set; }

        public Status Status { get; set; }

        public Subscription Subscription { get; set; }
        public int SubscriptionId { get; set; }

        public Client Client { get; set; }
        public int ClientId { get; set; }
    }

    public enum Status
    {
        [Display(Name = "Ожидает подтверждения")]
        Submitted,
        [Display(Name = "Подтверждено")]
        Approved,
        [Display(Name = "Отменено")]
        Rejected
    }
}
