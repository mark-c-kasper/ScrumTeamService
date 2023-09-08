using System.Data;
using FluentValidation;
using ScrumTeamService.Models;

namespace ScrumTeamService.Validators;

public sealed class TeamMemberValidator : AbstractValidator<TeamMember>
{
    public TeamMemberValidator()
    {
        RuleFor(tm => tm.Position).NotNull();
        RuleFor(tm => tm.Position).NotEmpty();
        
        RuleFor(tm => tm.LastName).NotNull();
        RuleFor(tm => tm.LastName).NotEmpty();
        
        RuleFor(tm => tm.FirstName).NotNull();
        RuleFor(tm => tm.FirstName).NotEmpty();
        
        RuleFor(tm => tm.DepartmentId).NotNull();
        RuleFor(tm => tm.DepartmentId).NotEmpty();
        
        RuleFor(tm => tm.TeamId).NotNull();
        RuleFor(tm => tm.TeamId).NotEmpty();

        RuleFor(tm => tm.Salary).GreaterThanOrEqualTo(1);
        RuleFor(tm => tm.Salary).Equal(0).WithMessage("Sorry, you should probably be making more.");
    }
}