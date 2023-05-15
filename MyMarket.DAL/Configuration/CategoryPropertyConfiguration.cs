using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMarket.DAL.Models.Listings;

namespace MyMarket.DAL.Configuration
{
    public class CategoryPropertyConfiguration : IEntityTypeConfiguration<CategoryProperty>
    {
        public void Configure(EntityTypeBuilder<CategoryProperty> builder)
        {
            builder.HasKey(po => new { po.PropertyId, po.CategoryId });

            builder
                .HasOne(cp => cp.Category)
                .WithMany(c => c.CategoryProperties)
                .HasForeignKey(cp => cp.CategoryId);

            builder
                .HasOne(cp => cp.Property)
                .WithMany(p => p.CategoryProperties)
                .HasForeignKey(cp => cp.PropertyId);
        }
    }
}
