﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace massive_infinity.Data.Entities
{
    public class Company
    {
        [Key]
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Logo { get; set; }

        public string Website_URL { get; set; }
    }
}
