using FluentValidation;
using ScrumTeamService.Models;

namespace ScrumTeamService.Services;

public sealed class ScrumTeamService : IScrumTeamService
{
    private readonly IDynamoDbService _dynamoDbService;
    
    private readonly ILogger<ScrumTeamService> _logger;

    private readonly IValidator<ScrumTeam> _validator;
    
    public ScrumTeamService(IDynamoDbService dynamoDbService, ILogger<ScrumTeamService> logger,
        IValidator<ScrumTeam> validator)
    {
        _dynamoDbService = dynamoDbService;
        _logger = logger;
        _validator = validator;
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