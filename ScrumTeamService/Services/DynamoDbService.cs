namespace ScrumTeamService.Services;

public sealed class DynamoDbService : IDynamoDbService
{
    private ILogger<DynamoDbService> _logger;
    
    public DynamoDbService(ILogger<DynamoDbService> logger)
    {
        _logger = logger;
    }
}