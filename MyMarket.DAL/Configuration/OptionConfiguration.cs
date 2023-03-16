using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMarket.DAL.Models.Listings;

namespace MyMarket.DAL.Configuration
{
    public class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.HasKey(o => o.Id);

            builder
                .HasOne(o => o.Property)
                .WithMany(p => p.Options)
                .HasForeignKey(o => o.PropertyId);

            builder
                .HasOne(o => o.Category)
                .WithMany(c => c.Options)
                .HasForeignKey(o => o.CategoryId);

            builder
                .HasOne(o => o.Listing)
                .WithMany(l => l.Options)
                .HasForeignKey(o => o.ListingId);
        }
    }
}
