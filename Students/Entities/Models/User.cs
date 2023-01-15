using Microsoft.AspNetCore.Identity;

namespace Students.Entities.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? LastLogin { get; set; }
    }
}
