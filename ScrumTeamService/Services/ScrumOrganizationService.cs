using Amazon.DynamoDBv2.Model;
using FluentValidation;
using ScrumTeamService.Constants;
using ScrumTeamService.Extensions;
using ScrumTeamService.Models;

namespace ScrumTeamService.Services;

public sealed class ScrumOrganizationService : DynamoDbParser<ScrumOrganization>, IDynamoDbCrudService<ScrumOrganization>
{
    private readonly IDynamoDbService _dynamoDbService;
    
    private readonly ILogger<ScrumOrganizationService> _logger;

    private readonly IValidator<ScrumOrganization> _validator;
    
    private static readonly List<string> ScrumOrganizationAttributesToGet = new() { "Id", "Name" };
    
    public ScrumOrganizationService(IDynamoDbService dynamoDbService, ILogger<ScrumOrganizationService> logger,
        IValidator<ScrumOrganization> validator)
    {
        _dynamoDbService = dynamoDbService;
        _logger = logger;
        _validator = validator;
    }
    
    public override async Task<IReadOnlyCollection<ScrumOrganization>> GetAllAsync()
    {
        
        QueryRequest queryRequest = new QueryRequest
        {
            TableName = DynamoDbConstants.ScrumOrganizationTableName,
            AttributesToGet = ScrumOrganizationAttributesToGet
        };

        var response = await _dynamoDbService.QueryTableAsync(queryRequest);
        return await Task.FromResult(new List<ScrumOrganization>());
    }

    public override async Task<ScrumOrganization> GetByIdAsync(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new ArgumentNullException(nameof(id));
        }

        var getItemRequest = GetDynamoDbItemRequestForId(id);

        var response = _dynamoDbService.GetItemAsync(getItemRequest);
        
        return await Task.FromResult(new ScrumOrganization());
    }
    
    public override async Task CreateAsync(ScrumOrganization organization)
    {
        organization.ThrowExceptionIfNull(nameof(organization));
        await _validator.ValidateAsync(organization, ValidationConstants.CreateScrumOrganizationValidationMessage, _logger);
        
    }

    public override async Task UpdateAsync(ScrumOrganization organization)
    {
        organization.ThrowExceptionIfNull(nameof(organization));
        await _validator.ValidateAsync(organization, ValidationConstants.UpdateScrumOrganizationValidationMessage, _logger);
    }
    
    private static GetItemRequest GetDynamoDbItemRequestForId(string id)
    {
        var getItemRequest = new GetItemRequest
        {
            TableName = DynamoDbConstants.ScrumOrganizationTableName,
            Key = {{ "Id", new AttributeValue(id)}},
            AttributesToGet = ScrumOrganizationAttributesToGet
        };

        return getItemRequest;
    }

    protected override ScrumOrganization GetObjectFromDynamoDbDictionary(Dictionary<string, AttributeValue> responseItem)
    {
        return new ScrumOrganization
        {
            Id = Guid.Parse(responseItem["Id"].S),
            Name = responseItem["Name"].S
        };
    }
}