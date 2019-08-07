using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace WinesWorld.Services.Models
{
    public class WinesWorldUserServiceModel : IdentityUser
    {
        public string FullName { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<OrderServiceModel> Orders { get; set; }
    }
}