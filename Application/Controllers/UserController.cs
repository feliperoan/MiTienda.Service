using Microsoft.AspNetCore.Mvc;
using miTienda.Domain.Interfaces;
using miTienda.Domain.Models;

namespace miTienda.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService= userService;

        }
        [HttpGet("~/GetUsers")]
        public async Task<List<User>> GetUsers()
        {
            var listUsers = await  userService.GetAllUsers();
            return listUsers; 
        }
        [HttpPost]
        public async Task<User> CreateUser(User user) {
            var result = await userService.InsertAsync(user);
            return user;
        }
        [HttpGet("~/GetUserByID")]
        public async Task<User> GetUserByID(string id)
        {
            var result = await userService.FindById(id); 
            return result; 
        }
        [HttpGet("~/GetUserByEmail")]
        public async Task<User> GetUserByEmail(string email)
        {
            var result = await userService.FindByEmail(email); 
            return result; 
        }
        [HttpDelete("~/DeleteById")]
        public async Task<User> DeleteById(string id)
        {
            var result = await userService.FindById(id); 
            return result; 
        }
    }
}
