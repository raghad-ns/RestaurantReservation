namespace RestaurantReservation.Db.Table.Repositories;

public interface ITableRepository
{
    Task<int> AddTable(Models.Table table);

    Task DeleteTable(Models.Table table);

    Task<Models.Table> UpdateTable(Models.Table newTable);
}