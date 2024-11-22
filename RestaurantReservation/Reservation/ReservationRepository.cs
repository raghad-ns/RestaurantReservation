using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;

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
        _db.Reservation.AddAsync(reservation);
        _db.SaveChangesAsync();
        return reservation.Id;
    }

    public async Task DeleteReservation(Db.Models.Reservation reservation)
    {
        _db.Reservation.Remove(reservation);
        _db.SaveChangesAsync();
    }

    public async Task<Db.Models.Reservation> UpdateReservation(int reservationId,Db.Models.Reservation newReservation)
    {
        var Reservation = await _db.Reservation.FindAsync(reservationId);
        Reservation = newReservation;
        _db.SaveChangesAsync();
        return Reservation;
    }

    public Task<List<Db.Models.Reservation>> GetReservationsByCustomer(int customerId)
    {
        return _db.Reservation.Where(reservation => reservation.CustomerId == customerId).ToListAsync();
    }
}