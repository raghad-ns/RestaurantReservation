﻿namespace RestaurantReservation.Db.Repositories.Reservation;

public interface IReservationRepository
{
    Task<int> AddReservation(Models.Reservation reservation);

    Task DeleteReservation(Models.Reservation reservation);

    Task<Models.Reservation> UpdateReservation(Models.Reservation newReservation);
}