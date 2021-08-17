using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BlazorLets.Shared.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }

        [PersonalData]
        public DateTime BirthDate { get; set; }

        [PersonalData]
        public byte[] Image { get; set; }

        [PersonalData]
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
