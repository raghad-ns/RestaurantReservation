namespace RestaurantReservation.Db.Repositories.Restaurant;

public interface IRestaurantRepository
{
    Task<int> AddRestaurant(Models.Restaurant restaurant);

    Task DeleteRestaurant(Models.Restaurant restaurant);

    Task<Models.Restaurant> UpdateRestaurant(Models.Restaurant newRestaurant);
}