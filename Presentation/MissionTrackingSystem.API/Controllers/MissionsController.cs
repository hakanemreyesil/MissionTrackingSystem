using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MissionTrackingSystem.Application.Repositories;
using MissionTrackingSystem.Application.ViewModels.Missions;
using MissionTrackingSystem.Domain.Entities;
using System.Net;

namespace MissionTrackingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class MissionsController : ControllerBase
    {
        readonly private IMissionWriteRepository _missionWriteRepository;
        readonly private IMissionReadRepository _missionReadRepository;
        public MissionsController(IMissionWriteRepository missionWriteRepository, IMissionReadRepository missionReadRepository)
        {
            _missionWriteRepository = missionWriteRepository;
            _missionReadRepository = missionReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_missionReadRepository.GetAll(false).Select(p => new
            { 
                p.Id,
                p.Content,
                p.CreatedDate,
                p.UpdatedDate,
                p.IsCompleted,

            }));

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            //    Department department = await _departmentReadRepository.GetByIdAsync(id);
            return Ok(await _missionReadRepository.GetByIdAsync(id, false));
        }
        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Mission model)
        {

            await _missionWriteRepository.AddAsync(new()
            {
                Content = model.Content,
                IsCompleted = model.IsCompleted,    

            });
            await _missionWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);

        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Mission model)
        {

            Mission mission = await _missionReadRepository.GetByIdAsync(model.Id);
            mission.Content = model.Content;
            mission.IsCompleted = model.IsCompleted;    
            await _missionWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _missionWriteRepository.RemoveAsync(id);
            await _missionWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
