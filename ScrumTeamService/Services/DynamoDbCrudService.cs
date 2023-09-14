using Amazon.DynamoDBv2.Model;
using ScrumTeamService.Models;

namespace ScrumTeamService.Services;

public abstract class DynamoDbCrudService<T> : IDynamoDbCrudService<T> where T: IDynamoDbParseable
{
    protected List<T> GetItemsFromQueryResponse(List<Dictionary<string, AttributeValue>> responseItems) 
    {
        List<T> listOfT = new List<T>();

        foreach (var responseItem in responseItems)
        {
            listOfT.Add(GetObjectFromDynamoDbDictionary(responseItem));
        }

        return listOfT;
    }

    protected abstract T GetObjectFromDynamoDbDictionary(Dictionary<string, AttributeValue> responseItem);
    
    public abstract Task<IReadOnlyCollection<T>> GetAllAsync();

    public abstract Task<T> GetByIdAsync(string id);

    public abstract Task CreateAsync(T t);

    public abstract Task UpdateAsync(T t);
}