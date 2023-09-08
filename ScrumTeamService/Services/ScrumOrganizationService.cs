using ScrumTeamService.Models;

namespace ScrumTeamService.Services;

public sealed class ScrumOrganizationService : IScrumOrganizationService
{
    private readonly ILogger<ScrumOrganizationService> _logger;
    
    public ScrumOrganizationService(ILogger<ScrumOrganizationService> logger)
    {
        _logger = logger;
    }
    
    public async Task CreateScrumOrganizationAsync(ScrumOrganization organization)
    {
        
    }

    public async Task<IReadOnlyCollection<ScrumOrganization>> GetAllScrumOrganizationsAsync()
    {
        return await Task.FromResult(new List<ScrumOrganization>());
    }

    public async Task<ScrumOrganization> GetScrumOrganizationById(string guid)
    {
        return await Task.FromResult(new ScrumOrganization());
    }

    public async Task UpdateScrumOrganizationAsync(ScrumOrganization organization)
    {
        
    }
}