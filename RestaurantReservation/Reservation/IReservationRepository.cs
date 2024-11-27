namespace RestaurantReservation.Reservation;

public interface IReservationRepository
{
    Task<int> AddReservation(Db.Models.Reservation reservation);

    Task DeleteReservation(Db.Models.Reservation reservation);

    Task<Db.Models.Reservation> UpdateReservation(Db.Models.Reservation newReservation);
}