using MyMarket.DAL.Models.Account;

namespace MyMarket.DAL.Models.Messages
{
    public class Conversation
    {
        public string User1Id { get; set; }
        public virtual User User1 { get; set; }
        public string User2Id { get; set; }
        public virtual User User2 { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
