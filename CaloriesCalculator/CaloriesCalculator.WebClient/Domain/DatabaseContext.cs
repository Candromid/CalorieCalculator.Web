using CaloriesCalculator.WebClient.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaloriesCalculator.WebClient.Domain
{
    public class DatabaseContext : DbContext
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

        //private void ConfigureMaster(EntityTypeBuilder<Master> builder)
        //{
        //    builder.ToTable("Masters");

        //    builder.HasKey(ci => ci.Id);

        //builder.Property(cb => cb.Name)
        //        .IsRequired()
        //        .HasMaxLength(100);

        //    builder.Property(cb => cb.MiddleName)
        //        .IsRequired()
        //        .HasMaxLength(100);

        //    builder.Property(cb => cb.Surname)
        //        .IsRequired()
        //        .HasMaxLength(100);
        //}

        //private void ConfigureWorkingDay(EntityTypeBuilder<WorkingDay> builder)
        //{
        //    builder.ToTable("WorkingDays");

        //    builder.HasKey(ci => ci.Id);

        //    builder.Property(cb => cb.MasterId)
        //        .IsRequired();

        //    builder.Property(cb => cb.WorkDay)
        //        .IsRequired();

        //    builder.HasOne(p => p.Master)
        //        .WithMany(t => t.WorkingDays)
        //        .HasForeignKey(p => p.MasterId);

        //}

    }
}
