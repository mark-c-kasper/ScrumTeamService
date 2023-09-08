using System.Net;
using Microsoft.AspNetCore.Mvc;
using ScrumTeamService.Models;

namespace ScrumTeamService.Controllers;

public sealed class ScrumTeamController : ControllerBase
{
    private readonly ILogger<ScrumTeamController> _logger;

    public ScrumTeamController(ILogger<ScrumTeamController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet(Name = "GetScrumTeams")]
    [ProducesResponseType(typeof(IReadOnlyCollection<ScrumTeam>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetScrumTeams()
    {
        return this.Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddNewOrganization([FromBody] ScrumTeam scrumTeam)
    {
        return this.Ok();
    }
}