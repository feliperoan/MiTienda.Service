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

        public async Task<User> FindByEmail(string email)
        {
            var result = await userRepository.GetByEmailAsync(email);
            return result;
        }

        public async Task<User> FindById(string id)
        {
            var result = await userRepository.GetByIdAsync(id);
            return result;
        }

        public Task<List<User>> GetAllUsers()
        {
            return userRepository.GetAllUsers();
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
