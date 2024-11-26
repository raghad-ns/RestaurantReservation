using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models;

[EntityTypeConfiguration(typeof(OrderItemEntityTypeConfiguration))]
public class OrderItem
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configures as an identity column
    public int Id { get; set; }
    public Order Order { get; set; }
    public int OrderId { get; set; }
    public MenuItem MenuItem { get; set; } // Navigation property
    public int MenuItemId { get; set; } // Foreign key
    public int Quantity { get; set; }

    public class OrderItemEntityTypeConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder
                .ToTable("OrderItem");
        }
    }
}