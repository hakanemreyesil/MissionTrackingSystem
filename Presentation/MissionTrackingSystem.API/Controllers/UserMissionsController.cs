using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MissionTrackingSystem.Application.Repositories;
using MissionTrackingSystem.Application.ViewModels.UserMissions;
using MissionTrackingSystem.Domain.Entities;
using System.Net;

namespace MissionTrackingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMissionsController : ControllerBase
    {
        readonly private IUserMissionWriteRepository _userMissionWriteRepository;
        readonly private IUserMissionReadRepository _userMissionReadRepository;
        public UserMissionsController(IUserMissionWriteRepository userMissionWriteRepository, IUserMissionReadRepository userMissionReadRepository)
        {
            _userMissionWriteRepository = userMissionWriteRepository;
            _userMissionReadRepository = userMissionReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_userMissionReadRepository.GetAll(false).Select(p => new
            {
                p.UserId,
                p.MissionId,
                p.Id,
                p.CreatedDate,
                p.UpdatedDate,

            }));

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            //    Department department = await _departmentReadRepository.GetByIdAsync(id);
            return Ok(await _userMissionReadRepository.GetByIdAsync(id, false));
        }
        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_UserMission model)
        {

            await _userMissionWriteRepository.AddAsync(new()
            {
                UserId = model.UserId,
                MissionId = model.MissionId,

            });
            await _userMissionWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);

        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_UserMission model)
        {

            UserMission userMission = await _userMissionReadRepository.GetByIdAsync(model.Id);
            userMission.MissionId = model.MissionId;
            userMission.UserId = model.UserId;
            await _userMissionWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _userMissionWriteRepository.RemoveAsync(id);
            await _userMissionWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
