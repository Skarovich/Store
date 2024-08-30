using Microsoft.EntityFrameworkCore;
using Store.Models;

namespace Store.Data.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<Category> Categories { get; }
        public DbSet<Item> Items { get; }
        public DbSet<ItemImage> Images { get; }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class;

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
