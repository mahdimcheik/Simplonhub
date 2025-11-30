using SimplonHubApi.Models;
using SimplonHubApi.Services;
using Microsoft.AspNetCore.Mvc;
using SimplonHubApi.Services;

namespace SimplonHubApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController(UsersService usersService, SchedulerService schedulerService, DocumentService documentService) : ControllerBase
    {
        [HttpPost("list")]
        public async Task<ActionResult<ResponseDTO<List<UserResponseDTO>>>> GetAllUsers([FromBody] DynamicFilters<UserApp> tableState)
        {
            var users = await usersService.GetUsers(tableState);
            return Ok(users);
        }

        [HttpPost("list-teachers")]
        public async Task<ActionResult<ResponseDTO<List<TeacherResponseDTO>>>> GetAllTeachers([FromBody] DynamicFilters<UserApp> tableState)
        {
            var users = await usersService.GetTeachers(tableState, User);
            return Ok(users);
        }
        [HttpPost("list-candidats")]
        public async Task<ActionResult<ResponseDTO<List<TeacherResponseDTO>>>> GetAllCandidats([FromBody] DynamicFilters<UserApp> tableState)
        {
            var users = await usersService.GetCandidats(tableState);
            return Ok(users);
        }

        [HttpPost("add-document")]
        [Consumes("multipart/form-data")]
        [Produces("application/json")]
        public async Task<IActionResult> AddDocument([FromForm] DocumentInfo request
        )
        {
            await documentService.AddFile(request.File, request, User);
            return Ok();
        }
    }
}
