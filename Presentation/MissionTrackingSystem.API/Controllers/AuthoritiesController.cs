using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MissionTrackingSystem.Application.Repositories;
using MissionTrackingSystem.Application.ViewModels.Authorities;
using MissionTrackingSystem.Domain.Entities;
using System.Net;

namespace MissionTrackingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthoritiesController : ControllerBase
    {
        readonly private IAuthorityWriteRepository _authorityWriteRepository;
        readonly private IAuthorityReadRepository _authorityReadRepository;
        public AuthoritiesController(IAuthorityWriteRepository authorityWriteRepository, IAuthorityReadRepository authorityReadRepository)
        {
            _authorityWriteRepository = authorityWriteRepository;
            _authorityReadRepository = authorityReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_authorityReadRepository.GetAll(false).Select(p => new
            {
                p.AuthorityName,
                p.Id,
                p.CreatedDate,
                p.UpdatedDate,

            }));

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            //    Department department = await _departmentReadRepository.GetByIdAsync(id);
            return Ok(await _authorityReadRepository.GetByIdAsync(id, false));
        }
        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Authority model)
        {

            await _authorityWriteRepository.AddAsync(new()
            {
                AuthorityName = model.AuthorityName,

            });
            await _authorityWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);

        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Authority model)
        {

            Authority authority = await _authorityReadRepository.GetByIdAsync(model.Id);
            authority.AuthorityName= model.AuthorityName;
            await _authorityWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _authorityWriteRepository.RemoveAsync(id);
            await _authorityWriteRepository.SaveAsync();
            return Ok();
        }

    }
}

