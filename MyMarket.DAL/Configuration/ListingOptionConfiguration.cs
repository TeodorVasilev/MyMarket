using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMarket.DAL.Models.Listings;

namespace MyMarket.DAL.Configuration
{
    public class ListingOptionConfiguration : IEntityTypeConfiguration<ListingOption>
    {
        public void Configure(EntityTypeBuilder<ListingOption> builder)
        {
            builder.HasKey(lo => new {lo.ListingId, lo.OptionId});

            builder
                .HasOne(lo => lo.Option)
                .WithMany(o => o.ListingOptions)
                .HasForeignKey(lo => lo.OptionId);

            builder
                .HasOne(lo => lo.Listing)
                .WithMany(l => l.ListingOptions)
                .HasForeignKey(lo => lo.ListingId);
        }
    }
}
