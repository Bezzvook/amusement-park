using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmusementPark.Models
{
    public class StaticData
    {
        public static List<SelectListItem> names = new List<SelectListItem>();
        public static List<Attraction> Attractions = new List<Attraction>();
        public static List<Service> Services = new List<Service>();
    }
}
