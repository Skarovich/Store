using Microsoft.EntityFrameworkCore;
using Store.Data.Interfaces;
using Store.Models;
using System.Reflection;

namespace Store.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemImage> Images { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Category>().HasData(new[]
            {
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Дом"
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Кухня"
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Ванна"
                }
            });
            modelBuilder.Entity<ItemImage>().HasData(new[]
            {
                new ItemImage
                {
                    Id = Guid.Parse("D6C1DAF5-AE57-41DF-8682-085DFCFD4DAB"),
                    Extenstion = "jpg"
                }
            });
        }
    }
}
