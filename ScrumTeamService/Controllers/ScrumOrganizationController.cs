using System.Net;
using Microsoft.AspNetCore.Mvc;
using ScrumTeamService.Models;
using ScrumTeamService.Services;

namespace ScrumTeamService.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class ScrumOrganizationController : ControllerBase
{
    private readonly IScrumOrganizationService _scrumOrganizationService;
    
    private readonly ILogger<ScrumOrganizationController> _logger;

    public ScrumOrganizationController(IScrumOrganizationService scrumOrganizationService,
        ILogger<ScrumOrganizationController> logger)
    {
        _scrumOrganizationService = scrumOrganizationService;
        _logger = logger;
    }

    [HttpGet(Name = "GetScrumOrganizationsAsync")]
    [ProducesResponseType(typeof(IReadOnlyCollection<ScrumOrganization>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetOrganizationsAsync()
    {
        try
        {
            IReadOnlyCollection<ScrumOrganization> departments = await _scrumOrganizationService.GetAllScrumOrganizationsAsync();
            return Ok(departments);
        }
        catch(Exception exception)
        {
            _logger.LogError(exception, "Error getting scrum organizations");
            throw;
        }
    }
    
    [HttpGet(Name = "GetScrumOrganizationByIdAsync")]
    [ProducesResponseType(typeof(ScrumOrganization), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetScrumOrganizationByIdAsync(string id)
    {
        try
        {
            ScrumOrganization departments = await _scrumOrganizationService.GetScrumOrganizationById(id);
            return Ok(departments);
        }
        catch(Exception exception)
        {
            _logger.LogError(exception, "Error getting team organization for id: {Id}", id);
            throw;
        }
    }

    [HttpPost(Name = "AddNewScrumOrganizationAsync")]
    public async Task<IActionResult> AddNewOrganizationAsync([FromBody] ScrumOrganization organization)
    {
        try
        {
            await _scrumOrganizationService.CreateScrumOrganizationAsync(organization);
            return Ok();
        }
        catch(Exception exception)
        {
            _logger.LogError(exception, "Error creating scrum organization");
            throw;
        }
    }
    
    [HttpPost(Name = "UpdateScrumOrganizationAsync")]
    public async Task<IActionResult> UpdateOrganizationAsync([FromBody] ScrumOrganization organization)
    {
        try
        {
            await _scrumOrganizationService.UpdateScrumOrganizationAsync(organization);
            return Ok();
        }
        catch(Exception exception)
        {
            _logger.LogError(exception, "Error updating team member for Id: {Id}", organization.Id);
            throw;
        }
    }
}