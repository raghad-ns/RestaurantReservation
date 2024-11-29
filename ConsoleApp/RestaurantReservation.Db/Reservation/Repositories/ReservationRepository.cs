using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db.Reservation.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly RestaurantReservationDbContext _db;

    public ReservationRepository(RestaurantReservationDbContext db)
    {
        _db = db;
    }

    public async Task<int> AddReservation(Models.Reservation reservation)
    {
        _db.Reservation.Add(reservation);
        await _db.SaveChangesAsync();
        return reservation.Id;
    }

    public async Task DeleteReservation(Models.Reservation reservation)
    {
        _db.Reservation.Remove(reservation);
        await _db.SaveChangesAsync();
    }

    public async Task<Models.Reservation> UpdateReservation(Models.Reservation newReservation)
    {
        _db.Reservation.Update(newReservation);
        await _db.SaveChangesAsync();
        return newReservation;
    }

    public Task<List<Models.Reservation>> GetReservationsByCustomer(int customerId)
    {
        return _db.Reservation
            .Where(reservation => reservation.CustomerId == customerId)
            .ToListAsync();
    }
}