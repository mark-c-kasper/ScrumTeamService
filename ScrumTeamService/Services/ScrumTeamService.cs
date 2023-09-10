using Amazon.DynamoDBv2.Model;
using FluentValidation;
using ScrumTeamService.Constants;
using ScrumTeamService.Extensions;
using ScrumTeamService.Models;

namespace ScrumTeamService.Services;

public sealed class ScrumTeamService : DynamoDbParser<ScrumTeam>, IDynamoDbCrudService<ScrumTeam>
{
    private readonly IDynamoDbService _dynamoDbService;
    
    private readonly ILogger<ScrumTeamService> _logger;

    private readonly IValidator<ScrumTeam> _validator;
    
    private static readonly List<string> ScrumTeamAttributesToGet = new() { "Id", "Name", "OrganizationId" };
    
    public ScrumTeamService(IDynamoDbService dynamoDbService, ILogger<ScrumTeamService> logger,
        IValidator<ScrumTeam> validator)
    {
        _dynamoDbService = dynamoDbService;
        _logger = logger;
        _validator = validator;
    }
    
    public override async Task<IReadOnlyCollection<ScrumTeam>> GetAllAsync()
    {
        QueryRequest queryRequest = new QueryRequest
        {
            TableName = DynamoDbConstants.ScrumTeamTableName,
            AttributesToGet = ScrumTeamAttributesToGet
        };

        var response = await _dynamoDbService.QueryTableAsync(queryRequest);
        return await Task.FromResult(new List<ScrumTeam>());
    }

    public override async Task<ScrumTeam> GetByIdAsync(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new ArgumentNullException(nameof(id));
        }

        var getItemRequest = GetDynamoDbItemRequestForId(id);

        var response = _dynamoDbService.GetItemAsync(getItemRequest);
        
        return await Task.FromResult(new ScrumTeam());
    }
    
    public override async Task CreateAsync(ScrumTeam scrumTeam)
    {
        scrumTeam.ThrowExceptionIfNull(nameof(scrumTeam));
        
        await _validator.ValidateAsync(scrumTeam, ValidationConstants.CreateScrumTeamValidationMessage, _logger);
    }

    public override async Task UpdateAsync(ScrumTeam scrumTeam)
    {
        scrumTeam.ThrowExceptionIfNull(nameof(scrumTeam));
        
        await _validator.ValidateAsync(scrumTeam, ValidationConstants.UpdateScrumTeamValidationMessage, _logger);
    }
    
    private static GetItemRequest GetDynamoDbItemRequestForId(string id)
    {
        var getItemRequest = new GetItemRequest
        {
            TableName = DynamoDbConstants.ScrumTeamTableName,
            Key = {{ "Id", new AttributeValue(id)}},
            AttributesToGet = ScrumTeamAttributesToGet
        };

        return getItemRequest;
    }

    protected override ScrumTeam GetObjectFromDynamoDbDictionary(Dictionary<string, AttributeValue> responseItem)
    {
        return new ScrumTeam
        {
            Id = Guid.Parse(responseItem["Id"].S),
            Name = responseItem["Name"].S,
            OrganizationId = Guid.Parse(responseItem["OrganizationId"].S),
        };
    }
}