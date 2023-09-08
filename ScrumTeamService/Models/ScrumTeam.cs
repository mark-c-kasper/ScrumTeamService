namespace ScrumTeamService.Models;

public sealed class ScrumTeam
{
    public Guid Id { get; init; }

    public string Name { get; init; } = null!;

    public Guid OrganizationId { get; set; }
}