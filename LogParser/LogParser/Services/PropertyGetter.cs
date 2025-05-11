using System.Reflection;
using LogParser.Interfaces;
using LogParser.Models;

namespace LogParser.Services;

public class PropertyGetter : IPropertyGetter
{
    public PropertyInfo GetPropertyData(string columnName)
    {
        var column = typeof(Log).GetProperty(columnName,
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase
        );
        return column;
    }
}