using MongoDB.Driver;

namespace miTienda.Domain.Interfaces
{
    public interface IMongoDbContext
    {
        IMongoCollection<TEntity> GetCollection<TEntity>(string collectionName);
    }
}
