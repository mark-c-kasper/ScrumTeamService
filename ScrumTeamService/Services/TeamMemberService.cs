using ScrumTeamService.Models;

namespace ScrumTeamService.Services;

public sealed class TeamMemberService : ITeamMemberService
{
    private readonly ILogger<TeamMemberService> _logger;
    
    public TeamMemberService(ILogger<TeamMemberService> logger)
    {
        _logger = logger;
    }
    
    public async Task CreateTeamMemberAsync(TeamMember teamMember)
    {
        
    }

    public async Task<IReadOnlyCollection<TeamMember>> GetAllTeamMembersAsync()
    {
        return await Task.FromResult(new List<TeamMember>());
    }

    public async Task<TeamMember> GetTeamMemberById(string guid)
    {
        return await Task.FromResult(new TeamMember());
    }

    public async Task UpdateTeamMemberAsync(TeamMember teamMember)
    {
        
    }
}