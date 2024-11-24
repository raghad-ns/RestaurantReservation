using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;

namespace RestaurantReservation.Reservation;

public class ReservationRepository
{
    private readonly RestaurantReservationDbContext _db;

    public ReservationRepository(RestaurantReservationDbContext db)
    {
        _db = db;
    }

    public async Task<int> AddReservation(Db.Models.Reservation reservation)
    {
        _db.Reservation.Add(reservation);
        await _db.SaveChangesAsync();
        return reservation.Id;
    }

    public async Task DeleteReservation(Db.Models.Reservation reservation)
    {
        _db.Reservation.Remove(reservation);
        await _db.SaveChangesAsync();
    }

    public async Task<Db.Models.Reservation> UpdateReservation(Db.Models.Reservation newReservation)
    {
        _db.Reservation.Update(newReservation);
        await _db.SaveChangesAsync();
        return newReservation;
    }

    public Task<List<Db.Models.Reservation>> GetReservationsByCustomer(int customerId)
    {
        return _db.Reservation
            .Where(reservation => reservation.CustomerId == customerId)
            .ToListAsync();
    }
}