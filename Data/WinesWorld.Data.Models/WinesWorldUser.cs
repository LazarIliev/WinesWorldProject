using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace WinesWorld.Data.Models
{
    public class WinesWorldUser : IdentityUser
    {
        public WinesWorldUser()
        {
            this.Orders = new List<Order>();
        }

        public string FullName { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<Order> Orders { get; set; }
    }
}
