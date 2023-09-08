using ScrumTeamService.Models;

namespace ScrumTeamService.Services;

public interface ITeamMemberService
{
    Task CreateTeamMemberAsync(TeamMember teamMember);
    
    Task<IReadOnlyCollection<TeamMember>> GetAllTeamMembersAsync();
    
    Task<TeamMember> GetTeamMemberById(string guid);
    
    Task UpdateTeamMemberAsync(TeamMember teamMember);
}