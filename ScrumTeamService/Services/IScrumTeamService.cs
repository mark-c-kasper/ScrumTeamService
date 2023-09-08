using ScrumTeamService.Models;

namespace ScrumTeamService.Services;

public interface IScrumTeamService
{
    Task CreateScrumTeamAsync(ScrumTeam scrumTeam);
    
    Task<IReadOnlyCollection<ScrumTeam>> GetAllScrumTeamsAsync();
    
    Task<ScrumTeam> GetScrumTeamById(string guid);
    
    Task UpdateScrumTeamAsync(ScrumTeam scrumTeam);
}