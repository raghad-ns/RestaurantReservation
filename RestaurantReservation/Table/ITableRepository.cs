namespace RestaurantReservation.Table;

public interface ITableRepository
{
    Task<int> AddTable(Db.Models.Table table);

    Task DeleteTable(Db.Models.Table table);

    Task<Db.Models.Table> UpdateTable(Db.Models.Table newTable);
}