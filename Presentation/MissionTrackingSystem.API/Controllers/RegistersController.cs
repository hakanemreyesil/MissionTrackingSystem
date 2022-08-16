using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MissionTrackingSystem.Application.Features.Commands.AppUser.CreateUser;
using MissionTrackingSystem.Application.Features.Commands.AppUser.LoginUser;

namespace MissionTrackingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        readonly IMediator _madiator;

        public RegistersController(IMediator madiator)
        {
            _madiator = madiator;
        }
        [HttpPost]
        public async Task <IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _madiator.Send(createUserCommandRequest);
            return Ok(response) ;

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserCommandResponse response = await _madiator.Send(loginUserCommandRequest);
            return Ok(response);
        }
     
    }
}
