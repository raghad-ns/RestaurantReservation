using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

namespace RestaurantReservation.Db.Models;

[EntityTypeConfiguration(typeof(TableEntityTypeConfiguration))]
public class Table
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configures as an identity column
    public int Id { get; set; }
    public Restaurant Restaurant { get; set; } // Navigation property
    public int RestaurantId { get; set; } // Foreign key
    public int Capacity { get; set; }
    public ICollection<Reservation> Reservations { get; set; }

    public class TableEntityTypeConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder
                .HasMany(e => e.Reservations)
                .WithOne(e => e.Table)
                .HasForeignKey(e => e.TableId)
                .IsRequired();
        }
    }
}