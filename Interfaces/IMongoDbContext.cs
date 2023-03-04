using MongoDB.Driver;

namespace miTienda.Interfaces
{
    public interface IMongoDbContext
    {
        IMongoCollection<TEntity> GetCollection<TEntity>(string collectionName);
    }
}
