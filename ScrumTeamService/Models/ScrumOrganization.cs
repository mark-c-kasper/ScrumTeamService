namespace ScrumTeamService.Models;

public sealed class ScrumOrganization : IDynamoDbParseable
{
    public Guid Id { get; init; }

    public string Name { get; init; } = null!;
}