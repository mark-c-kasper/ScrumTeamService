using ScrumTeamService.Models;

namespace ScrumTeamService.Services;

public interface ITeamMemberService
{
    Task<IReadOnlyCollection<TeamMember>> GetAllTeamMembersAsync();
    
    Task<TeamMember> GetTeamMemberById(string id);
    
    Task CreateTeamMemberAsync(TeamMember teamMember);
    
    Task UpdateTeamMemberAsync(TeamMember teamMember);
}