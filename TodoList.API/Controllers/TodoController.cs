using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.API.Repositories;

namespace TodoList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : Controller 
    {
        private readonly ITodoRepository todoRepository;
        private readonly IMapper mapper;

        public TodoController(ITodoRepository todoRepository, IMapper mapper)
        {
            this.todoRepository = todoRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        //[Authorize(Roles = "reader")]

        public async Task<IActionResult> GetAlTodosAsync()
        {
            var todos = await todoRepository.GetAllAsync();
            var res = mapper.Map<List<Models.DTO.Todo>>(todos); 

            return Ok(res);
        }

        [HttpGet]
        [Route("{id:guid}")]
        //[Authorize(Roles = "reader")]
        [ActionName("GetTodoByIdAsync")]
        public async Task<IActionResult> GetTodoByIdAsync(Guid id)
        {
            var todo = await todoRepository.GetTodoByIdAsync(id);

            if (todo == null)
            {
                return NotFound();
            }
            else
            {
                var res = mapper.Map<Models.DTO.Todo>(todo);
                return Ok(res);
            }


        }

        [HttpPost]
        //[Authorize(Roles = "writer")]

        public async Task<IActionResult> AddTodoAsync(Models.DTO.AddTodoRequest addTodoRequest)
        {
            // Request(DTO) to Domain modal
            var todo = new Models.Domain.Todo()
            {
                Title = addTodoRequest.Title,
                Content = addTodoRequest.Content,
                UserId = addTodoRequest.UserId,
                UrgencyId = addTodoRequest.UrgencyId,
            };

            // pass details to Reposetory
            todo = await todoRepository.AddTodoAsync(todo);

            // Convert back to DTO
            var res = new Models.DTO.Todo()
            {
                Title = todo.Title,
                Content = todo.Content,
                UserId = todo.UserId,
            };

            return CreatedAtAction(nameof(GetTodoByIdAsync), new { id = res.Id }, res);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        //[Authorize(Roles = "writer")]

        public async Task<IActionResult> DeleteTodoById(Guid id)
        {
            // Get Region from Db
            var todo = await todoRepository.DeleteTodoAsync(id);

            // if null NotFound
            if (todo == null)
            {
                return NotFound();
            }

            // Convert res to DTO
            var res = mapper.Map<Models.DTO.Todo>(todo);

            // Return Ok response
            return Ok(res);
        }

        [HttpPut]
        [Route("{id:guid}")]
        //[Authorize(Roles = "writer")]

        public async Task<IActionResult> UpdateTodoAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateTodoRequest updateTodoRequest)
        {
            // Convert DTO to Domain model
            var todo = new Models.Domain.Todo()
            {
                Title = updateTodoRequest.Title,
                Content = updateTodoRequest.Content,
                UserId = updateTodoRequest.UserId,
                UrgencyId = updateTodoRequest.UrgencyId,
            };

            // Update Region using reposetory
            todo = await todoRepository.UpdateTodoAsync(id, todo);

            // if null return NotFound
            if (todo == null)
            {
                return NotFound();
            }

            // Convert to DTO
            var res = mapper.Map<Models.DTO.Todo>(todo);

            // return Ok response
            return Ok(res);
        }
    }
}

