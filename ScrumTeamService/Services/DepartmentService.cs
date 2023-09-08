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
        await _validator.ValidateAsync(department, ValidationConstants.CreateDepartmentValidationMessage, _logger);
        
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
        await _validator.ValidateAsync(department, ValidationConstants.UpdateDepartmentValidationMessage, _logger);
    }
}