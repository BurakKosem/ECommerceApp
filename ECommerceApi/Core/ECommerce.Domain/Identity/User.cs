using Microsoft.AspNetCore.Identity;

namespace ECommerce.Domain.Identity
{
    public class User : IdentityUser
    {
        public string? Initials { get; set; }
    }
}
