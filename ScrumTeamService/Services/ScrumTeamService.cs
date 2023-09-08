using ScrumTeamService.Models;

namespace ScrumTeamService.Services;

public sealed class ScrumTeamService : IScrumTeamService
{
    private readonly ILogger<ScrumTeamService> _logger;
    
    public ScrumTeamService(ILogger<ScrumTeamService> logger)
    {
        _logger = logger;
    }
    
    public async Task CreateScrumTeamAsync(ScrumTeam scrumTeam)
    {
        
    }

    public async Task<IReadOnlyCollection<ScrumTeam>> GetAllScrumTeamsAsync()
    {
        return await Task.FromResult(new List<ScrumTeam>());
    }

    public async Task<ScrumTeam> GetScrumTeamById(string guid)
    {
        return await Task.FromResult(new ScrumTeam());
    }

    public async Task UpdateScrumTeamAsync(ScrumTeam scrumTeam)
    {
        
    }
}