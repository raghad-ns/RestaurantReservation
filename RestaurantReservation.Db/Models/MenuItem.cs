using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models;

[EntityTypeConfiguration(typeof(MenuItemEntityTypeConfiguration))]
public class MenuItem
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configures as an identity column
    public int Id { get; set; }
    public Restaurant Restaurant { get; set; } // Navigation property
    public int RestaurantId { get; set; } // Foreign key
    public string Name { get; set; }
    public string? Description { get; set; }
    public double price { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }

    public class MenuItemEntityTypeConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder
                .ToTable("MenuItem");
            builder
                .HasMany(e => e.OrderItems)
                .WithOne(e => e.MenuItem)
                .HasForeignKey(e => e.MenuItemId)
                .IsRequired();
        }
    }
}