using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MissionTrackingSystem.Application.Repositories;
using MissionTrackingSystem.Application.ViewModels.Users;
using MissionTrackingSystem.Domain.Entities;
using System.Net;

namespace MissionTrackingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly private IUserWriteRepository _userWriteRepository;
        readonly private IUserReadRepository _userReadRepository;
        public UsersController(IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository)
        {
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_userReadRepository.GetAll(false).Select(p => new
            {
                p.Name,
                p.SurName,
                p.PhoneNumber,
                p.Id,
                p.Birthday,
                p.DepartmentId,
                p.CreatedDate,
                p.UpdatedDate,

            }));

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            //    Department department = await _departmentReadRepository.GetByIdAsync(id);
            return Ok(await _userReadRepository.GetByIdAsync(id, false));
        }
        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_User model)
        {

            await _userWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                SurName = model.SurName,
                PhoneNumber=model.PhoneNumber,
                Birthday=model.Birthday,
                DepartmentId=model.DepartmentId,

            });
            await _userWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);

        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_User model)
        {

            User user = await _userReadRepository.GetByIdAsync(model.Id);
            user.Name = model.Name;
            user.SurName = model.SurName;
            user.PhoneNumber = model.PhoneNumber;
            user.Birthday = model.Birthday;
            user.DepartmentId = model.DepartmentId;
            await _userWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _userWriteRepository.RemoveAsync(id);
            await _userWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
