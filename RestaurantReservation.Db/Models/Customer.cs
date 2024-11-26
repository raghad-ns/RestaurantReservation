using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace RestaurantReservation.Db.Models;

[EntityTypeConfiguration(typeof(CustomerEntityTypeConfiguration))]
public class Customer
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configures as an identity column
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public ICollection<Reservation> Reservations { get; set; }

    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .ToTable("Customer");
            builder
                .HasMany(e => e.Reservations)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.CustomerId);
        }
    }
}