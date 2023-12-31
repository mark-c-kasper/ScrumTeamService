using System.Net;
using Microsoft.AspNetCore.Mvc;
using ScrumTeamService.Models;
using ScrumTeamService.Services;

namespace ScrumTeamService.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class TeamMemberController : ControllerBase
{
    private readonly IDynamoDbCrudService<TeamMember> _teamMemberService;
    
    private readonly ILogger<TeamMemberController> _logger;

    public TeamMemberController(IDynamoDbCrudService<TeamMember> teamMemberService, ILogger<TeamMemberController> logger)
    {
        _teamMemberService = teamMemberService;
        _logger = logger;
    }
    
    [HttpGet(Name = "GetTeamMembersAsync")]
    [ProducesResponseType(typeof(IReadOnlyCollection<TeamMember>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetTeamMembersAsync()
    {
        try
        {
            IReadOnlyCollection<TeamMember> teamMembers = await _teamMemberService.GetAllAsync();
            return Ok(teamMembers);
        }
        catch(Exception exception)
        {
            _logger.LogError(exception, "Error getting team members");
            throw;
        }
    }
    
    [HttpGet(Name = "GetTeamMemberByIdAsync")]
    [ProducesResponseType(typeof(ScrumOrganization), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetTeamMemberByIdAsync(string id)
    {
        try
        {
            TeamMember teamMember = await _teamMemberService.GetByIdAsync(id);
            return Ok(teamMember);
        }
        catch(Exception exception)
        {
            _logger.LogError(exception, "Error getting team member for id: {Id}", id);
            throw;
        }
    }
    
    [HttpPost(Name = "AddNewTeamMemberAsync")]
    public async Task<IActionResult> AddNewTeamMemberAsync([FromBody] TeamMember teamMember)
    {
        try
        {
            await _teamMemberService.CreateAsync(teamMember);
            return Ok(teamMember);
        }
        catch(Exception exception)
        {
            _logger.LogError(exception, "Error creating team member");
            throw;
        }
    }
    
    [HttpPost(Name = "UpdateTeamMemberAsync")]
    public async Task<IActionResult> UpdateTeamMemberAsync([FromBody] TeamMember teamMember)
    {
        try
        {
            await _teamMemberService.UpdateAsync(teamMember);
            return Ok(teamMember);
        }
        catch(Exception exception)
        {
            _logger.LogError(exception, "Error updating team member for Id: {Id}", teamMember.Id);
            throw;
        }
    }
}