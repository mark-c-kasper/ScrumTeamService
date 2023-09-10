using System.Net;
using Microsoft.AspNetCore.Mvc;
using ScrumTeamService.Models;
using ScrumTeamService.Services;

namespace ScrumTeamService.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class DepartmentController : ControllerBase
{
    private readonly IDynamoDbCrudService<Department> _departmentService;
    
    private readonly ILogger<DepartmentController> _logger;

    public DepartmentController(IDynamoDbCrudService<Department> departmentService, ILogger<DepartmentController> logger)
    {
        _departmentService = departmentService;
        _logger = logger;
    }

    [HttpGet(Name = "GetDepartmentsAsync")]
    [ProducesResponseType(typeof(IReadOnlyCollection<Department>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDepartmentsAsync()
    {
        try
        {
            IReadOnlyCollection<Department> departments = await _departmentService.GetAllAsync();
            return Ok(departments);
        }
        catch(Exception exception)
        {
            _logger.LogError(exception, "Error getting departments");
            throw;
        }
    }
    
    [HttpGet(Name = "GetDepartmentByIdAsync")]
    [ProducesResponseType(typeof(Department), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDepartmentByIdAsync(string id)
    {
        try
        {
            Department department = await _departmentService.GetByIdAsync(id);
            return Ok(department);
        }
        catch(Exception exception)
        {
            _logger.LogError(exception, "Error getting department for id: {Id}", id);
            throw;
        }
    }

    [HttpPost(Name = "AddNewDepartmentAsync")]
    public async Task<IActionResult> AddNewDepartmentAsync([FromBody] Department department)
    {
        try
        {
            await _departmentService.CreateAsync(department);
            return Ok();
        }
        catch(Exception exception)
        {
            _logger.LogError(exception, "Error creating department");
            throw;
        }
    }
    
    [HttpPost(Name = "UpdateDepartmentAsync")]
    public async Task<IActionResult> UpdateDepartmentAsync([FromBody] Department department)
    {
        try
        {
            await _departmentService.UpdateAsync(department);
            return Ok();
        }
        catch(Exception exception)
        {
            _logger.LogError(exception, "Error updating team member for Id: {Id}", department.Id);
            throw;
        }
    }
}