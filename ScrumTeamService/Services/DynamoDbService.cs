namespace ScrumTeamService.Services;

public sealed class DynamoDbService
{
    private ILogger<DynamoDbService> _logger;
    
    public DynamoDbService(ILogger<DynamoDbService> logger)
    {
        _logger = logger;
    }
}