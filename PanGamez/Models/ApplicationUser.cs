﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace PanGamez.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = "DefaultFirstName";

        public string LastName { get; set; } = "DefaultLastName";

    }
}
