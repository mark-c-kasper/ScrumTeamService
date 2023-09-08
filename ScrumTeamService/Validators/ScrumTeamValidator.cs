using FluentValidation;
using ScrumTeamService.Models;

namespace ScrumTeamService.Validators;

public sealed class ScrumTeamValidator : AbstractValidator<ScrumTeam>
{
    public ScrumTeamValidator()
    {
        RuleFor(st => st.Name).NotNull();
        RuleFor(st => st.Name).NotEmpty();
        
        RuleFor(st => st.OrganizationId).NotNull();
        RuleFor(st => st.OrganizationId).NotEmpty();
    }
}