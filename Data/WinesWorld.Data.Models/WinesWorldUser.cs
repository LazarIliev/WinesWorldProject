using Microsoft.AspNetCore.Identity;
using System;

namespace WinesWorld.Data.Models
{
    public class WinesWorldUser : IdentityUser
    {
        public WinesWorldUser()
        {
           
        }

        public string FullName { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
