using Amazon.DynamoDBv2.Model;

namespace ScrumTeamService.Services;

public interface IDynamoDbService
{
    Task<PutItemResponse?> PutItemAsync(PutItemRequest putItemRequest);

    Task<GetItemResponse> GetItemAsync(GetItemRequest getItemRequest);

    Task<QueryResponse> QueryTableAsync(QueryRequest queryRequest);

    Task<ScanResponse> ScanTableAsync(ScanRequest scanRequest);
}