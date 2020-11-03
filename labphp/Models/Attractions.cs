using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmusementPark.Models
{
    public class Attractions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxFreeSeat { get; set; }
    }
}
