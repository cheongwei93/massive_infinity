using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace massive_infinity.Models
{
    public class CompanyModel
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public IFormFile LogoPath { get; set; }

        public string Website_URL { get; set; }

        public string FileName { get; set; }

    }
}
