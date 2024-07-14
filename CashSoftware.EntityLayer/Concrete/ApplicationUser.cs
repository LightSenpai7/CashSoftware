using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashSoftware.EntityLayer.Concrete
{
    public class ApplicationUser: IdentityUser<int>
    {
        public string NameSurname { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
    }
}
