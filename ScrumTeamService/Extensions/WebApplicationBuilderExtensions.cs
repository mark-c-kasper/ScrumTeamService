using FluentValidation;
using ScrumTeamService.Models;
using ScrumTeamService.Services;
using ScrumTeamService.Validators;

namespace ScrumTeamService.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void RegisterServices(this IServiceCollection service)
    {
        service.AddScoped<IDepartmentService, DepartmentService>();
        service.AddScoped<IScrumOrganizationService, ScrumOrganizationService>();
        service.AddScoped<IScrumTeamService, Services.ScrumTeamService>();
        service.AddScoped<ITeamMemberService, TeamMemberService>();
        service.AddScoped<IDynamoDbService, DynamoDbService>();
    }

    public static void RegisterValidators(this IServiceCollection service)
    {
        service.AddTransient<IValidator<Department>, DepartmentValidator>();
        service.AddTransient<IValidator<ScrumOrganization>, ScrumOrganizationValidator>();
        service.AddTransient<IValidator<ScrumTeam>, ScrumTeamValidator>();
        service.AddTransient<IValidator<TeamMember>, TeamMemberValidator>();
    }
}