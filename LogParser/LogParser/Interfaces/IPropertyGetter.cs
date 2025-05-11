using System.Reflection;

namespace LogParser.Interfaces;

public interface IPropertyGetter
{
    PropertyInfo GetPropertyData(string columnName);
}