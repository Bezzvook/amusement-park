using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmusementPark.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Link { get; set; }
        public string Email { get; set; }

        public List<Booking> Bookings { get; set; }
    }
}
