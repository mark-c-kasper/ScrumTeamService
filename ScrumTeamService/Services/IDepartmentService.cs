using ScrumTeamService.Models;

namespace ScrumTeamService.Services;

public interface IDepartmentService
{
    Task CreateDepartmentAsync(Department department);
    
    Task<IReadOnlyCollection<Department>> GetAllDepartmentsAsync();
    
    Task<Department> GetDepartmentById(string guid);
    
    Task UpdateDepartmentAsync(Department department);
}