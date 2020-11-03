using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmusementPark.Models
{
    public class Subscriptions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal ChildPrice { get; set; }
        public decimal AdultPrice { get; set; }
    }
}
