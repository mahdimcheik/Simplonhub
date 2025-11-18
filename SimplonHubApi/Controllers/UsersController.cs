using SimplonHubApi.Models;
using SimplonHubApi.Services;
using Microsoft.AspNetCore.Mvc;
using SimplonHubApi.Services;

namespace SimplonHubApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController(UsersService usersService, SchedulerService schedulerService) : ControllerBase
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
    }
}
