using miTienda.Interfaces;
using miTienda.Models;
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

        public Task<User> GetByEmailAsync(string email)
        {
            var filter = Builders<User>.Filter.Eq("Email", email);
            return _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            var filter = Builders<User>.Filter.Eq("_id", id);
            var result = await _collection.Find(filter).FirstOrDefaultAsync();
            return result;
        }

        public Task<User> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
        public async Task<User> UpdateAsync(User entity)
        {
            var updated = await _collection.ReplaceOneAsync(user => user.Id == entity.Id, entity);
            return entity;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var filter = Builders<User>.Filter.Empty;
            var result = await _collection.Find(filter).ToListAsync();
            return result;
        }
    }
}
