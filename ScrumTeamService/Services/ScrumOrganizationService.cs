using FluentValidation;
using ScrumTeamService.Models;

namespace ScrumTeamService.Services;

public sealed class ScrumOrganizationService : IScrumOrganizationService
{
    private readonly IDynamoDbService _dynamoDbService;
    
    private readonly ILogger<ScrumOrganizationService> _logger;

    private readonly IValidator<ScrumOrganization> _validator;
    
    public ScrumOrganizationService(IDynamoDbService dynamoDbService, ILogger<ScrumOrganizationService> logger,
        IValidator<ScrumOrganization> validator)
    {
        _dynamoDbService = dynamoDbService;
        _logger = logger;
        _validator = validator;
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