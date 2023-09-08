using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using ScrumTeamService.Constants;
using ScrumTeamService.Models;

namespace ScrumTeamService.Services;

public sealed class DynamoDbService : IDynamoDbService
{
    private ILogger<DynamoDbService> _logger;
    
    public DynamoDbService(ILogger<DynamoDbService> logger)
    {
        _logger = logger;
    }

    public void PutItem(PutItemRequest putItemRequest)
    {
        using AmazonDynamoDBClient amazonDynamoDbClient = new AmazonDynamoDBClient();

        amazonDynamoDbClient.PutItemAsync(putItemRequest);
    }
}