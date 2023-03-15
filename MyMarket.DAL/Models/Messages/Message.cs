using MyMarket.DAL.Models.Account;

namespace MyMarket.DAL.Models.Messages
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime SendAt { get; set; }
        public bool IsRead { get; set; }
        public string SenderId { get; set; }
        public virtual User Sender { get; set; }
        public string RecipientId { get; set; }
        public virtual User Recipient { get; set; }
    }
}
