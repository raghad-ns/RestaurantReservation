namespace RestaurantReservation.Db.Repositories.MenuItem;

public interface IMenuItemRepository
{

    Task<int> AddMenuItem(Models.MenuItem menuItem);

    Task DeleteMenuItem(Models.MenuItem menuItem);

    Task<Models.MenuItem> UpdateMenuItem(Models.MenuItem newMenuItem);
}