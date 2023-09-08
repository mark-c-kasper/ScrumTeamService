namespace ScrumTeamService.Extensions;

public static class ClassExtensions
{
    public static void ThrowExceptionIfNull<T>(this T obj, string nameOfObject) where T: class
    {
        if (obj is null)
        {
            throw new ArgumentNullException(nameOfObject);
        }
    }
}