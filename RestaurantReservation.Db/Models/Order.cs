namespace RestaurantReservation.Db.Models;

public class Order
{
    public int Id { get; set; }
    public Reservation Reservation { get; set; } // Navigation property
    public int ReservationId { get; set; } // Foreign key
    public Employee Employee { get; set; } // Navigation property
    public int EmployeeId { get; set; } // Foreign key
    public DateTime OrderDate { get; set; }
    public double TotalAmount { get; set; }
}