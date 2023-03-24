using Microsoft.AspNetCore.Identity;
using MyMarket.DAL.Models.Listings;

namespace MyMarket.DAL.Models.Account
{
    public class User : IdentityUser
    {
        public virtual ICollection<Listing> Listings { get; set; }
    }
}
