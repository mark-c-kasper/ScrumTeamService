namespace ScrumTeamService.Models;

public class TeamMember
{
    public Guid Id { get; init; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Position { get; set; } = null!;

    public decimal Salary { get; set; }

    public Guid TeamId { get; set; }

    public Guid DepartmentId { get; set; }
}