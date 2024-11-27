namespace RestaurantReservation.Restaurant;

public interface IRestaurantRepository
{
    Task<int> AddRestaurant(Db.Models.Restaurant restaurant);

    Task DeleteRestaurant(Db.Models.Restaurant restaurant);

    Task<Db.Models.Restaurant> UpdateRestaurant(Db.Models.Restaurant newRestaurant);
}