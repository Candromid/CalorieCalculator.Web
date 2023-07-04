using CaloriesCalculator.WebAdmin.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CaloriesCalculator.WebAdmin.Domain
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>(ConfigureProducts);
        }

        private void ConfigureProducts(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
            .IsRequired()
             .HasMaxLength(100);

            builder.Property(x => x.Proteins);

            builder.Property(x => x.Fats);

            builder.Property(x => x.Carbohydrates);

        }

    }
}
