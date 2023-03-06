using miTienda.Domain.Interfaces;
using miTienda.Domain.Models;
using MongoDB.Driver;
using System.Xml;

namespace miTienda.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IMongoDatabase _database = null;
        private readonly IMongoCollection<User> _collection;
        public UserRepository(IConfiguration configuration, IMongoDbContext context)
        {
            _collection = context.GetCollection<User>("User");
        }

        public async Task<User> InsertAsync(User entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public Task DeleteAsync(string id)
        {
            return _collection.FindOneAndDeleteAsync(user => user.Id == id);
        }

       
        public async Task<User> UpdateAsync(User entity)
        {
            var updated = await _collection.ReplaceOneAsync(user => user.Id == entity.Id, entity);
            return entity;
        }

        
    }
}
