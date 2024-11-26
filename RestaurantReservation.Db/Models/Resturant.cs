using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models;

[EntityTypeConfiguration(typeof(RestaurantEntityTypeConfiguration))]
public class Restaurant
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configures as an identity column
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string? PhoneNumber { get; set; }
    public int OpeningHours { get; set; }
    public ICollection<Employee> Employees { get; set; }
    public ICollection<Table> Tables { get; set; }
    public ICollection<MenuItem> MenuItems { get; set; }

    public class RestaurantEntityTypeConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder
                .ToTable("Restaurant");
            builder
                .HasMany(e => e.Tables)
                .WithOne(e => e.Restaurant)
                .HasForeignKey(e => e.RestaurantId)
                .IsRequired();

            builder
                .HasMany(e => e.Employees)
                .WithOne(e => e.Restaurant)
                .HasForeignKey(e => e.RestaurantId)
                .IsRequired();

            builder
                .HasMany(e => e.MenuItems)
                .WithOne(e => e.Restaurant)
                .HasForeignKey(e => e.RestaurantId)
                .IsRequired();
        }
    }
}