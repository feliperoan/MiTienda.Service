using miTienda.Interfaces;
using miTienda.Models;
using MongoDB.Driver;
using System.Xml;

namespace miTienda.Infrastructure
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

        public Task DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByEmailAsync(string product)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdAsync(string id )
        {
            var filter = Builders<User>.Filter.Eq( "_id", id );
            var result = await _collection.FindAsync(filter);
            return result.First();
        }

        public Task<User> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        

        public Task<User> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
