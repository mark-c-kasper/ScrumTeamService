using Amazon.DynamoDBv2.Model;
using FluentValidation;
using ScrumTeamService.Models;
using ScrumTeamService.Extensions;
using ScrumTeamService.Constants;

namespace ScrumTeamService.Services;

public sealed class DepartmentService : DynamoDbParser<Department>, IDynamoDbCrudService<Department>
{
    private readonly IDynamoDbService _dynamoDbService;
    
    private readonly ILogger<DepartmentService> _logger;

    private readonly IValidator<Department> _validator;

    private static readonly List<string> DepartmentAttributesToGet = new() { "Id", "Name" };
    
    public DepartmentService(IDynamoDbService dynamoDbService,
        ILogger<DepartmentService> logger,
        IValidator<Department> validator)
    {
        _dynamoDbService = dynamoDbService;
        _logger = logger;
        _validator = validator;
    }
    
    public override async Task<IReadOnlyCollection<Department>> GetAllAsync()
    {
        QueryRequest queryRequest = new QueryRequest
        {
            TableName = DynamoDbConstants.DepartmentsTableName,
            AttributesToGet = DepartmentAttributesToGet
        };

        var response = await _dynamoDbService.QueryTableAsync(queryRequest);
        
        return await Task.FromResult(new List<Department>());
    }

    public override async Task<Department> GetByIdAsync(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new ArgumentNullException(nameof(id));
        }

        var getItemRequest = GetDynamoDbItemRequestForId(id);

        var response = _dynamoDbService.GetItemAsync(getItemRequest);
        
        return await Task.FromResult(new Department());
    }
    
    public override async Task CreateAsync(Department department)
    {
        department.ThrowExceptionIfNull(nameof(department));
        await _validator.ValidateAsync(department, ValidationConstants.CreateDepartmentValidationMessage, _logger);

        var putItemRequest = department.ToPutItemRequest();

        await _dynamoDbService.PutItemAsync(putItemRequest);
    }

    public override async Task UpdateAsync(Department department)
    {
        department.ThrowExceptionIfNull(nameof(department));
        await _validator.ValidateAsync(department, ValidationConstants.UpdateDepartmentValidationMessage, _logger);

        var putItemRequest = department.ToPutItemRequest();

        await _dynamoDbService.PutItemAsync(putItemRequest);
    }
    
    private static GetItemRequest GetDynamoDbItemRequestForId(string id)
    {
        var getItemRequest = new GetItemRequest
        {
            TableName = DynamoDbConstants.DepartmentsTableName,
            Key = {{ "Id", new AttributeValue(id)}},
            AttributesToGet = DepartmentAttributesToGet
        };

        return getItemRequest;
    }
    
    protected override Department GetObjectFromDynamoDbDictionary(Dictionary<string, AttributeValue> responseItem)
    {
        return new Department
        {
            Id = Guid.Parse(responseItem["Id"].S),
            Name = responseItem["Name"].S
        };
    }
}