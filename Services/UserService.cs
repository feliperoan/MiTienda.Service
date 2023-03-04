using miTienda.Interfaces;
using miTienda.Models;

namespace miTienda.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task<User> FindByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindById(string id)
        {
            var result = await userRepository.GetByIdAsync(id);
            return result;
        }

        public async Task<User> InsertAsync(User entity)
        {
            var idGnerated = Guid.NewGuid().ToString();
            entity.Id= idGnerated;
            var result = await userRepository.InsertAsync(entity);
            return result;
        }
    }
}
