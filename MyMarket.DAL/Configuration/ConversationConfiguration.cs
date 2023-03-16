using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMarket.DAL.Models.Messages;

namespace MyMarket.DAL.Configuration
{
    public class ConversationConfiguration : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            builder.HasKey(c => new { c.User1Id, c.User2Id });

            builder
                .HasMany(c => c.Messages)
                .WithOne(m => m.Conversation)
                .HasForeignKey(m => new { m.SenderId, m.RecipientId });

            builder
                .HasOne(c => c.User1)
                .WithMany(u => u.Conversations)
                .HasForeignKey(c => c.User1Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(c => c.User2)
                .WithMany(u => u.Conversations)
                .HasForeignKey(c => c.User2Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
