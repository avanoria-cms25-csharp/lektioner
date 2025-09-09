namespace Business.Helpers;

internal static class IdGenerator
{
    public static string Generate()
    {
        return $"ID-{Guid.NewGuid()}";
    }
}
