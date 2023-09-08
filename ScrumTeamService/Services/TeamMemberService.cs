using FluentValidation;
using ScrumTeamService.Constants;
using ScrumTeamService.Extensions;
using ScrumTeamService.Models;

namespace ScrumTeamService.Services;

public sealed class TeamMemberService : ITeamMemberService
{
    private readonly IDynamoDbService _dynamoDbService;
    
    private readonly ILogger<TeamMemberService> _logger;

    private readonly IValidator<TeamMember> _validator;
    
    public TeamMemberService(IDynamoDbService dynamoDbService,
        ILogger<TeamMemberService> logger,
        IValidator<TeamMember> validator)
    {
        _dynamoDbService = dynamoDbService;
        _logger = logger;
        _validator = validator;
    }
    
    public async Task CreateTeamMemberAsync(TeamMember teamMember)
    {
        await _validator.ValidateAsync(teamMember, ValidationConstants.CreateTeamMemberValidationMessage, _logger);
    }

    public async Task<IReadOnlyCollection<TeamMember>> GetAllTeamMembersAsync()
    {
        return await Task.FromResult(new List<TeamMember>());
    }

    public async Task<TeamMember> GetTeamMemberById(string guid)
    {
        return await Task.FromResult(new TeamMember());
    }

    public async Task UpdateTeamMemberAsync(TeamMember teamMember)
    {
        await _validator.ValidateAsync(teamMember, ValidationConstants.UpdateTeamMemberValidationMessage, _logger);
    }
}