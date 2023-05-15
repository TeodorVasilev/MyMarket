using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMarket.DAL.Models.Listings;

namespace MyMarket.DAL.Configuration
{
    public class PropertyOptionConfiguration : IEntityTypeConfiguration<PropertyOption>
    {
        public void Configure(EntityTypeBuilder<PropertyOption> builder)
        {
            builder.HasKey(po => new {po.PropertyId, po.OptionId});

            builder
                .HasOne(po => po.Property)
                .WithMany(p => p.PropertyOptions)
                .HasForeignKey(po => po.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(po => po.Option)
                .WithMany(o => o.PropertyOptions)
                .HasForeignKey(po => po.OptionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
