using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string FullAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
