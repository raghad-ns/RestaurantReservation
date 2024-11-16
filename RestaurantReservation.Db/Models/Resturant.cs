namespace RestaurantReservation.Db.Models;

public class Resturant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public int OpeningHours { get; set; }
}