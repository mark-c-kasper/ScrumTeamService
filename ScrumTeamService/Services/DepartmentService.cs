using Amazon.DynamoDBv2.Model;
using FluentValidation;
using ScrumTeamService.Models;
using ScrumTeamService.Extensions;
using ScrumTeamService.Constants;

namespace ScrumTeamService.Services;

public sealed class DepartmentService : IDepartmentService
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
    
    public async Task<IReadOnlyCollection<Department>> GetAllDepartmentsAsync()
    {
        QueryRequest queryRequest = new QueryRequest
        {
            TableName = DynamoDbConstants.DepartmentsTableName,
            AttributesToGet = DepartmentAttributesToGet
        };

        var response = await _dynamoDbService.QueryTableAsync(queryRequest);
        
        return await Task.FromResult(new List<Department>());
    }

    public async Task<Department> GetDepartmentById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new ArgumentNullException(nameof(id));
        }

        var getItemRequest = GetDynamoDbItemRequestForId(id);

        var response = _dynamoDbService.GetItemAsync(getItemRequest);
        
        return await Task.FromResult(new Department());
    }
    
    public async Task CreateDepartmentAsync(Department department)
    {
        department.ThrowExceptionIfNull(nameof(department));
        await _validator.ValidateAsync(department, ValidationConstants.CreateDepartmentValidationMessage, _logger);

        var putItemRequest = department.ToPutItemRequest();

        await _dynamoDbService.PutItemAsync(putItemRequest);
    }

    public async Task UpdateDepartmentAsync(Department department)
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
}