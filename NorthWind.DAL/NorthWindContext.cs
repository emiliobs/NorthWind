namespace NorthWind.DAL
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
    using NorthWind.Entities;
    using NorthWind.Helpers;
    public class NorthWindContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Log> Logs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = HelperConfiguration.GetAppConfiguration().ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Property(c => c.CategoryName).HasMaxLength(15).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.ProductName).HasMaxLength(40).IsRequired();
            modelBuilder.Entity<Log>(l =>
            {
                l.Property(log => log.DateTime).HasDefaultValueSql("getData()");
                l.Property(log => log.Type).HasConversion(new EnumToStringConverter<LogType>()).HasMaxLength(20);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
