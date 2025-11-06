using Microsoft.AspNetCore.Identity;

namespace FiveMotors.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Guid? ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
