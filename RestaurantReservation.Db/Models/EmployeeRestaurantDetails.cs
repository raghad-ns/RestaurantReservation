using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db.Models;

[EntityTypeConfiguration(typeof(EmployeeRestaurantDetailsEntityTypeConfiguration))]
public class EmployeeRestaurantDetails
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public string RestaurantName { get; set; }
    public string RestaurantAddress { get; set; }
    public string? RestaurantPhoneNumber { get; set; }

    public class EmployeeRestaurantDetailsEntityTypeConfiguration : IEntityTypeConfiguration<EmployeeRestaurantDetails>
    {
        public void Configure(EntityTypeBuilder<EmployeeRestaurantDetails> builder)
        {
            builder
                .ToView("EmployeeRestaurantDetails")
                .HasNoKey();
        }
    }
}