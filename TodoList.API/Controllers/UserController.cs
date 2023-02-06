using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoList.API.Repositories;

namespace TodoList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller    
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlTodosAsync()
        {
            var users = await userRepository.GetAllAsync();
            var res = mapper.Map<List<Models.DTO.User>>(users);

            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodoAsync(Models.DTO.AddUserRequest addUserRequest)
        {
            // Request(DTO) to Domain modal
            var user = new Models.Domain.User()
            {
                Username = addUserRequest.Username,
            };

            // pass details to Reposetory
            user = await userRepository.RegisterUserAsync(user);

            // Convert back to DTO
            var res = new Models.DTO.User()
            {
                Username = user.Username,
            };

            return Ok(user);
        }



    }
}
