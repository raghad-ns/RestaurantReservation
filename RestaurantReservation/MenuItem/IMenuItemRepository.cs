using RestaurantReservation.Db;

namespace RestaurantReservation.MenuItem;

public interface IMenuItemRepository
{

    Task<int> AddMenuItem(Db.Models.MenuItem menuItem);

    Task DeleteMenuItem(Db.Models.MenuItem menuItem);

    Task<Db.Models.MenuItem> UpdateMenuItem(Db.Models.MenuItem newMenuItem);
}