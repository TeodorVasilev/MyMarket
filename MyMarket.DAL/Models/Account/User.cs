using Microsoft.AspNetCore.Identity;
using MyMarket.DAL.Models.Listings;
using MyMarket.DAL.Models.Messages;

namespace MyMarket.DAL.Models.Account
{
    public class User : IdentityUser
    {
        public virtual ICollection<Listing> Listings { get; set; }
        public virtual ICollection<Conversation> Conversations { get; set; }
    }
}
