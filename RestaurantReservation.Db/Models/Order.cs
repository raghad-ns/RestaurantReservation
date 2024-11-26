using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models;

[EntityTypeConfiguration(typeof(OrderEntityTypeConfiguration))]
public class Order
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configures as an identity column
    public int Id { get; set; }
    public Reservation Reservation { get; set; } // Navigation property
    public int ReservationId { get; set; } // Foreign key
    public Employee Employee { get; set; } // Navigation property
    public int EmployeeId { get; set; } // Foreign key
    public DateTime OrderDate { get; set; }
    public double TotalAmount { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }

    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .ToTable("Order");
            builder
                .HasMany(e => e.OrderItems)
                .WithOne(e => e.Order)
                .HasForeignKey(e => e.OrderId)
                .IsRequired(); ;
        }
    }
}