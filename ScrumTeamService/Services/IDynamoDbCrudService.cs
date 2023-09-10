namespace ScrumTeamService.Services;

public interface IDynamoDbCrudService<T>
{
    Task<IReadOnlyCollection<T>> GetAllAsync();

    Task<T> GetByIdAsync(string id);

    Task CreateAsync(T t);

    Task UpdateAsync(T t);
}