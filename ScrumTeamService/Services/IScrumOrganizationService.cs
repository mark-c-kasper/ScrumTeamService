using ScrumTeamService.Models;

namespace ScrumTeamService.Services;

public interface IScrumOrganizationService
{
    Task CreateScrumOrganizationAsync(ScrumOrganization organization);
    
    Task<IReadOnlyCollection<ScrumOrganization>> GetAllScrumOrganizationsAsync();
    
    Task<ScrumOrganization> GetScrumOrganizationById(string guid);
    
    Task UpdateScrumOrganizationAsync(ScrumOrganization organization);
}