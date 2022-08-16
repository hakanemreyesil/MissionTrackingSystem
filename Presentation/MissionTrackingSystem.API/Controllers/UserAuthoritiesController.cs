using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MissionTrackingSystem.Application.Repositories;
using MissionTrackingSystem.Application.ViewModels.UserAuthorities;
using MissionTrackingSystem.Domain.Entities;
using System.Net;

namespace MissionTrackingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthoritiesController : ControllerBase
    {
        readonly private IUserAuthorityWriteRepository _userAuthorityWriteRepository;
        readonly private IUserAuthorityReadRepository _userAuthorityReadRepository;
        public UserAuthoritiesController(IUserAuthorityWriteRepository userAuthorityWriteRepository, IUserAuthorityReadRepository userAuthorityReadRepository)
        {
            _userAuthorityWriteRepository = userAuthorityWriteRepository;
            _userAuthorityReadRepository = userAuthorityReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_userAuthorityReadRepository.GetAll(false).Select(p => new
            {
                p.UserId,
                p.AuthorityId,
                p.Id,
                p.CreatedDate,
                p.UpdatedDate,

            }));

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            //    Department department = await _departmentReadRepository.GetByIdAsync(id);
            return Ok(await _userAuthorityReadRepository.GetByIdAsync(id, false));
        }
        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_UserAuthority model)
        {

            await _userAuthorityWriteRepository.AddAsync(new()
            {
                 UserId = model.UserId,
                 AuthorityId = model.AuthorityId,

            });
            await _userAuthorityWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);

        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_UserAuthority model)
        {

            UserAuthority  userAuthority = await _userAuthorityReadRepository.GetByIdAsync(model.Id);
            userAuthority.AuthorityId = model.AuthorityId;
            userAuthority.UserId = model.UserId;
            await _userAuthorityWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _userAuthorityWriteRepository.RemoveAsync(id);
            await _userAuthorityWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
