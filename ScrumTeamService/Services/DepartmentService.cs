using ScrumTeamService.Models;

namespace ScrumTeamService.Services;

public sealed class DepartmentService : IDepartmentService
{
    private readonly ILogger<DepartmentService> _logger;
    
    public DepartmentService(ILogger<DepartmentService> logger)
    {
        _logger = logger;
    }
    
    public async Task CreateDepartmentAsync(Department department)
    {
        
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
        
    }
}