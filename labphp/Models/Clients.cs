﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmusementPark.Models
{
    public class Clients
    {
        [Key]
        public string PhoneNumber { get; set; }
        public string Link { get; set; }
    }
}
