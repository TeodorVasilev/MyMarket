using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyMarket.DAL.Configuration;
using MyMarket.DAL.Models.Account;
using MyMarket.DAL.Models.Images;
using MyMarket.DAL.Models.Listings;

namespace MyMarket.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<StaticOption> StaticOptions { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Server=.;Database=MyMarketDatabase;Trusted_Connection=True;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../MyMarket"))
        //            .AddJsonFile("appsettings.json")
        //            .Build();
        //        string connectionString = configuration.GetConnectionString("DefaultConnection");
        //        optionsBuilder.UseSqlServer(connectionString);
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Role>().HasData(
                new Role
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = "USER",
                },
                new Role
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                }
            );

            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ListingConfiguration());
            builder.ApplyConfiguration(new CategoryPropertyConfiguration());
            builder.ApplyConfiguration(new ListingOptionConfiguration());
            builder.ApplyConfiguration(new PropertyOptionConfiguration());
            builder.ApplyConfiguration(new StaticOptionConfiguration());
        }
    }
}