using System.Net;
using Microsoft.AspNetCore.Mvc;
using ScrumTeamService.Models;

namespace ScrumTeamService.Controllers;

public sealed class OrganizationController : ControllerBase
{
    private readonly ILogger<OrganizationController> _logger;

    public OrganizationController(ILogger<OrganizationController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetOrganizations")]
    [ProducesResponseType(typeof(IReadOnlyCollection<ScrumOrganization>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetOrganizations()
    {
        return this.Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddNewOrganization([FromBody] ScrumOrganization organization)
    {
        return this.Ok();
    }
}