using miTienda.Models;

namespace miTienda.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> InsertAsync(User entity);
        public Task<User> UpdateAsync(User entity);
        public Task DeleteAsync(User entity);
        public Task<User> GetByIdAsync(string id);
        public Task<User> GetByNameAsync(string name);
        public Task<User> GetByEmailAsync(string product);
    }
}
