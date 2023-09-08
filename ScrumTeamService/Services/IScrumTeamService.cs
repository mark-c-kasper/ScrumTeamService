using ScrumTeamService.Models;

namespace ScrumTeamService.Services;

public interface IScrumTeamService
{
    Task<IReadOnlyCollection<ScrumTeam>> GetAllScrumTeamsAsync();
    
    Task<ScrumTeam> GetScrumTeamById(string id);
    
    Task CreateScrumTeamAsync(ScrumTeam scrumTeam);
    
    Task UpdateScrumTeamAsync(ScrumTeam scrumTeam);
}