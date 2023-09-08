using FluentValidation;
using ScrumTeamService.Models;

namespace ScrumTeamService.Validators;

public sealed class ScrumOrganizationValidator : AbstractValidator<ScrumOrganization>
{
    public ScrumOrganizationValidator()
    {
        RuleFor(so => so.Name).NotNull();
        RuleFor(so => so.Name).NotEmpty();
    }
}