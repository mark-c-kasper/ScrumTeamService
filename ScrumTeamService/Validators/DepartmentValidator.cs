using FluentValidation;
using ScrumTeamService.Models;

namespace ScrumTeamService.Validators;

public sealed class DepartmentValidator : AbstractValidator<Department>
{
    public DepartmentValidator()
    {
        RuleFor(x => x.Name).NotNull();
        RuleFor(x => x.Name).NotEmpty();
    }
}