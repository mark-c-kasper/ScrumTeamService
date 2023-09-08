using ScrumTeamService.Services;

namespace ScrumTeamService.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void RegisterServices(this IServiceCollection service)
    {
        service.AddScoped<IDepartmentService, DepartmentService>();
        service.AddScoped<IScrumOrganizationService, ScrumOrganizationService>();
        service.AddScoped<IScrumTeamService, Services.ScrumTeamService>();
        service.AddScoped<ITeamMemberService, TeamMemberService>();
    }
}