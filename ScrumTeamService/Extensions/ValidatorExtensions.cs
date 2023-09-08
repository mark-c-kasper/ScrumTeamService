using FluentValidation;

namespace ScrumTeamService.Extensions;

public static class ValidatorExtensions
{
    public static async Task ValidateAsync<T>(this IValidator<T> validator, T objectToValidate, string validatorMessage, ILogger logger)
    {
        var validationResults = await validator.ValidateAsync(objectToValidate);

        if (!validationResults.IsValid)
        {
            logger.LogWarning(validatorMessage);
            throw new ValidationException(validationResults.Errors);
        }
    }
}