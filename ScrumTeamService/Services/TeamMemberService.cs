using Amazon.DynamoDBv2.Model;
using FluentValidation;
using ScrumTeamService.Constants;
using ScrumTeamService.Extensions;
using ScrumTeamService.Models;

namespace ScrumTeamService.Services;

public sealed class TeamMemberService : DynamoDbParser<TeamMember>, IDynamoDbCrudService<TeamMember>
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
    
    public override async Task<IReadOnlyCollection<TeamMember>> GetAllAsync()
    {
        QueryRequest queryRequest = new QueryRequest
        {
            TableName = DynamoDbConstants.TeamMemberTableName,
            AttributesToGet = TeamMemberAttributesToGet
        };

        var response = await _dynamoDbService.QueryTableAsync(queryRequest);
        
        return this.GetItemsFromQueryResponse(response.Items);
    }

    public override async Task<TeamMember> GetByIdAsync(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new ArgumentNullException(nameof(id));
        }

        var getItemRequest = GetDynamoDbItemRequestForId(id);

        var response = await _dynamoDbService.GetItemAsync(getItemRequest);
        
        return GetObjectFromDynamoDbDictionary(response.Item);
    }
    
    public override async Task CreateAsync(TeamMember teamMember)
    {
        teamMember.ThrowExceptionIfNull(nameof(teamMember));
        await _validator.ValidateAsync(teamMember, ValidationConstants.CreateTeamMemberValidationMessage, _logger);
    }

    public override async Task UpdateAsync(TeamMember teamMember)
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

    protected override TeamMember GetObjectFromDynamoDbDictionary(Dictionary<string, AttributeValue> responseItem)
    {
        return new TeamMember
        {
            Id = Guid.Parse(responseItem["Id"].S),
            LastName = responseItem["LastName"].S,
            FirstName = responseItem["FirstName"].S,
            Position = responseItem["Position"].S,
            Salary = decimal.Parse(responseItem["Salary"].N),
            DepartmentId = Guid.Parse(responseItem["DepartmentId"].S),
            TeamId = Guid.Parse(responseItem["TeamId"].S),
        };
    }
}