using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Models;

namespace Store.Data.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Image)
                .WithOne(x => x.Item)
                .HasForeignKey<Item>(x => x.ImageId);
            builder.HasMany(x => x.Categories)
                .WithMany(x => x.Items);
            builder.Property(x => x.Price).HasPrecision(20);
        }
    }
}
