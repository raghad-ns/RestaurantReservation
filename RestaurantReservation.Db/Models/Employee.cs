using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models;

[EntityTypeConfiguration(typeof(EmployeeEntityTypeConfiguration))]
public class Employee
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configures as an identity columns
    public int Id { get; set; }
    public Restaurant Restaurant { get; set; } // Navigation property
    public int RestaurantId { get; set; } // Foreign key
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public ICollection<Order> Orders { get; set; }

    public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .ToTable("Employee");
            builder
                .HasMany(e => e.Orders)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.EmployeeId)
                .IsRequired();
        }
    }
}