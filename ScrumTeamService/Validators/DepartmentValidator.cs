using FluentValidation;
using ScrumTeamService.Models;

namespace ScrumTeamService.Validators;

public sealed class DepartmentValidator : AbstractValidator<Department>
{
    public DepartmentValidator()
    {
        RuleFor(d => d.Name).NotNull();
        RuleFor(d => d.Name).NotEmpty();
    }
}