using Microsoft.AspNetCore.Mvc;
using miTienda.Interfaces;
using miTienda.Models;
using miTienda.Services;

namespace miTienda.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public  static List<User> users = new List<User>();
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService= userService;
        }
        [HttpGet(Name = "getuserlist")]
        public List<User> GetUsers()
        {
            return users; // Consulta en tabla user
        }
        [HttpPost]
        public async Task<User> CreateUser(User user) {
            var result = await userService.InsertAsync(user);
            users.Add(user); // Inserción en tabla user
            return user;
        }
    }
}
