﻿using Microsoft.AspNetCore.Identity;

namespace Users.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
    }
}