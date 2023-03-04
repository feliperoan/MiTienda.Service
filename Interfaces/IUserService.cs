using miTienda.Models;

namespace miTienda.Interfaces
{
    public interface IUserService
    {
        public Task<User> InsertAsync(User entity);
    }
}
