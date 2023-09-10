using Amazon.DynamoDBv2.Model;

namespace ScrumTeamService.Models;

public class Department : IDynamoDbParseable
{
    public Guid Id { get; init; }

    public string Name { get; init; } = null!;
}