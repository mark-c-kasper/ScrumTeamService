using System.Net;
using Microsoft.AspNetCore.Mvc;
using ScrumTeamService.Models;

namespace ScrumTeamService.Controllers;

public sealed class TeamMemberController : ControllerBase
{
    private readonly ILogger<TeamMemberController> _logger;

    public TeamMemberController(ILogger<TeamMemberController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet(Name = "GetTeamMembers")]
    [ProducesResponseType(typeof(IReadOnlyCollection<TeamMember>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetTeamMembers()
    {
        return this.Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddNewOrganization([FromBody] TeamMember team)
    {
        return this.Ok();
    }
}