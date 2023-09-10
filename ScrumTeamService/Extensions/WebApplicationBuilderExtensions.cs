using FluentValidation;
using ScrumTeamService.Models;
using ScrumTeamService.Services;
using ScrumTeamService.Validators;

namespace ScrumTeamService.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void RegisterServices(this IServiceCollection service)
    {
        service.AddScoped<IDynamoDbCrudService<Department>, DepartmentService>();
        service.AddScoped<IDynamoDbCrudService<ScrumOrganization>, ScrumOrganizationService>();
        service.AddScoped<IDynamoDbCrudService<ScrumTeam>, Services.ScrumTeamService>();
        service.AddScoped<IDynamoDbCrudService<TeamMember>, TeamMemberService>();
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