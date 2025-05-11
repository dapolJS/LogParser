using System.Reflection;
using System.Runtime.CompilerServices;

namespace LogParser.Services;

public static class Guard
{
    public static void CheckIfColumnIsNotNull(PropertyInfo column)
    {
        if (column == null)
        {
            throw new ArgumentException("Column Not Found");
        }
    }

    public static void CheckIfIsNullOrEmpty(string value, [CallerArgumentExpression("value")] string? parameterName = null)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException($"Not found value: {parameterName}");
        }
    }
}