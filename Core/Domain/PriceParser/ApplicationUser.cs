using Microsoft.AspNetCore.Identity;

namespace PriceParser
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsAdult { get; set; }
    }
}
