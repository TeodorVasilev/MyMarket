using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMarket.DAL.Models.Listings;

namespace MyMarket.DAL.Configuration
{
    public class StaticOptionConfiguration : IEntityTypeConfiguration<StaticOption>
    {
        public void Configure(EntityTypeBuilder<StaticOption> builder)
        {
            builder.HasKey(so => so.Id);

            builder.HasMany(so => so.Children)
                .WithOne(so => so.Parent)
                .HasForeignKey(so => so.ParentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
