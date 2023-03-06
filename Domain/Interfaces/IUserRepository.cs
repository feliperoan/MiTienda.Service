using miTienda.Domain.Models;


namespace miTienda.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> InsertAsync(User entity);
        public Task<User> UpdateAsync(User entity);
        public Task DeleteAsync(string id);

    }
}
