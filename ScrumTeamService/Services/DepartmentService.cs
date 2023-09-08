using FluentValidation;
using ScrumTeamService.Models;

namespace ScrumTeamService.Services;

public sealed class DepartmentService : IDepartmentService
{
    private readonly IDynamoDbService _dynamoDbService;
    
    private readonly ILogger<DepartmentService> _logger;

    private readonly IValidator<Department> _validator;
    
    public DepartmentService(IDynamoDbService dynamoDbService,
        ILogger<DepartmentService> logger,
        IValidator<Department> validator)
    {
        _dynamoDbService = dynamoDbService;
        _logger = logger;
        _validator = validator;
    }
    
    public async Task CreateDepartmentAsync(Department department)
    {
        var validationResults = await _validator.ValidateAsync(department);

        if (!validationResults.IsValid)
        {
            _logger.LogWarning("Encountered issue validating creating department");
            throw new ValidationException(validationResults.Errors);
        }
        
    }

    public async Task<IReadOnlyCollection<Department>> GetAllDepartmentsAsync()
    {
        return await Task.FromResult(new List<Department>());
    }

    public async Task<Department> GetDepartmentById(string guid)
    {
        return await Task.FromResult(new Department());
    }

    public async Task UpdateDepartmentAsync(Department department)
    {
        var validationResults = await _validator.ValidateAsync(department);

        if (!validationResults.IsValid)
        {
            _logger.LogWarning("Encountered issue validating creating department");
            throw new ValidationException(validationResults.Errors);
        }
    }
}