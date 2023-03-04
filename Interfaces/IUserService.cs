using miTienda.Models;

namespace miTienda.Interfaces
{
    public interface IUserService
    {
        public Task<User> InsertAsync(User entity);
        public Task<User> FindById(string id);
        public Task<User> FindByEmail(string email);

    }
}
