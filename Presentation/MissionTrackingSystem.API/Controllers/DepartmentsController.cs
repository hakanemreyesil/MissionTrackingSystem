using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MissionTrackingSystem.Application.Repositories;
using MissionTrackingSystem.Application.ViewModels.Departments;
using MissionTrackingSystem.Domain.Entities;
using System.Net;

namespace MissionTrackingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class DepartmentsController : ControllerBase
    {
        readonly private IDepartmentWriteRepository _departmentWriteRepository;
        readonly private IDepartmentReadRepository _departmentReadRepository;
        public DepartmentsController(IDepartmentWriteRepository departmentWriteRepository, IDepartmentReadRepository departmentReadRepository)
        {
            _departmentWriteRepository = departmentWriteRepository;
            _departmentReadRepository = departmentReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_departmentReadRepository.GetAll(false).Select(p=> new
            {
                p.DepartmentName,
                p.Id,
                p.CreatedDate,
                p.UpdatedDate,

            })); 
            
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
        //    Department department = await _departmentReadRepository.GetByIdAsync(id);
            return Ok(await _departmentReadRepository.GetByIdAsync(id, false));
        }
        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Department model)
        {

            await _departmentWriteRepository.AddAsync(new()
            {
                DepartmentName = model.DepartmentName,
            
            });
            await _departmentWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);

        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Department model)
        {

            Department department = await _departmentReadRepository.GetByIdAsync(model.ID);
            department.DepartmentName= model.DepartmentName;
            await _departmentWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _departmentWriteRepository.RemoveAsync(id);
            await _departmentWriteRepository.SaveAsync();
            return Ok();
        }

    }
}
