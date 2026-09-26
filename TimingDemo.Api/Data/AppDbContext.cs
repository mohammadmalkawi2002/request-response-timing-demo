using Microsoft.EntityFrameworkCore;
using TimingDemo.Api.Models;

namespace TimingDemo.Api.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) :DbContext(options)
    {
       public DbSet<Product> Products => Set<Product>();
       public DbSet<Category> Categories => Set<Category>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
