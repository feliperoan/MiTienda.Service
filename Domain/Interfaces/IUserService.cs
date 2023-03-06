using miTienda.Domain.Models;

namespace miTienda.Domain.Interfaces
{
    public interface IUserService
    {
        public Task<User> InsertAsync(User entity);
        public Task<User> FindById(string id);
        public Task<List<User>> GetAllUsers();
        public Task<User> FindByEmail(string email);

    }
}
