using ScrumTeamService.Models;

namespace ScrumTeamService.Services;

public interface IScrumOrganizationService
{
    Task<IReadOnlyCollection<ScrumOrganization>> GetAllScrumOrganizationsAsync();
    
    Task<ScrumOrganization> GetScrumOrganizationById(string id);
    
    Task CreateScrumOrganizationAsync(ScrumOrganization organization);
    
    Task UpdateScrumOrganizationAsync(ScrumOrganization organization);
}