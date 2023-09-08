namespace ScrumTeamService.Models;

public sealed class ScrumOrganization
{
    public Guid Id { get; init; }

    public string Name { get; init; } = null!;
}