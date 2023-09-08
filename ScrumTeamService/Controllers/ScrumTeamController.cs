using System.Net;
using Microsoft.AspNetCore.Mvc;
using ScrumTeamService.Models;
using ScrumTeamService.Services;

namespace ScrumTeamService.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class ScrumTeamController : ControllerBase
{
    private readonly IScrumTeamService _scrumTeamService;
    
    private readonly ILogger<ScrumTeamController> _logger;

    public ScrumTeamController(IScrumTeamService scrumTeamService, ILogger<ScrumTeamController> logger)
    {
        _scrumTeamService = scrumTeamService;
        _logger = logger;
    }
    
    [HttpGet(Name = "GetScrumTeamsAsync")]
    [ProducesResponseType(typeof(IReadOnlyCollection<ScrumTeam>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetScrumTeamsAsync()
    {
        try
        {
            IReadOnlyCollection<ScrumTeam> departments = await _scrumTeamService.GetAllScrumTeamsAsync();
            return Ok(departments);
        }
        catch(Exception exception)
        {
            _logger.LogError(exception, "Error getting scrum teams");
            throw;
        }
    }
    
    [HttpGet(Name = "GetScrumTeamByIdAsync")]
    [ProducesResponseType(typeof(ScrumTeam), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetScrumTeamByIdAsync(string id)
    {
        try
        {
            ScrumTeam departments = await _scrumTeamService.GetScrumTeamById(id);
            return Ok(departments);
        }
        catch(Exception exception)
        {
            _logger.LogError(exception, "Error getting scrum team for id: {Id}", id);
            throw;
        }
    }
    
    [HttpPost(Name = "AddNewScrumTeamAsync")]
    public async Task<IActionResult> AddNewScrumTeamAsync([FromBody] ScrumTeam scrumTeam)
    {
        try
        {
            await _scrumTeamService.CreateScrumTeamAsync(scrumTeam);
            return Ok();
        }
        catch(Exception exception)
        {
            _logger.LogError(exception, "Error creating scrum team");
            throw;
        }
    }
    
    [HttpPost(Name = "UpdateScrumTeamAsync")]
    public async Task<IActionResult> UpdateScrumTeamAsync([FromBody] ScrumTeam scrumTeam)
    {
        try
        {
            await _scrumTeamService.UpdateScrumTeamAsync(scrumTeam);
            return Ok();
        }
        catch(Exception exception)
        {
            _logger.LogError(exception, "Error updating team member for Id: {Id}", scrumTeam.Id);
            throw;
        }
    }
}