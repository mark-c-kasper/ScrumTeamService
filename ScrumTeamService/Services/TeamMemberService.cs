using Amazon.DynamoDBv2.Model;
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
    
    private static readonly List<string> TeamMemberAttributesToGet = new() { "Id", "Name" };
    
    public TeamMemberService(IDynamoDbService dynamoDbService,
        ILogger<TeamMemberService> logger,
        IValidator<TeamMember> validator)
    {
        _dynamoDbService = dynamoDbService;
        _logger = logger;
        _validator = validator;
    }
    
    public async Task<IReadOnlyCollection<TeamMember>> GetAllTeamMembersAsync()
    {
        QueryRequest queryRequest = new QueryRequest
        {
            TableName = DynamoDbConstants.TeamMemberTableName,
            AttributesToGet = TeamMemberAttributesToGet
        };

        var response = await _dynamoDbService.QueryTableAsync(queryRequest);
        return await Task.FromResult(new List<TeamMember>());
    }

    public async Task<TeamMember> GetTeamMemberById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new ArgumentNullException(nameof(id));
        }

        var getItemRequest = GetDynamoDbItemRequestForId(id);

        var response = _dynamoDbService.GetItemAsync(getItemRequest);
        
        return await Task.FromResult(new TeamMember());
    }
    
    public async Task CreateTeamMemberAsync(TeamMember teamMember)
    {
        teamMember.ThrowExceptionIfNull(nameof(teamMember));
        await _validator.ValidateAsync(teamMember, ValidationConstants.CreateTeamMemberValidationMessage, _logger);
    }

    public async Task UpdateTeamMemberAsync(TeamMember teamMember)
    {
        teamMember.ThrowExceptionIfNull(nameof(teamMember));
        await _validator.ValidateAsync(teamMember, ValidationConstants.UpdateTeamMemberValidationMessage, _logger);
    }
    
    private static GetItemRequest GetDynamoDbItemRequestForId(string id)
    {
        var getItemRequest = new GetItemRequest
        {
            TableName = DynamoDbConstants.TeamMemberTableName,
            Key = {{ "Id", new AttributeValue(id)}},
            AttributesToGet = TeamMemberAttributesToGet
        };

        return getItemRequest;
    }
}