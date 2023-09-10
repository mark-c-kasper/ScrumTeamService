using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace ScrumTeamService.Services;

public sealed class DynamoDbService : IDynamoDbService
{
    private ILogger<DynamoDbService> _logger;
    
    public DynamoDbService(ILogger<DynamoDbService> logger)
    {
        _logger = logger;
    }

    public async Task<PutItemResponse?> PutItemAsync(PutItemRequest putItemRequest)
    {
        if (putItemRequest is null)
        {
            throw new ArgumentNullException(nameof(putItemRequest));
        }
        
        using AmazonDynamoDBClient amazonDynamoDbClient = new AmazonDynamoDBClient();

        try
        {
            var response = await amazonDynamoDbClient.PutItemAsync(putItemRequest);
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception putting item to DynamoDb");
            throw;
        }
    }

    public async Task<GetItemResponse> GetItemAsync(GetItemRequest getItemRequest)
    {
        if (getItemRequest is null)
        {
            throw new ArgumentNullException(nameof(getItemRequest));
        }
        
        using AmazonDynamoDBClient amazonDynamoDbClient = new AmazonDynamoDBClient();

        try
        {
            var response = await amazonDynamoDbClient.GetItemAsync(getItemRequest);
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception getting item from DynamoDb");
            throw;
        }
    }
    
    public async Task<QueryResponse> QueryTableAsync(QueryRequest queryRequest)
    {
        if (queryRequest is null)
        {
            throw new ArgumentNullException(nameof(queryRequest));
        }
        
        using AmazonDynamoDBClient amazonDynamoDbClient = new AmazonDynamoDBClient();

        try
        {
            var response = await amazonDynamoDbClient.QueryAsync(queryRequest);
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception querying table from DynamoDb");
            throw;
        }
    }
}