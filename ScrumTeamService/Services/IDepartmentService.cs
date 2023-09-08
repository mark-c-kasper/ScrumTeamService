using ScrumTeamService.Models;

namespace ScrumTeamService.Services;

public interface IDepartmentService
{
    Task<IReadOnlyCollection<Department>> GetAllDepartmentsAsync();
    
    Task<Department> GetDepartmentById(string id);
    
    Task CreateDepartmentAsync(Department department);
    
    Task UpdateDepartmentAsync(Department department);
}